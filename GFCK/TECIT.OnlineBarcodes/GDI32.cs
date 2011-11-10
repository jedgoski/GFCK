using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;

namespace TECIT.OnlineBarcodes
{
    public static class GDI32
    {

        #region Enums

        internal enum MWT
        {
            IDENTITY = 1,
            LEFTMULTIPLY = 2,
            RIGHTMULTIPLY = 3,
            MIN = 1,
            MAX = 3,
        }

        internal enum GM
        {
            COMPATIBLE = 1,
            ADVANCED = 2
        }

        #endregion Enums


        #region Imports

        [DllImport("gdi32.dll")]
        public static extern int SetGraphicsMode(IntPtr hdc, int iMode);

        [DllImport("gdi32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern bool ModifyWorldTransform(
            IntPtr hdc,
            [In] ref XFORM xf,
            uint mode
        );

        [DllImport("gdi32.dll")]
        public static extern
        bool RestoreDC(
            IntPtr hdc,
            int nSavedDC
        );

        [DllImport("gdi32.dll")]
        public static extern
        int SaveDC(
            IntPtr hdc
        );

        #endregion Imports



        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        public struct XFORM
        {
            public float eM11;
            public float eM12;
            public float eM21;
            public float eM22;
            public float eDx;
            public float eDy;


        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        #endregion Structs
    }
}
