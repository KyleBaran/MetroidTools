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
    /// Contains helpful functions to work with byte-level data
    /// </summary>
    public static class BitHelper
    {
        #region public constants

        public const int MinPCAddress = 0x00000000;
        public const int MaxPCAddress = 0x3FFFFFFF;

        public const int BankSize = 0x8000;
        public const int BankOffset = 0x0080;
        public const int BankAddressOffset = 0x8000;

        #endregion
        #region public static methods

        #region ToLoRom

        public static void ToLoRom(ref int value, out int result)
        {
            result =
                ((value / BitHelper.BankSize + BitHelper.BankOffset) << 16) +
                (value % BitHelper.BankSize + BitHelper.BankAddressOffset);
        }

        public static int ToLoRom(int value)
        {
            ToLoRom(ref value, out value);
            return value;
        }

        #endregion
        #region ToPCAddress

        public static void ToPCAddress(ref int value, out int result)
        {
            result = BitHelper.BankSize *
                (((value & 0xFF0000) >> 16) - BitHelper.BankOffset) +
                ((value & 0x00FFFF) - BitHelper.BankAddressOffset);
        }

        public static int ToPCAddress(int value)
        {
            ToPCAddress(ref value, out value);
            return value;
        }

        #endregion

        #endregion
    }
}
