using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TDXGrobal;

namespace HomeworkTest
{
    public partial class Form1 : Form
    {
        DataReader.Reader a;

        public Form1()
        {
            InitializeComponent();
            a = new DataReader.Reader(this.Handle, "600158", "中体产业");
            a.GetKDays();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == TDXGrobal.Define.WM_TDX_DEPACKDATA - 1)
            {
                if (4 == m.WParam.ToInt32())
                {
                }
            }
            if (m.Msg == TDXGrobal.Define.WM_TDX_DEPACKDATA)
            {
                System.Console.WriteLine("aaa");
                if (m.WParam.ToInt32() == TDXGrobal.Define.TDX_MSG_INITDATA)
                {
                    TDXGrobal.Define.TTdxDllShareData data = new TDXGrobal.Define.TTdxDllShareData();
                    data = (TDXGrobal.Define.TTdxDllShareData)m.GetLParam(data.GetType());
                }
                else if (m.WParam.ToInt32() == TDXGrobal.Define.TDX_MSG_GETPK)
                {
                    Define.TTdxDllShareData data = new Define.TTdxDllShareData();
                    data = (Define.TTdxDllShareData)m.GetLParam(data.GetType());
                    GCHandle handle = GCHandle.Alloc(data.buf, GCHandleType.Pinned);

                    Define.TTDX_DAYInfo stuff = (Define.TTDX_DAYInfo)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
                        typeof(Define.TTDX_DAYInfo));
                    handle.Free();
                }
                else if (m.WParam.ToInt32() == TDXGrobal.Define.TDX_MSG_TESTREALPK)
                {
                    Define.TTdxDllShareData data = new Define.TTdxDllShareData();
                    data = (Define.TTdxDllShareData)m.GetLParam(data.GetType());
                    GCHandle handle = GCHandle.Alloc(data.buf, GCHandleType.Pinned);

                    Define.TTDX_REALPKDAT stuff = (Define.TTDX_REALPKDAT)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
                        typeof(Define.TTDX_REALPKDAT));
                    handle.Free();
                    a.GetTestRealPK();
                }
                else if (m.WParam.ToInt32() == TDXGrobal.Define.TDX_MSG_GET_K_DAY)
                {
                    Define.TTdxDllShareData data = new Define.TTdxDllShareData();
                    data = (Define.TTdxDllShareData)m.GetLParam(data.GetType());
                    GCHandle handle = GCHandle.Alloc(data.buf, GCHandleType.Pinned);

                    Define.TTDX_DAYInfo stuff = (Define.TTDX_DAYInfo)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
                        typeof(Define.TTDX_DAYInfo));
                    handle.Free();
                }

            }
            base.WndProc(ref m);
        }
    }
}
