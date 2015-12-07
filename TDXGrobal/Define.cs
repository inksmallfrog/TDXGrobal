using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TDXGrobal
{
    public class Define
    {
        public const int MARKET_SZ = 0;
        public const int MARKET_SH = 1;

        public const int MARKETS_COUNT = 2;

        public const string[] FMarketNames = null;
        public const string[] FMarketCodes = null;

        public const int WM_USER = 0x0400;
        public const int WM_TDX_DEPACKDATA = WM_USER + 0x0111;

        public const int TDX_MSG_TESTREALPK = 0x0526;
        public const int TDX_MSG_GETPK = 0x053e;
        public const int TDX_MSG_GET_K_DAY = 0x052c;
        public const int TDX_MSG_GET_MINS = 0x051d;
        public const int TDX_MSG_GET_DEALS = 0x0fc5;
        public const int TDX_MSG_INITDATA = 0x0450;

        public struct TTDX_STOCKINFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            byte[] code;
            ushort rate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            byte[] Name;
            ushort W1;
            ushort W2;
            byte PriceMag;
            float YClose;
            ushort W3;
            ushort W4;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_PK_ADD
        {
            byte tmp9E;
            float tmp9F;
            float tmpA3;
            float tmpA7;
            float tmpAB;
            ushort tmpAF;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_PKBASE
        {
            byte MarketMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            byte[] code;
            byte tmp7;
            ushort DealCount;
            ushort tmpA;
            float YClose;
            float Open;
            float High;
            float Low;
            float Close;
            uint LastDealTime;
            float tmp24;
            uint Volume;
            uint LastVolume;
            float Amount;
            uint Inside;
            uint OutSide;
            float tmp3C;
            float tmp40;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            float[] Buyp;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            uint[] Buyv;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            float[] Sellp;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            uint[] Sellv;
            ushort tmp94;
            uint tmp96;
            uint tmp9A;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_PKDAT
        {
            TTDX_PKBASE D;
            TTDX_PK_ADD DEx;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_REALPK_ADD
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            uint[] tmp9E;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            uint[] tmpB2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            float[] tmpC6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            uint[] tmpDA;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_REALPKDAT
        {
            TTDX_PKBASE PK;
            TTDX_REALPK_ADD DatEx;
            float tmpEE;
            float tmpF2;
            uint tmpF6;
            uint tmpFA;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_DAYInfo
        {
            uint DAY;
            float Open;
            float High;
            float Low;
            float Close;
            float Amount;
            uint Volume;
            ushort UpCount;
            ushort DownCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTDX_DEALInfo
        {
            ushort Min;
            uint value;
            uint Volume;
            int DealCount;
            ushort SellOrBuy;
        }

        public struct TTDX_MIN
        {
            ushort Min;
            float Close;
            float Arg;
            int Volume;
            uint tmpE;
            uint tmp12;
            float tmp16;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TCallBackStockInfo
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            byte[] Code;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            byte[] Name;
            ushort Market;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct TTdxDllShareData
        {
            TCallBackStockInfo stockinfo;
            int start;
            int count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65536)]
            public byte[] buf;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TWM_TDX_DEPACKDATA
        {
            uint Msg;
            int TDX_MSG;
            TTdxDllShareData Data;
            int Result;
        }

        public struct TTdxDataHeader
        {
            uint CheckSum;
            byte EncodeMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            byte[] tmp;
            ushort MsgID;
            ushort Size;
            ushort DePackSize;
        }

        public struct TTdxSendHeader
        {
            byte CheckSum;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            byte[] tmp;
            ushort Size;
            ushort Size2;
        }

        public struct TTdxData
        {
            ushort Len;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 70000)]
            byte[] buf;
        }

        public struct TTdxDepackData
        {
            TTdxDataHeader Head;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256 * 256 - 1)]
            byte[] buf;
        }
    }
}
