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
    public partial class PlayGame : Form
    {
        GameEngine engine = null;
        GameDefinition definition = null;

        public PlayGame(string fileName)
        {
            InitializeComponent();
            var loader = new GameLoader();
            definition = loader.LoadGame(fileName);
            engine = new GameEngine(definition);
            pictureBox1.Refresh();

        }

        private void PlayGame_Load(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            this.Text = "Playing " + definition.Name;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            engine.Render(e.Graphics);
        }

        private void PlayGame_KeyDown(object sender, KeyEventArgs e)
        {
            engine.KeyPressed(e.KeyCode);

            pictureBox1.Refresh();
        }
    }
}
