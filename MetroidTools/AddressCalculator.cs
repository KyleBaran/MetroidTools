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
    /// Converts between PC Address and LoRom Address
    /// </summary>
    public partial class AddressCalculator :
        Form
    {
        #region constructors

        public AddressCalculator()
        {
            InitializeComponent();
            validateAddress();
        }

        #endregion
        #region events (valuechanged)

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            validateAddress();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            validateAddress();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            validateAddress2();
        }

        #endregion
        #region methods

        private void validateAddress()
        {
            LoRom value = new LoRom(
                (byte)numericUpDown1.Value,
                (ushort)numericUpDown2.Value);

            textBox1.Text = String.Format("{0:X6}", value.PCAddress);
        }

        private void validateAddress2()
        {
            LoRom value = new LoRom(BitHelper.ToLoRom((int)numericUpDown3.Value));
            textBox2.Text = String.Format("{0:X6}", value.PackedValue);
        }

        #endregion
    }
}