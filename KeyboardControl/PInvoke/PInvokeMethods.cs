using System;
using System.Runtime.InteropServices;
using System.Text;
using KeyboardControl.Structs;

namespace KeyboardControl.PInvoke
{
    internal static class PInvokeMethods
    {
		[DllImport("user32.dll", SetLastError = true)]
		public static extern Int16 GetAsyncKeyState(UInt16 virtualKeyCode);

		//[DllImport("user32.dll", SetLastError = true)]
		//public static extern Int16 GetKeyState(UInt16 virtualKeyCode);

		[DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 SendInput(
            UInt32 numberOfInputs, 
            INPUT[] inputs, 
            Int32 sizeOfInputStructure);

        //[DllImport("user32.dll")]
        //public static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        public static extern int ToUnicodeEx(
            uint wVirtKey, 
            uint wScanCode, 
            byte[] lpKeyState, 
            /*[Out, MarshalAs(UnmanagedType.LPWStr)]*/ StringBuilder pwszBuff,
            int cchBuff, 
            uint wFlags, 
            IntPtr dwhkl);

        [DllImport("user32.dll")]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint idThread);
    }
}