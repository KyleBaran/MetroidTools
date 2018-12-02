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
    /// Value type for managing lorom addressing
    /// </summary>
    public struct LoRom :
        IComparable<LoRom>,
        IEquatable<LoRom>
    {
        #region public static methods

        public static LoRom FromPCAddress(int value)
        {
            BitHelper.ToLoRom(ref value, out value);
            return new LoRom(value);
        }

        #endregion

        #region public constructors

        public LoRom(byte bank, ushort address)
        {
            Bank = bank;
            Address = address;
        }

        public LoRom(int value)
        {
            Bank = (byte)(value >> 16);
            Address = (ushort)(value);
        }

        #endregion
        #region public fields

        public byte Bank;
        public ushort Address;

        #endregion
        #region public properties

        public int PackedValue
        {
            get
            {
                return (Bank << 16) + Address;
            }
        }

        public int PCAddress
        {
            get
            {
                return BitHelper.ToPCAddress(PackedValue);
            }
        }

        #endregion
        #region public methods (Object)

        public override bool Equals(object other)
        {
            return
                (other is LoRom) &&
                Equals((LoRom)other);
        }

        public override int GetHashCode()
        {
            return
                Bank.GetHashCode() +
                Address.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("${0:X2}:{1:X4}", Bank, Address);
        }

        #endregion
        #region public methods (IComparable)

        public int CompareTo(LoRom other)
        {
            return (PackedValue - other.PackedValue);
        }

        #endregion
        #region public methods (IEquatable)

        public bool Equals(LoRom other)
        {
            return
                Bank == other.Bank &&
                Address == other.Address;
        }

        #endregion
    }
}