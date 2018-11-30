/*
 * Author: Kyle Baran
 * Date: November 30, 2018
 * 
 * This is a simple address calculator for romhacking Super Metroid. It can probably
 * be used for other things, too. It converts between PC address and LoRom values.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AddressCalculator
{
    /**/

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
