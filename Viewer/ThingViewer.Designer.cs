namespace AcsViewer
{
    partial class ThingViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UIPortalParamLabel = new System.Windows.Forms.Label();
            this.UIPortalAccessParam = new System.Windows.Forms.TextBox();
            this.UIOneWayPortal = new System.Windows.Forms.CheckBox();
            this.thingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UIUsedByAnyone = new System.Windows.Forms.CheckBox();
            this.UIMagic = new System.Windows.Forms.CheckBox();
            this.UIAcsAdds = new System.Windows.Forms.TextBox();
            this.UIAcsMayAddLabel = new System.Windows.Forms.Label();
            this.UIAccessTypeLabel = new System.Windows.Forms.Label();
            this.UIAccessType = new System.Windows.Forms.TextBox();
            this.UISpellCastMessage = new System.Windows.Forms.TextBox();
            this.UISpellCastLabel = new System.Windows.Forms.Label();
            this.UIInvokedOnDropped = new System.Windows.Forms.CheckBox();
            this.UIInvokedPickedUp = new System.Windows.Forms.CheckBox();
            this.UIInvokedOnUse = new System.Windows.Forms.CheckBox();
            this.UIActionParam = new System.Windows.Forms.TextBox();
            this.UIActionParamLabel = new System.Windows.Forms.Label();
            this.UIAction = new System.Windows.Forms.TextBox();
            this.UIActionLabnel = new System.Windows.Forms.Label();
            this.UIAttackAdjust = new System.Windows.Forms.TextBox();
            this.UIAttackAdjustLabel = new System.Windows.Forms.Label();
            this.UIChangeOfBreaking = new System.Windows.Forms.TextBox();
            this.UIRange = new System.Windows.Forms.TextBox();
            this.UIPower = new System.Windows.Forms.TextBox();
            this.UIPicture = new System.Windows.Forms.TextBox();
            this.UIChangeOfBreakingLabel = new System.Windows.Forms.Label();
            this.UIRangeLabel = new System.Windows.Forms.Label();
            this.UIPowerLabel = new System.Windows.Forms.Label();
            this.UIPictureLabel = new System.Windows.Forms.Label();
            this.UIDisappearOnUse = new System.Windows.Forms.CheckBox();
            this.UIValue = new System.Windows.Forms.TextBox();
            this.UIValueLabel = new System.Windows.Forms.Label();
            this.UIWeight = new System.Windows.Forms.TextBox();
            this.UIWeightLabel = new System.Windows.Forms.Label();
            this.UIType = new System.Windows.Forms.TextBox();
            this.UITypeLabel = new System.Windows.Forms.Label();
            this.UIName = new System.Windows.Forms.TextBox();
            this.UINameLabel = new System.Windows.Forms.Label();
            this.UIPictureDisplay = new System.Windows.Forms.PictureBox();
            this.UIWhyCantPassMessage = new System.Windows.Forms.TextBox();
            this.UIWhyCantPassLabel = new System.Windows.Forms.Label();
            this.UIBumpActionLabel = new System.Windows.Forms.Label();
            this.UIBumpAction = new System.Windows.Forms.TextBox();
            this.UIDestroysThing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.thingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIPictureDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // UIPortalParamLabel
            // 
            this.UIPortalParamLabel.AutoSize = true;
            this.UIPortalParamLabel.Location = new System.Drawing.Point(330, 544);
            this.UIPortalParamLabel.Name = "UIPortalParamLabel";
            this.UIPortalParamLabel.Size = new System.Drawing.Size(67, 13);
            this.UIPortalParamLabel.TabIndex = 75;
            this.UIPortalParamLabel.Text = "Portal Param";
            // 
            // UIPortalAccessParam
            // 
            this.UIPortalAccessParam.Location = new System.Drawing.Point(329, 560);
            this.UIPortalAccessParam.Name = "UIPortalAccessParam";
            this.UIPortalAccessParam.ReadOnly = true;
            this.UIPortalAccessParam.Size = new System.Drawing.Size(170, 20);
            this.UIPortalAccessParam.TabIndex = 74;
            // 
            // UIOneWayPortal
            // 
            this.UIOneWayPortal.AutoCheck = false;
            this.UIOneWayPortal.AutoSize = true;
            this.UIOneWayPortal.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "OneWayPortal", true));
            this.UIOneWayPortal.Location = new System.Drawing.Point(17, 586);
            this.UIOneWayPortal.Name = "UIOneWayPortal";
            this.UIOneWayPortal.Size = new System.Drawing.Size(101, 17);
            this.UIOneWayPortal.TabIndex = 73;
            this.UIOneWayPortal.Text = "One Way Portal";
            this.UIOneWayPortal.UseVisualStyleBackColor = true;
            // 
            // thingBindingSource
            // 
            this.thingBindingSource.DataSource = typeof(AcsLib.Thing);
            // 
            // UIUsedByAnyone
            // 
            this.UIUsedByAnyone.AutoCheck = false;
            this.UIUsedByAnyone.AutoSize = true;
            this.UIUsedByAnyone.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "UsedByAnyone", true));
            this.UIUsedByAnyone.Location = new System.Drawing.Point(84, 195);
            this.UIUsedByAnyone.Name = "UIUsedByAnyone";
            this.UIUsedByAnyone.Size = new System.Drawing.Size(143, 17);
            this.UIUsedByAnyone.TabIndex = 72;
            this.UIUsedByAnyone.Text = "Can Be Used By Anyone";
            this.UIUsedByAnyone.UseVisualStyleBackColor = true;
            // 
            // UIMagic
            // 
            this.UIMagic.AutoCheck = false;
            this.UIMagic.AutoSize = true;
            this.UIMagic.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "Magic", true));
            this.UIMagic.Location = new System.Drawing.Point(23, 195);
            this.UIMagic.Name = "UIMagic";
            this.UIMagic.Size = new System.Drawing.Size(55, 17);
            this.UIMagic.TabIndex = 71;
            this.UIMagic.Text = "Magic";
            this.UIMagic.UseVisualStyleBackColor = true;
            // 
            // UIAcsAdds
            // 
            this.UIAcsAdds.Location = new System.Drawing.Point(17, 66);
            this.UIAcsAdds.Name = "UIAcsAdds";
            this.UIAcsAdds.ReadOnly = true;
            this.UIAcsAdds.Size = new System.Drawing.Size(100, 20);
            this.UIAcsAdds.TabIndex = 70;
            // 
            // UIAcsMayAddLabel
            // 
            this.UIAcsMayAddLabel.AutoSize = true;
            this.UIAcsMayAddLabel.Location = new System.Drawing.Point(14, 49);
            this.UIAcsMayAddLabel.Name = "UIAcsMayAddLabel";
            this.UIAcsMayAddLabel.Size = new System.Drawing.Size(76, 13);
            this.UIAcsMayAddLabel.TabIndex = 69;
            this.UIAcsMayAddLabel.Text = "ACS May Add ";
            // 
            // UIAccessTypeLabel
            // 
            this.UIAccessTypeLabel.AutoSize = true;
            this.UIAccessTypeLabel.Location = new System.Drawing.Point(19, 544);
            this.UIAccessTypeLabel.Name = "UIAccessTypeLabel";
            this.UIAccessTypeLabel.Size = new System.Drawing.Size(99, 13);
            this.UIAccessTypeLabel.TabIndex = 68;
            this.UIAccessTypeLabel.Text = "Portal Access Type";
            // 
            // UIAccessType
            // 
            this.UIAccessType.Location = new System.Drawing.Point(21, 560);
            this.UIAccessType.Name = "UIAccessType";
            this.UIAccessType.ReadOnly = true;
            this.UIAccessType.Size = new System.Drawing.Size(279, 20);
            this.UIAccessType.TabIndex = 67;
            // 
            // UISpellCastMessage
            // 
            this.UISpellCastMessage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "SpellCastMessage", true));
            this.UISpellCastMessage.Location = new System.Drawing.Point(21, 467);
            this.UISpellCastMessage.Multiline = true;
            this.UISpellCastMessage.Name = "UISpellCastMessage";
            this.UISpellCastMessage.ReadOnly = true;
            this.UISpellCastMessage.Size = new System.Drawing.Size(478, 51);
            this.UISpellCastMessage.TabIndex = 66;
            // 
            // UISpellCastLabel
            // 
            this.UISpellCastLabel.AutoSize = true;
            this.UISpellCastLabel.Location = new System.Drawing.Point(18, 450);
            this.UISpellCastLabel.Name = "UISpellCastLabel";
            this.UISpellCastLabel.Size = new System.Drawing.Size(100, 13);
            this.UISpellCastLabel.TabIndex = 65;
            this.UISpellCastLabel.Text = "Spell Cast Message";
            // 
            // UIInvokedOnDropped
            // 
            this.UIInvokedOnDropped.AutoCheck = false;
            this.UIInvokedOnDropped.AutoSize = true;
            this.UIInvokedOnDropped.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "InvokedWhenItemIsDropped", true));
            this.UIInvokedOnDropped.Location = new System.Drawing.Point(24, 292);
            this.UIInvokedOnDropped.Name = "UIInvokedOnDropped";
            this.UIInvokedOnDropped.Size = new System.Drawing.Size(168, 17);
            this.UIInvokedOnDropped.TabIndex = 64;
            this.UIInvokedOnDropped.Text = "Invoked when item is dropped";
            this.UIInvokedOnDropped.UseVisualStyleBackColor = true;
            // 
            // UIInvokedPickedUp
            // 
            this.UIInvokedPickedUp.AutoCheck = false;
            this.UIInvokedPickedUp.AutoSize = true;
            this.UIInvokedPickedUp.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "InvokedWhenItemIsPickedUp", true));
            this.UIInvokedPickedUp.Location = new System.Drawing.Point(24, 315);
            this.UIInvokedPickedUp.Name = "UIInvokedPickedUp";
            this.UIInvokedPickedUp.Size = new System.Drawing.Size(176, 17);
            this.UIInvokedPickedUp.TabIndex = 63;
            this.UIInvokedPickedUp.Text = "Invoked when item is picked up";
            this.UIInvokedPickedUp.UseVisualStyleBackColor = true;
            // 
            // UIInvokedOnUse
            // 
            this.UIInvokedOnUse.AutoCheck = false;
            this.UIInvokedOnUse.AutoSize = true;
            this.UIInvokedOnUse.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "InvokedWhenOwnerUsesItem", true));
            this.UIInvokedOnUse.Location = new System.Drawing.Point(24, 269);
            this.UIInvokedOnUse.Name = "UIInvokedOnUse";
            this.UIInvokedOnUse.Size = new System.Drawing.Size(191, 17);
            this.UIInvokedOnUse.TabIndex = 62;
            this.UIInvokedOnUse.Text = "Invoked when owner uses the item";
            this.UIInvokedOnUse.UseVisualStyleBackColor = true;
            // 
            // UIActionParam
            // 
            this.UIActionParam.Location = new System.Drawing.Point(332, 243);
            this.UIActionParam.Name = "UIActionParam";
            this.UIActionParam.ReadOnly = true;
            this.UIActionParam.Size = new System.Drawing.Size(170, 20);
            this.UIActionParam.TabIndex = 61;
            this.UIActionParam.DoubleClick += new System.EventHandler(this.UIActionParam_DoubleClick);
            // 
            // UIActionParamLabel
            // 
            this.UIActionParamLabel.AutoSize = true;
            this.UIActionParamLabel.Location = new System.Drawing.Point(332, 226);
            this.UIActionParamLabel.Name = "UIActionParamLabel";
            this.UIActionParamLabel.Size = new System.Drawing.Size(70, 13);
            this.UIActionParamLabel.TabIndex = 60;
            this.UIActionParamLabel.Text = "Action Param";
            // 
            // UIAction
            // 
            this.UIAction.Location = new System.Drawing.Point(24, 243);
            this.UIAction.Name = "UIAction";
            this.UIAction.ReadOnly = true;
            this.UIAction.Size = new System.Drawing.Size(279, 20);
            this.UIAction.TabIndex = 59;
            // 
            // UIActionLabnel
            // 
            this.UIActionLabnel.AutoSize = true;
            this.UIActionLabnel.Location = new System.Drawing.Point(21, 226);
            this.UIActionLabnel.Name = "UIActionLabnel";
            this.UIActionLabnel.Size = new System.Drawing.Size(37, 13);
            this.UIActionLabnel.TabIndex = 58;
            this.UIActionLabnel.Text = "Action";
            // 
            // UIAttackAdjust
            // 
            this.UIAttackAdjust.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "AttackAdjustment", true));
            this.UIAttackAdjust.Location = new System.Drawing.Point(137, 157);
            this.UIAttackAdjust.Name = "UIAttackAdjust";
            this.UIAttackAdjust.ReadOnly = true;
            this.UIAttackAdjust.Size = new System.Drawing.Size(100, 20);
            this.UIAttackAdjust.TabIndex = 57;
            // 
            // UIAttackAdjustLabel
            // 
            this.UIAttackAdjustLabel.AutoSize = true;
            this.UIAttackAdjustLabel.Location = new System.Drawing.Point(134, 140);
            this.UIAttackAdjustLabel.Name = "UIAttackAdjustLabel";
            this.UIAttackAdjustLabel.Size = new System.Drawing.Size(70, 13);
            this.UIAttackAdjustLabel.TabIndex = 56;
            this.UIAttackAdjustLabel.Text = "Attack Adjust";
            // 
            // UIChangeOfBreaking
            // 
            this.UIChangeOfBreaking.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "ChanceOfBreaking", true));
            this.UIChangeOfBreaking.Location = new System.Drawing.Point(21, 157);
            this.UIChangeOfBreaking.Name = "UIChangeOfBreaking";
            this.UIChangeOfBreaking.ReadOnly = true;
            this.UIChangeOfBreaking.Size = new System.Drawing.Size(100, 20);
            this.UIChangeOfBreaking.TabIndex = 55;
            // 
            // UIRange
            // 
            this.UIRange.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Range", true));
            this.UIRange.Location = new System.Drawing.Point(386, 157);
            this.UIRange.Name = "UIRange";
            this.UIRange.ReadOnly = true;
            this.UIRange.Size = new System.Drawing.Size(100, 20);
            this.UIRange.TabIndex = 54;
            // 
            // UIPower
            // 
            this.UIPower.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Power", true));
            this.UIPower.Location = new System.Drawing.Point(266, 157);
            this.UIPower.Name = "UIPower";
            this.UIPower.ReadOnly = true;
            this.UIPower.Size = new System.Drawing.Size(100, 20);
            this.UIPower.TabIndex = 53;
            // 
            // UIPicture
            // 
            this.UIPicture.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Picture", true));
            this.UIPicture.Location = new System.Drawing.Point(209, 68);
            this.UIPicture.Name = "UIPicture";
            this.UIPicture.ReadOnly = true;
            this.UIPicture.Size = new System.Drawing.Size(100, 20);
            this.UIPicture.TabIndex = 52;
            // 
            // UIChangeOfBreakingLabel
            // 
            this.UIChangeOfBreakingLabel.AutoSize = true;
            this.UIChangeOfBreakingLabel.Location = new System.Drawing.Point(20, 141);
            this.UIChangeOfBreakingLabel.Name = "UIChangeOfBreakingLabel";
            this.UIChangeOfBreakingLabel.Size = new System.Drawing.Size(101, 13);
            this.UIChangeOfBreakingLabel.TabIndex = 51;
            this.UIChangeOfBreakingLabel.Text = "Chance of Breaking";
            // 
            // UIRangeLabel
            // 
            this.UIRangeLabel.AutoSize = true;
            this.UIRangeLabel.Location = new System.Drawing.Point(385, 140);
            this.UIRangeLabel.Name = "UIRangeLabel";
            this.UIRangeLabel.Size = new System.Drawing.Size(39, 13);
            this.UIRangeLabel.TabIndex = 50;
            this.UIRangeLabel.Text = "Range";
            // 
            // UIPowerLabel
            // 
            this.UIPowerLabel.AutoSize = true;
            this.UIPowerLabel.Location = new System.Drawing.Point(263, 140);
            this.UIPowerLabel.Name = "UIPowerLabel";
            this.UIPowerLabel.Size = new System.Drawing.Size(37, 13);
            this.UIPowerLabel.TabIndex = 49;
            this.UIPowerLabel.Text = "Power";
            // 
            // UIPictureLabel
            // 
            this.UIPictureLabel.AutoSize = true;
            this.UIPictureLabel.Location = new System.Drawing.Point(206, 51);
            this.UIPictureLabel.Name = "UIPictureLabel";
            this.UIPictureLabel.Size = new System.Drawing.Size(40, 13);
            this.UIPictureLabel.TabIndex = 48;
            this.UIPictureLabel.Text = "Picture";
            // 
            // UIDisappearOnUse
            // 
            this.UIDisappearOnUse.AutoCheck = false;
            this.UIDisappearOnUse.AutoSize = true;
            this.UIDisappearOnUse.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "DisappearsAfterUser", true));
            this.UIDisappearOnUse.Location = new System.Drawing.Point(233, 195);
            this.UIDisappearOnUse.Name = "UIDisappearOnUse";
            this.UIDisappearOnUse.Size = new System.Drawing.Size(123, 17);
            this.UIDisappearOnUse.TabIndex = 47;
            this.UIDisappearOnUse.Text = "Disappears after use";
            this.UIDisappearOnUse.UseVisualStyleBackColor = true;
            // 
            // UIValue
            // 
            this.UIValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Value", true));
            this.UIValue.Location = new System.Drawing.Point(128, 113);
            this.UIValue.Name = "UIValue";
            this.UIValue.ReadOnly = true;
            this.UIValue.Size = new System.Drawing.Size(100, 20);
            this.UIValue.TabIndex = 46;
            // 
            // UIValueLabel
            // 
            this.UIValueLabel.AutoSize = true;
            this.UIValueLabel.Location = new System.Drawing.Point(128, 96);
            this.UIValueLabel.Name = "UIValueLabel";
            this.UIValueLabel.Size = new System.Drawing.Size(34, 13);
            this.UIValueLabel.TabIndex = 45;
            this.UIValueLabel.Text = "Value";
            // 
            // UIWeight
            // 
            this.UIWeight.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Weight", true));
            this.UIWeight.Location = new System.Drawing.Point(20, 113);
            this.UIWeight.Name = "UIWeight";
            this.UIWeight.ReadOnly = true;
            this.UIWeight.Size = new System.Drawing.Size(100, 20);
            this.UIWeight.TabIndex = 44;
            // 
            // UIWeightLabel
            // 
            this.UIWeightLabel.AutoSize = true;
            this.UIWeightLabel.Location = new System.Drawing.Point(17, 96);
            this.UIWeightLabel.Name = "UIWeightLabel";
            this.UIWeightLabel.Size = new System.Drawing.Size(41, 13);
            this.UIWeightLabel.TabIndex = 43;
            this.UIWeightLabel.Text = "Weight";
            // 
            // UIType
            // 
            this.UIType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "ThingTypeDescription", true));
            this.UIType.Location = new System.Drawing.Point(209, 26);
            this.UIType.Name = "UIType";
            this.UIType.ReadOnly = true;
            this.UIType.Size = new System.Drawing.Size(117, 20);
            this.UIType.TabIndex = 42;
            // 
            // UITypeLabel
            // 
            this.UITypeLabel.AutoSize = true;
            this.UITypeLabel.Location = new System.Drawing.Point(206, 9);
            this.UITypeLabel.Name = "UITypeLabel";
            this.UITypeLabel.Size = new System.Drawing.Size(31, 13);
            this.UITypeLabel.TabIndex = 41;
            this.UITypeLabel.Text = "Type";
            // 
            // UIName
            // 
            this.UIName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "Name", true));
            this.UIName.Location = new System.Drawing.Point(15, 26);
            this.UIName.Name = "UIName";
            this.UIName.ReadOnly = true;
            this.UIName.Size = new System.Drawing.Size(177, 20);
            this.UIName.TabIndex = 40;
            // 
            // UINameLabel
            // 
            this.UINameLabel.AutoSize = true;
            this.UINameLabel.Location = new System.Drawing.Point(12, 9);
            this.UINameLabel.Name = "UINameLabel";
            this.UINameLabel.Size = new System.Drawing.Size(35, 13);
            this.UINameLabel.TabIndex = 39;
            this.UINameLabel.Text = "Name";
            // 
            // UIPictureDisplay
            // 
            this.UIPictureDisplay.Location = new System.Drawing.Point(401, 26);
            this.UIPictureDisplay.Name = "UIPictureDisplay";
            this.UIPictureDisplay.Size = new System.Drawing.Size(73, 74);
            this.UIPictureDisplay.TabIndex = 77;
            this.UIPictureDisplay.TabStop = false;
            this.UIPictureDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.UIPictureDisplay_Paint);
            // 
            // UIWhyCantPassMessage
            // 
            this.UIWhyCantPassMessage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.thingBindingSource, "WhyCannotPassMessage", true));
            this.UIWhyCantPassMessage.Location = new System.Drawing.Point(24, 400);
            this.UIWhyCantPassMessage.Multiline = true;
            this.UIWhyCantPassMessage.Name = "UIWhyCantPassMessage";
            this.UIWhyCantPassMessage.ReadOnly = true;
            this.UIWhyCantPassMessage.Size = new System.Drawing.Size(478, 47);
            this.UIWhyCantPassMessage.TabIndex = 79;
            // 
            // UIWhyCantPassLabel
            // 
            this.UIWhyCantPassLabel.AutoSize = true;
            this.UIWhyCantPassLabel.Location = new System.Drawing.Point(21, 383);
            this.UIWhyCantPassLabel.Name = "UIWhyCantPassLabel";
            this.UIWhyCantPassLabel.Size = new System.Drawing.Size(128, 13);
            this.UIWhyCantPassLabel.TabIndex = 78;
            this.UIWhyCantPassLabel.Text = "Why Can\'t Pass Message";
            // 
            // UIBumpActionLabel
            // 
            this.UIBumpActionLabel.AutoSize = true;
            this.UIBumpActionLabel.Location = new System.Drawing.Point(21, 341);
            this.UIBumpActionLabel.Name = "UIBumpActionLabel";
            this.UIBumpActionLabel.Size = new System.Drawing.Size(67, 13);
            this.UIBumpActionLabel.TabIndex = 80;
            this.UIBumpActionLabel.Text = "Bump Action";
            // 
            // UIBumpAction
            // 
            this.UIBumpAction.Location = new System.Drawing.Point(24, 357);
            this.UIBumpAction.Name = "UIBumpAction";
            this.UIBumpAction.ReadOnly = true;
            this.UIBumpAction.Size = new System.Drawing.Size(333, 20);
            this.UIBumpAction.TabIndex = 81;
            // 
            // UIDestroysThing
            // 
            this.UIDestroysThing.AutoCheck = false;
            this.UIDestroysThing.AutoSize = true;
            this.UIDestroysThing.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.thingBindingSource, "DestroyThingNeededToMove", true));
            this.UIDestroysThing.Location = new System.Drawing.Point(166, 586);
            this.UIDestroysThing.Name = "UIDestroysThing";
            this.UIDestroysThing.Size = new System.Drawing.Size(183, 17);
            this.UIDestroysThing.TabIndex = 82;
            this.UIDestroysThing.Text = "Destroys Thing Allowing Passage";
            this.UIDestroysThing.UseVisualStyleBackColor = true;
            // 
            // ThingViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 606);
            this.Controls.Add(this.UIDestroysThing);
            this.Controls.Add(this.UIBumpAction);
            this.Controls.Add(this.UIBumpActionLabel);
            this.Controls.Add(this.UIWhyCantPassMessage);
            this.Controls.Add(this.UIWhyCantPassLabel);
            this.Controls.Add(this.UIPictureDisplay);
            this.Controls.Add(this.UIPortalParamLabel);
            this.Controls.Add(this.UIPortalAccessParam);
            this.Controls.Add(this.UIOneWayPortal);
            this.Controls.Add(this.UIUsedByAnyone);
            this.Controls.Add(this.UIMagic);
            this.Controls.Add(this.UIAcsAdds);
            this.Controls.Add(this.UIAcsMayAddLabel);
            this.Controls.Add(this.UIAccessTypeLabel);
            this.Controls.Add(this.UIAccessType);
            this.Controls.Add(this.UISpellCastMessage);
            this.Controls.Add(this.UISpellCastLabel);
            this.Controls.Add(this.UIInvokedOnDropped);
            this.Controls.Add(this.UIInvokedPickedUp);
            this.Controls.Add(this.UIInvokedOnUse);
            this.Controls.Add(this.UIActionParam);
            this.Controls.Add(this.UIActionParamLabel);
            this.Controls.Add(this.UIAction);
            this.Controls.Add(this.UIActionLabnel);
            this.Controls.Add(this.UIAttackAdjust);
            this.Controls.Add(this.UIAttackAdjustLabel);
            this.Controls.Add(this.UIChangeOfBreaking);
            this.Controls.Add(this.UIRange);
            this.Controls.Add(this.UIPower);
            this.Controls.Add(this.UIPicture);
            this.Controls.Add(this.UIChangeOfBreakingLabel);
            this.Controls.Add(this.UIRangeLabel);
            this.Controls.Add(this.UIPowerLabel);
            this.Controls.Add(this.UIPictureLabel);
            this.Controls.Add(this.UIDisappearOnUse);
            this.Controls.Add(this.UIValue);
            this.Controls.Add(this.UIValueLabel);
            this.Controls.Add(this.UIWeight);
            this.Controls.Add(this.UIWeightLabel);
            this.Controls.Add(this.UIType);
            this.Controls.Add(this.UITypeLabel);
            this.Controls.Add(this.UIName);
            this.Controls.Add(this.UINameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ThingViewer";
            this.Text = "ThingViewer";
            this.Load += new System.EventHandler(this.ThingViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UIPictureDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource thingBindingSource;
        private System.Windows.Forms.Label UIPortalParamLabel;
        private System.Windows.Forms.TextBox UIPortalAccessParam;
        private System.Windows.Forms.CheckBox UIOneWayPortal;
        private System.Windows.Forms.CheckBox UIUsedByAnyone;
        private System.Windows.Forms.CheckBox UIMagic;
        private System.Windows.Forms.TextBox UIAcsAdds;
        private System.Windows.Forms.Label UIAcsMayAddLabel;
        private System.Windows.Forms.Label UIAccessTypeLabel;
        private System.Windows.Forms.TextBox UIAccessType;
        private System.Windows.Forms.TextBox UISpellCastMessage;
        private System.Windows.Forms.Label UISpellCastLabel;
        private System.Windows.Forms.CheckBox UIInvokedOnDropped;
        private System.Windows.Forms.CheckBox UIInvokedPickedUp;
        private System.Windows.Forms.CheckBox UIInvokedOnUse;
        private System.Windows.Forms.TextBox UIActionParam;
        private System.Windows.Forms.Label UIActionParamLabel;
        private System.Windows.Forms.TextBox UIAction;
        private System.Windows.Forms.Label UIActionLabnel;
        private System.Windows.Forms.TextBox UIAttackAdjust;
        private System.Windows.Forms.Label UIAttackAdjustLabel;
        private System.Windows.Forms.TextBox UIChangeOfBreaking;
        private System.Windows.Forms.TextBox UIRange;
        private System.Windows.Forms.TextBox UIPower;
        private System.Windows.Forms.TextBox UIPicture;
        private System.Windows.Forms.Label UIChangeOfBreakingLabel;
        private System.Windows.Forms.Label UIRangeLabel;
        private System.Windows.Forms.Label UIPowerLabel;
        private System.Windows.Forms.Label UIPictureLabel;
        private System.Windows.Forms.CheckBox UIDisappearOnUse;
        private System.Windows.Forms.TextBox UIValue;
        private System.Windows.Forms.Label UIValueLabel;
        private System.Windows.Forms.TextBox UIWeight;
        private System.Windows.Forms.Label UIWeightLabel;
        private System.Windows.Forms.TextBox UIType;
        private System.Windows.Forms.Label UITypeLabel;
        private System.Windows.Forms.TextBox UIName;
        private System.Windows.Forms.Label UINameLabel;
        private System.Windows.Forms.PictureBox UIPictureDisplay;
        private System.Windows.Forms.TextBox UIWhyCantPassMessage;
        private System.Windows.Forms.Label UIWhyCantPassLabel;
        private System.Windows.Forms.Label UIBumpActionLabel;
        private System.Windows.Forms.TextBox UIBumpAction;
        private System.Windows.Forms.CheckBox UIDestroysThing;
    }
}