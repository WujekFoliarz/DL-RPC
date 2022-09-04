using System;
using DiscordRPC;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace DL_RPC
{
    public class functions
    {
        [DllImport("Kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        public static bool isGameOpen()
        {
            Process[] processes = Process.GetProcessesByName("DyingLightGame");
            if (processes.Length == 0) { return false; }
            else { return true; }
        }

        public static void waitfordl()
        {
            Console.WriteLine("Waiting for DyingLightGame.exe");
            while (!isGameOpen()){
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }

        public static void hide()
        {
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0);//hide
            }
        }

        public static void findDuplicate()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                Environment.Exit(0);
            }
        }
    }
}
