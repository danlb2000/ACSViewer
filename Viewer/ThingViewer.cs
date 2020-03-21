/*   This file is part of ACS Viewer.
     Copyright (C) 2016  Dan Boris (danlb_2000@yahoo.com)

    ACS Viewer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ACS Viewer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using AcsLib;
using System;
using System.Windows.Forms;

namespace AcsViewer
{
    public partial class ThingViewer : Form
    {

        public GameDefinition Definition { get; set; }
        public Thing Thing {get; set;}     
        public byte? ActionParameter { get; set; }

        public ThingViewer()
        {
            InitializeComponent();
        }

        private void ThingViewer_Load(object sender, EventArgs e)
        {
            RefreshThing();
            ActionParameter = null;
        }

        private void RefreshThing()
        {
            UpdateThing();
            SetLabels();
            ShowActionParam();
        }

        private void SetLabels()
        {
            if (this.Thing == null) return;

            switch (this.Thing.TypeOfThing)
            {
                case AcsLib.Thing.ThingType.Treasure:
                    UIDisappearOnUse.Text = "Disappears when dropped";
                    break;
            }
        }

        private void ShowActionParam()
        {
            if (this.Thing == null || this.Thing.Action == null) return;

            byte param;

            if (this.Thing.ChooseWhenPutIntoRoom == AcsLib.Thing.ChooseWhenPutIntoRoomType.SpellModifier && !ActionParameter.HasValue)
            {
                UIActionParam.Text = "[Choose]";
                return;
            }
            else if (this.Thing.ChooseWhenPutIntoRoom == AcsLib.Thing.ChooseWhenPutIntoRoomType.SpellModifier && ActionParameter.HasValue)
            {
                param = (byte)ActionParameter;
            }
            else
            {
                param = this.Thing.Action.Parameter;
            }

            switch (this.Thing.Action.ParameterType)
            {
                case SpellAction.ActionParameterType.Music:
                    Music mus = new Music();
                    UIActionParam.Text = param.ToString() + " - " + mus.GetMusicName(param);
                    break;
                case SpellAction.ActionParameterType.Message:
                    UIActionParam.Text = param.ToString();
                    break;
                case SpellAction.ActionParameterType.VictimStat:
                    UIActionParam.Text = Enum.ToObject(typeof(Creature.Stat), param).ToString();
                    break;
                case SpellAction.ActionParameterType.ChangeLifeForcePower:
                    int n = param & 0x3F;
                    if (param.BitField(7)) n = -n;
                    UIActionParam.Text = n.ToString();
                    if (param.BitField(6))
                        UIActionParam.Text += " Temporarily";
                    else
                        UIActionParam.Text += " Permanently";
                    break;
                case SpellAction.ActionParameterType.Creature:
                    if (param == 0)
                    {
                        UIActionParam.Text = "Banish all creatures in room";
                    }
                    else
                    {
                        UIActionParam.Text = "Summon " + param.ToString();
                        UIActionParam.Text += " - " + Definition.CreatureList[param - 1].Name;
                    }
                    break;
                case SpellAction.ActionParameterType.Item:
                    UIActionParam.Text = param.ToString() + " - ";
                    UIActionParam.Text += Definition.Things[param - 1].Name;
                    break;

            }
        }

        private void UpdateThing()
        {
            // Get thing
            thingBindingSource.DataSource = this.Thing;
            if (this.Thing == null) return;

            // Portal
            if (this.Thing.TypeOfThing == AcsLib.Thing.ThingType.Portal || this.Thing.TypeOfThing == AcsLib.Thing.ThingType.Space)
            {
                UIAccessType.Text = this.Thing.PortalAccessTypeDescription;
                UIAccessTypeLabel.Text = "Portal Access Type";
                UIPortalParamLabel.Text = "Portal Access Parameter";

                if (this.Thing.PortalAccess == AcsLib.Thing.PortalAccessType.SpecificItem || this.Thing.PortalAccess == AcsLib.Thing.PortalAccessType.DoNotOwn)
                {
                    UIPortalAccessParam.Text = this.Thing.PortalActionParameter.ToString() + " - " + Definition.Things[this.Thing.PortalActionParameter - 1].Name;
                }
            }

            if (this.Thing.TypeOfThing == AcsLib.Thing.ThingType.CustomSpace)
            {
                UIAccessType.Text = this.Thing.CustomSpaceAccessTypeDescription;
                UIAccessTypeLabel.Text = "Custom Space Access Type";
                UIPortalParamLabel.Text = "Custom Space Access Parameter";
                switch (this.Thing.CustomSpaceAccess)
                {
                    case AcsLib.Thing.CustomSpaceAccessType.InvokeDropHere:
                    case AcsLib.Thing.CustomSpaceAccessType.SpecificItem:
                    case AcsLib.Thing.CustomSpaceAccessType.DoesNotOwn:
                        byte portalParam = (byte)this.Thing.PortalActionParameter;
                        if (portalParam > 0)
                        {
                            UIPortalAccessParam.Text = this.Thing.PortalActionParameter.ToString() + " - " + Definition.Things[this.Thing.PortalActionParameter - 1].Name;
                        }
                        else
                        {
                            UIPortalAccessParam.Text = "[Choose]";
                        }
                        break;
                }
            }

            if (this.Thing.TypeOfThing == Thing.ThingType.Obstacle || this.Thing.TypeOfThing == Thing.ThingType.CustomObstacle)
            {
                UIBumpAction.Text = this.Thing.BumpAction.ToDescription();
            }

            // How many ACS can add
            UIAction.Text = this.Thing.Action.ToString();
            if (this.Thing.AcsMayAdd == 15)
                UIAcsAdds.Text = "Many";
            else
                UIAcsAdds.Text = this.Thing.AcsMayAdd.ToString();

            //Title
            this.Text = "View " + this.Thing.Name;

  
        }

        private void UIPictureDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (!this.Thing.HasPicture) return;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (Definition.Pictures[this.Thing.Picture] != null) e.Graphics.DrawImage(Definition.Pictures[this.Thing.Picture], 0, 0, 64, 64);
        }

        private void UIActionParam_DoubleClick(object sender, EventArgs e)
        {
      
            switch (this.Thing.Action.ParameterType)
            {
                case SpellAction.ActionParameterType.Message:
                    var form = new DisplayText();
                    byte param;
                    param = byte.Parse(UIActionParam.Text);
                    form.Message = Definition.LongMessages[param - 1];
                    form.Title = "Long Message: " + param.ToString();
                    form.MdiParent = this.MdiParent;                   
                    form.Show();
                    break;
            }
        }

    }
}
