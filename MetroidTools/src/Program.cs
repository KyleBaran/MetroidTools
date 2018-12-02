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
    ///  Main entry point
    /// </summary>
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            string path = @"C:\Users\Kyle\Desktop\metroid\mod\test.smc";
            byte[] file = System.IO.File.ReadAllBytes(path);

            LoRom lr = new LoRom(0x909E8F);
            int offset = lr.PCAddress;

            for (int i = 0; i < 4; i++)
            {
                file[offset + i] = 0;
            }

            //System.IO.File.WriteAllBytes(path, file);

            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
