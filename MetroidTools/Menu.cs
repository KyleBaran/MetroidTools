/*
 * Author: Dan
 * Date: December 2018
 * 
 * This code is released under the GPL v3.0 license.
 * All other rights (c) their respective parties; I make no claims of ownership.
 */

namespace MetroidTools
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// Main menu for a collection of helpful editing tools
    /// </summary>
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddressCalculator();
            form.Show(this);
        }
    }
}
