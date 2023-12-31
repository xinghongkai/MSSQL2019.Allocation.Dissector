﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace InternalsViewer.Internals
{
    /// <summary>
    /// Class for decoding and converting between different SQL Server data types
    /// </summary>
    public static class DataConverter
    {
        private static readonly char[] hexDigits = {'0', '1', '2', '3', '4', '5', '6', '7',
                                                    '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        /// <summary>
        /// Returns a hex string for a given array of bytes
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            if (bytes == null)
                return string.Empty;

            char[] chars = new char[bytes.Length * 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];

                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }

            return new string(chars);
        }

        /// <summary>
        /// Returns a hex string for a given byte
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToHexString(byte bytes)
        {
            return ToHexString(new byte[1] { bytes });
        }

        /// <summary>
        /// Converts a bit at a given index of a byte array
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static string BinaryToString(byte[] data, int index)
        {
            return new BitArray(data).Get(index).ToString();
        }

        /// <summary>
        /// Converts a binary GUID to string
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string BinaryToGuidString(byte[] data)
        {
            if (data == null)
                return string.Empty;

            if (data.Length != 16)
            {
                throw new ArgumentException("Invalid GUID");
            }

            return string.Format(CultureInfo.InvariantCulture,
                                 "{0}{1}{2}{3}-{4}{5}-{6}{7}-{8}{9}-{10}{11}{12}{13}{14}{15}",
                                 ToHexString(data[3]),
                                 ToHexString(data[2]),
                                 ToHexString(data[1]),
                                 ToHexString(data[0]),
                                 ToHexString(data[5]),
                                 ToHexString(data[4]),
                                 ToHexString(data[7]),
                                 ToHexString(data[6]),
                                 ToHexString(data[8]),
                                 ToHexString(data[9]),
                                 ToHexString(data[10]),
                                 ToHexString(data[11]),
                                 ToHexString(data[12]),
                                 ToHexString(data[13]),
                                 ToHexString(data[14]),
                                 ToHexString(data[15]));
        }

        /// <summary>
        /// Converts a byte array to a value
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="sqlType">SQL Server type</param>
        /// <param name="precision">The precision.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public static string BinaryToString(byte[] data, SqlDbType sqlType, byte precision, byte scale)
        {
            if (data == null) return string.Empty;

            try
            {
                switch (sqlType)
                {
                    case SqlDbType.BigInt:

                        return BitConverter.ToInt64(data, 0).ToString(CultureInfo.CurrentCulture);

                    case SqlDbType.Int:

                        return BitConverter.ToInt32(data, 0).ToString(CultureInfo.CurrentCulture);

                    case SqlDbType.TinyInt:

                        return ((int)data[0]).ToString(CultureInfo.CurrentCulture);

                    case SqlDbType.SmallInt:

                        return BitConverter.ToInt16(data, 0).ToString(CultureInfo.CurrentCulture);

                    case SqlDbType.Char:
                    case SqlDbType.VarChar:

                        return Regex.Replace(Encoding.UTF8.GetString(data), @"[^\t -~]", "");

                    case SqlDbType.NChar:
                    case SqlDbType.NVarChar:

                        return Encoding.Unicode.GetString(data);

                    case SqlDbType.DateTime:

                        return DecodeDateTime(data);

                    case SqlDbType.SmallDateTime:

                        return DecodeSmallDateTime(data);

                    case SqlDbType.VarBinary:
                    case SqlDbType.Binary:

                        return "0x" + ToHexString(data);

                    case SqlDbType.UniqueIdentifier:

                        return BinaryToGuidString(data);

                    case SqlDbType.Decimal:

                        return DecodeDecimal(data, precision, scale).ToString();

                    case SqlDbType.Money:
                    case SqlDbType.SmallMoney:

                        return (BitConverter.ToInt64(data, 0) / 10000.0).ToString();

                    case SqlDbType.Real:

                        return BitConverter.ToSingle(data, 0).ToString();

                    case SqlDbType.Float:

                        return BitConverter.ToDouble(data, 0).ToString();

                    case SqlDbType.Variant:

                        return VariantBinaryToString(data);

                    case SqlDbType.Date:

                        return DecodeDate(data);

                    case SqlDbType.Time:

                        return DecodeTime(data, scale);

                    case SqlDbType.DateTime2:

                        return DecodeDateTime2(data, scale);

                    case SqlDbType.DateTimeOffset:

                        return DecodeDateTimeOffset(data, scale);

                    default:
                        return string.Format(CultureInfo.CurrentCulture,
                                             "not yet supported ({0:G})",
                                             sqlType);
                }
            }
            catch
            {
                return "Error converting data";
            }
        }

        /// <summary>
        /// Decodes DATETIMEOFFSET type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>
        /// String representing the value
        /// </returns>
        private static string DecodeDateTimeOffset(byte[] data, byte scale)
        {
            byte[] dateData = new byte[4];
            byte[] timeData = new byte[8];

            float scaleFactor = 1000F / (float)Math.Pow(10, scale);

            Array.Copy(data, timeData, data.Length - 5);
            Array.Copy(data, data.Length - 5, dateData, 0, 3);

            int datePart = BitConverter.ToInt32(dateData, 0);
            long timePart = BitConverter.ToInt64(timeData, 0);
            Int16 time = BitConverter.ToInt16(data, data.Length - 2);

            DateTime returnDate = new DateTime(0001, 01, 01);
            returnDate = returnDate.AddDays(datePart);
            returnDate = returnDate.AddMilliseconds(scaleFactor * timePart);

            DateTime offsetTime = new DateTime().AddMinutes(Math.Abs(time));

            string sign;

            if (time >= 0)
            {
                sign = "+";
            }
            else
            {
                sign = "-";
            }

            return string.Format("{0:yyyy-MM-dd HH:mm:ss.fffffff} {1}{2:HH:mm}", returnDate, sign, offsetTime);
        }

        /// <summary>
        /// Returns a string representation of a variant data type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static string VariantBinaryToString(byte[] data)
        {
            byte[] variantData;

            byte variantType = data[0];
            int offset = 2;
            byte precision = 0;
            byte scale = 0;

            switch (ToSqlType(variantType))
            {
                case SqlDbType.Decimal:

                    precision = data[2];
                    scale = data[3];
                    offset += 2;
                    break;

                case SqlDbType.Char:
                case SqlDbType.VarChar:
                case SqlDbType.NChar:
                case SqlDbType.NVarChar:

                    offset += 6;
                    break;

                case SqlDbType.VarBinary:
                case SqlDbType.Binary:

                    offset += 2;
                    break;


            }

            variantData = new byte[data.Length - offset];
            Array.Copy(data, offset, variantData, 0, variantData.Length);

            return BinaryToString(variantData, ToSqlType(variantType), precision, scale);
        }

        /// <summary>
        /// Decodes SMALLDATETIME data type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DecodeSmallDateTime(byte[] data)
        {
            DateTime returnDate = new DateTime(1900, 1, 1);

            int datePart;
            int timePart;

            timePart = BitConverter.ToUInt16(data, 0);
            datePart = BitConverter.ToUInt16(data, 2);

            returnDate = returnDate.AddDays(datePart).AddMinutes(timePart);

            return returnDate.ToString();
        }

        /// <summary>
        /// Decode DATETIME data type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string DecodeDateTime(byte[] data)
        {
            int timePart = BitConverter.ToInt32(data, 0);
            int datePart = BitConverter.ToInt32(data, 4);

            return DecodeDateTime(timePart, datePart);
        }

        /// <summary>
        /// Decodes DATETIME data type from 2 integers representing date and time
        /// </summary>
        /// <param name="timePart">The time part.</param>
        /// <param name="datePart">The date part.</param>
        /// <returns></returns>
        public static string DecodeDateTime(int timePart, int datePart)
        {
            DateTime returnDate = new DateTime(1900, 1, 1);

            returnDate = returnDate.AddDays(datePart).AddMilliseconds(3.333333 * timePart);

            return returnDate.ToString();
        }

        /// <summary>
        /// Decodes the DATETIME2 data type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        private static string DecodeDateTime2(byte[] data, int scale)
        {
            byte[] dateData = new byte[4];
            byte[] timeData = new byte[8];

            float scaleFactor = 1000F / (float)Math.Pow(10, scale);

            Array.Copy(data, timeData, data.Length - 3);
            Array.Copy(data, data.Length - 3, dateData, 0, 3);

            int datePart = BitConverter.ToInt32(dateData, 0);
            long timePart = BitConverter.ToInt64(timeData, 0);

            DateTime returnDate = new DateTime(0001, 01, 01);
            returnDate = returnDate.AddDays(datePart);
            returnDate = returnDate.AddMilliseconds(scaleFactor * timePart);

            return returnDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }

        /// <summary>
        /// Decodes the DATE data type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static string DecodeDate(byte[] data)
        {
            byte[] dateData = new byte[4];

            Array.Copy(data, dateData, 3);

            int date = BitConverter.ToInt32(dateData, 0);

            DateTime returnDate = new DateTime(0001, 01, 01);
            returnDate = returnDate.AddDays(date);

            return returnDate.ToShortDateString();
        }

        /// <summary>
        /// Decodes the TIME datatype
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        private static string DecodeTime(byte[] data, int scale)
        {
            byte[] timeData = new byte[8];

            float scaleFactor = 1000F / (float)Math.Pow(10, scale);

            Array.Copy(data, timeData, data.Length);

            long time = BitConverter.ToInt64(timeData, 0);

            DateTime returnDate = new DateTime();
            returnDate = returnDate.AddMilliseconds(scaleFactor * time);

            return returnDate.ToString("HH:mm:ss.fffffff");
        }

        /// <summary>
        /// Decodes the DECIMAL data type
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        private static SqlDecimal DecodeDecimal(byte[] data, byte precision, byte scale)
        {
            int index;
            bool positive = (1 == data[0]);

            int[] bits = new int[4];

            int length = data.Length >> 2;

            for (index = 0; index < length; index++)
            {
                bits[index] = BitConverter.ToInt32(data, 1 + (index * 4));
            }

            return new SqlDecimal(precision, scale, positive, bits);
        }

        public static List<string> DecodeDataString(string data)
        {
            List<string> decodedData = new List<string>();

            byte[] binaryData = new byte[data.Length / 2];

            for (int i = 0; i < binaryData.Length; i++)
            {
                binaryData[i] = byte.Parse(data.Substring(i * 2, 2),
                                           NumberStyles.AllowHexSpecifier,
                                           CultureInfo.InvariantCulture);
            }

            switch (binaryData.Length)
            {
                case 1:
                    decodedData.Add(DataString(binaryData, SqlDbType.TinyInt));
                    break;
                case 2:
                    decodedData.Add(DataString(binaryData, SqlDbType.SmallInt));
                    break;
                case 4:
                    decodedData.Add(DataString(binaryData, SqlDbType.Int));
                    break;
                case 8:
                    decodedData.Add(DataString(binaryData, SqlDbType.BigInt));
                    break;
                default:
                    break;
            }

            if (binaryData.Length == 1)
            {
                BitArray bitArray = new BitArray(binaryData);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < 8; i++)
                {
                    stringBuilder.Insert(0, bitArray[i] ? "1" : "0");
                }

                stringBuilder.Insert(0, "binary: ");

                decodedData.Add(stringBuilder.ToString());
            }

            string varcharData = DataString(binaryData, SqlDbType.VarChar);

            if (!string.IsNullOrEmpty(varcharData))
            {
                decodedData.Add(DataString(binaryData, SqlDbType.VarChar));
            }

            return decodedData;
        }

        private static string DataString(byte[] data, SqlDbType sqlType)
        {
            StringBuilder stringBuilder = new StringBuilder(sqlType.ToString().ToLower(CultureInfo.CurrentCulture));

            stringBuilder.Append(": ");
            try
            {
                stringBuilder.Append(BinaryToString(data, sqlType, 0, 0));
            }
            catch
            {
                stringBuilder.Append("(Error)");
            }

            return stringBuilder.ToString();
        }

        internal static SqlDbType ToSqlType(byte value)
        {
            switch (value)
            {
                case 34:
                    return SqlDbType.Image;
                case 35:
                    return SqlDbType.Text;
                case 36:
                    return SqlDbType.UniqueIdentifier;
                case 48:
                    return SqlDbType.TinyInt;
                case 52:
                    return SqlDbType.SmallInt;
                case 56:
                    return SqlDbType.Int;
                case 58:
                    return SqlDbType.SmallDateTime;
                case 59:
                    return SqlDbType.Real;
                case 60:
                    return SqlDbType.Money;
                case 61:
                    return SqlDbType.DateTime;
                case 62:
                    return SqlDbType.Float;
                case 98:
                    return SqlDbType.Variant;
                case 99:
                    return SqlDbType.NText;
                case 104:
                    return SqlDbType.Bit;
                case 106:
                    return SqlDbType.Decimal;
                case 108:
                    return SqlDbType.Decimal;
                case 122:
                    return SqlDbType.SmallMoney;
                case 127:
                    return SqlDbType.BigInt;
                case 165:
                    return SqlDbType.VarBinary;
                case 167:
                    return SqlDbType.VarChar;
                case 173:
                    return SqlDbType.Binary;
                case 175:
                    return SqlDbType.Char;
                case 189:
                    return SqlDbType.Timestamp;
                case 231:
                    return SqlDbType.NVarChar;
                case 239:
                    return SqlDbType.NChar;
                case 241:
                    return SqlDbType.Xml;

                //New 2008 Types
                case 40:
                    return SqlDbType.Date;
                case 41:
                    return SqlDbType.Time;
                case 42:
                    return SqlDbType.DateTime2;
                case 43:
                    return SqlDbType.DateTimeOffset;

                default:
                    return SqlDbType.Variant;
            }
        }

        public static string EncodeInt32(int value)
        {
            return BitConverter.ToString(BitConverter.GetBytes(value)).Replace("-", " ");
        }

        public static string EncodeInt16(Int16 value)
        {
            return BitConverter.ToString(BitConverter.GetBytes(value)).Replace("-", " ");
        }

        public static string EncodeInt64(long value)
        {
            return BitConverter.ToString(BitConverter.GetBytes(value)).Replace("-", " ");
        }

        public static string[] EncodeDateTime(DateTime value)
        {
            int timePart = (int)((value - value.Date).TotalMilliseconds / 3.333333);
            int datePart = (value - new DateTime(1900, 1, 1)).Days;

            return new string[] { EncodeInt32(timePart), EncodeInt32(datePart) };
        }

        public static string[] EncodeSmallDateTime(DateTime value)
        {

            UInt16 timePart = (UInt16)((value - value.Date).TotalMinutes);
            UInt16 datePart = (UInt16)(value - new DateTime(1900, 1, 1)).Days;

            return new string[] { EncodeUInt16(timePart), EncodeUInt16(datePart) };
        }

        public static string EncodeUInt16(UInt16 value)
        {
            return BitConverter.ToString(BitConverter.GetBytes(value)).Replace("-", " ");
        }

        public static string EncodeReal(Single value)
        {
            return BitConverter.ToString(BitConverter.GetBytes(value)).Replace("-", " ");
        }

        public static string EncodeFloat(double value)
        {
            return BitConverter.ToString(BitConverter.GetBytes(value)).Replace("-", " ");
        }

        public static string EncodeMoney(decimal value)
        {
            return EncodeInt64((long)(value * 10000)).ToString();
        }

        public static string EncodeSmallMoney(decimal value)
        {
            return EncodeInt32((int)(value * 10000)).ToString();
        }

        public static string EncodeDecimal(decimal value)
        {
            SqlDecimal sqlValue = new SqlDecimal(value);
            //sqlValue.Precision = precision;
            //sqlValue.Scale = scale;

            return BitConverter.ToString(sqlValue.BinData).Replace("-", " ");
        }
    }
}
