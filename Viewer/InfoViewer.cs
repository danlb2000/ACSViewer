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
    public partial class InfoViewer : Form
    {
        public GameDefinition Definition { get; set; }

        public InfoViewer()
        {
            InitializeComponent();        
        }

        private void InfoViewer_Load(object sender, EventArgs e)
        {
            if (Definition == null) return;

            UIName.Text = Definition.Name;
            UIByLine.Text = Definition.Byline;
            UIIntroduction.Text = Definition.IntroText;
        }
    }
}
