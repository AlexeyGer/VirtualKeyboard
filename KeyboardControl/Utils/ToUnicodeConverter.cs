using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyboardControl.PInvoke;
using KeyboardControl.Enums;

namespace KeyboardControl.Utils
{
	public static class ToUnicodeConverter
	{
		public static string GetKeyUIName(VirtualKeyCode vkcode)
		{
			uint wVirtKey = (uint)vkcode;
			uint wScanCode = 0;
			byte[] lpKeyState = new byte[255];
			StringBuilder pwszBuff = new StringBuilder();
			int cchBuff = 2;
			uint wFlags = 0;
			IntPtr dwhkl = PInvokeMethods.GetKeyboardLayout(0);

			PInvokeMethods.GetKeyboardState(lpKeyState);

			PInvokeMethods.ToUnicodeEx(wVirtKey, wScanCode, lpKeyState, pwszBuff, cchBuff, wFlags, dwhkl);

			return pwszBuff.ToString();
		}

	}
}
