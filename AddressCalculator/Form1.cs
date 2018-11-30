/*
 * Author: Kyle Baran
 * Date: November 30, 2018
 * 
 * This is a simple address calculator for romhacking Super Metroid. It can probably
 * be used for other things, too. It converts between PC address and LoRom values.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddressCalculator
{
    public partial class Form1 : Form
    {
        #region constructors

        public Form1()
        {
            InitializeComponent();
            m_validateAddress();
            m_validateAddress2();
        }

        #endregion
        #region methods

        private void m_validateAddress()
        {
            const int bankBase = 0x80;
            const int bankScale = 0x8000;
            const int addressOffset = 0x8000;

            int bank = (int)numericUpDown2.Value;
            int address = (int)numericUpDown3.Value;

            int value = (bank - bankBase) * bankScale + address - addressOffset;

            pcAddress.Text = String.Format("{0:X6}", value);
        }

        private void m_validateAddress2()
        {
            const int bankBase = 0x80;
            const int bankScale = 0x8000;
            const int addressOffset = 0x8000;

            int bank = (int)numericUpDown4.Value / bankScale + bankBase;
            int address = (int)numericUpDown4.Value % bankScale + addressOffset;

            textBox1.Text = String.Format("{0:X2}", bank);
            textBox2.Text = String.Format("{0:X4}", address);
            textBox3.Text = textBox1.Text + textBox2.Text;
        }

        #endregion
        #region events (keydown)

        private void spinnerStep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void spinnerAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                numericUpDown3.Value = numericUpDown3.Minimum;
        }

        private void spinnerBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                numericUpDown2.Value = numericUpDown2.Minimum;
        }

        private void numericUpDown4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                numericUpDown4.Value = numericUpDown4.Minimum;
        }

        #endregion
        #region events (click)

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown2.Minimum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown3.Value = numericUpDown3.Minimum;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown4.Value = numericUpDown4.Minimum;
        }

        #endregion
        #region events (valuechanged)

        private void spinnerStep_ValueChanged(object sender, EventArgs e)
        {
            // numericUpDown2.Increment = numericUpDown1.Value;
            numericUpDown3.Increment = numericUpDown1.Value;
            numericUpDown4.Increment = numericUpDown1.Value;
        }

        private void spinnerBank_ValueChanged(object sender, EventArgs e)
        {
            m_validateAddress();
        }

        private void spinnerAddress_ValueChanged(object sender, EventArgs e)
        {
            m_validateAddress();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            m_validateAddress2();
        }

        #endregion     
    }
}
