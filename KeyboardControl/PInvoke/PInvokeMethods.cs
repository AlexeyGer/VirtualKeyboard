using System;
using System.Runtime.InteropServices;
using KeyboardControl.Structs;

namespace KeyboardControl.PInvoke
{
    internal static class PInvokeMethods
    {
        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern Int16 GetAsyncKeyState(UInt16 virtualKeyCode);

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern Int16 GetKeyState(UInt16 virtualKeyCode);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] inputs, Int32 sizeOfInputStructure);

        //[DllImport("user32.dll")]
        //public static extern IntPtr GetMessageExtraInfo();
    }
}