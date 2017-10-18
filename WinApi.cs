using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class WinApi
    {
        // Hace que una ventana sea hija (o esté contenida) en otra
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        // Devuelve el Handle (hWnd) de una ventana de la que sabemos el título
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        // Cambia el tamaño y la posición de una ventana
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int MoveWindow(IntPtr hWnd, int x, int y,
                int nWidth, int nHeight, int bRepaint);
        // Activa una ventana
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int SetForegroundWindow(IntPtr hWnd);
        //Set Impresora Predeterminada
        [System.Runtime.InteropServices.DllImport("winspool.drv", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
        //Get Impresora Predeterminada
        [System.Runtime.InteropServices.DllImport("winspool.drv", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int size);
    }

