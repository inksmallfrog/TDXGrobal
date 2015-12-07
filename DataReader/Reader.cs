using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DataReader
{
    public class Reader
    {
        uint connection;
        string stkCode;
        string stkName;

        public Reader(IntPtr Handle, string _stkCode, string _stkName)
        {
            connection = R_Open(Handle, null);
            stkCode = _stkCode;
            stkName = _stkName;
            Connect();
        }

        ~Reader(){
            R_Close(connection);
        }

        private void Connect()
        {
            if (!R_Connect(connection, "218.18.103.38", 7709))
            {
                Console.WriteLine("连接失败！");
                Connect();
            }
        }

        public void GetTestRealPK()
        {
            R_GetTestRealPK(connection, stkCode, stkName, 10);
        }

        public void GetKDays()
        {
            R_GetKDays(connection, stkCode, 1, 0, 2000);
        }


        [DllImport("RSRStock.dll", EntryPoint = "R_Open", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern uint R_Open(IntPtr Handle, string RegKey);

        [DllImport("RSRStock.dll", EntryPoint = "R_Close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_Close(uint TDXManager);

        [DllImport("RSRStock.dll", EntryPoint = "R_Connect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern bool R_Connect(uint TDXManager, string ServerAddr, int port);

        [DllImport("RSRStock.dll", EntryPoint = "R_DisConnect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_DisConnect(uint TDXManager);

        [DllImport("RSRStock.dll", EntryPoint = "R_InitMarketData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_InitMarketData(uint TDXManager, int Market);

        [DllImport("RSRStock.dll", EntryPoint = "R_GetPK", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_GetPK(uint TDXManager, string StkCode, string StkName);

        [DllImport("RSRStock.dll", EntryPoint = "R_GetTestRealPK", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_GetTestRealPK(uint TDXManager, string StkCode, string StkName, int Time);

         [DllImport("RSRStock.dll", EntryPoint = "R_GetKDays", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_GetKDays(uint TDXManager, string StkCode, int market, int startcount, int count);

         [DllImport("RSRStock.dll", EntryPoint = "R_GetDeals", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_GetDeals(uint TDXManager, string StkCode, int market, int startcount, int count);

         [DllImport("RSRStock.dll", EntryPoint = "R_GetMins", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void R_GetMins(uint TDXManager, string StkCode, int market, int start);

         [DllImport("RSRStock.dll", EntryPoint = "R_GetMarket", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
         static extern int R_GetMarket(string StkCode, string StkName);
    }
}
