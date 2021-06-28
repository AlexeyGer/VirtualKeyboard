using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardControl.Enums
{
	public enum CharPadArrange
	{
		// Row 0

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '`~' key 
		/// </summary>
		OEM_3 = 0xC0,

		/// <summary>
		/// Q key
		/// </summary>
		VK_Q = 0x51,

		/// <summary>
		/// W key
		/// </summary>
		VK_W = 0x57,

		/// <summary>
		/// E key
		/// </summary>
		VK_E = 0x45,

		/// <summary>
		/// R key
		/// </summary>
		VK_R = 0x52,

		/// <summary>
		/// T key
		/// </summary>
		VK_T = 0x54,

		/// <summary>
		/// Y key
		/// </summary>
		VK_Y = 0x59,

		/// <summary>
		/// U key
		/// </summary>
		VK_U = 0x55,

		/// <summary>
		/// I key
		/// </summary>
		VK_I = 0x49,

		/// <summary>
		/// O key
		/// </summary>
		VK_O = 0x4F,

		/// <summary>
		/// P key
		/// </summary>
		VK_P = 0x50,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '[{' key
		/// </summary>
		OEM_4 = 0xDB,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the ']}' key
		/// </summary>
		OEM_6 = 0xDD,

		/// <summary>
		/// BACKSPACE key
		/// </summary>
		BACK = 0x08,


		// Row 1

		/// <summary>
		/// TAB key
		/// </summary>
		TAB = 0x09,

		/// <summary>
		/// A key
		/// </summary>
		VK_A = 0x41,

		/// <summary>
		/// S key
		/// </summary>
		VK_S = 0x53,

		/// <summary>
		/// D key
		/// </summary>
		VK_D = 0x44,

		/// <summary>
		/// F key
		/// </summary>
		VK_F = 0x46,

		/// <summary>
		/// G key
		/// </summary>
		VK_G = 0x47,

		/// <summary>
		/// H key
		/// </summary>
		VK_H = 0x48,

		/// <summary>
		/// J key
		/// </summary>
		VK_J = 0x4A,

		/// <summary>
		/// K key
		/// </summary>
		VK_K = 0x4B,

		/// <summary>
		/// L key
		/// </summary>
		VK_L = 0x4C,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the ';:' key 
		/// </summary>
		OEM_1 = 0xBA,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the 'single-quote/double-quote' key
		/// </summary>
		OEM_7 = 0xDE,

		/// <summary>
		/// ENTER key
		/// </summary>
		RETURN = 0x0D,


		// Row 2

		/// <summary>
		/// Left SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
		/// </summary>
		LSHIFT = 0xA0,

		/// <summary>
		/// Z key
		/// </summary>
		VK_Z = 0x5A,

		/// <summary>
		/// X key
		/// </summary>
		VK_X = 0x58,

		/// <summary>
		/// C key
		/// </summary>
		VK_C = 0x43,

		/// <summary>
		/// V key
		/// </summary>
		VK_V = 0x56,

		/// <summary>
		/// B key
		/// </summary>
		VK_B = 0x42,

		/// <summary>
		/// N key
		/// </summary>
		VK_N = 0x4E,

		/// <summary>
		/// M key
		/// </summary>
		VK_M = 0x4D,

		/// <summary>
		/// Windows 2000/XP: For any country/region, the ',' key
		/// </summary>
		OEM_COMMA = 0xBC,

		/// <summary>
		/// Windows 2000/XP: For any country/region, the '.' key
		/// </summary>
		OEM_PERIOD = 0xBE,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '/?' key 
		/// </summary>
		OEM_2 = 0xBF,


		// Row 3

		//"@123"

		/// <summary>
		/// SPACEBAR
		/// </summary>
		SPACE = 0x20,

		/// <summary>
		/// LEFT ARROW key
		/// </summary>
		LEFT = 0x25,

		/// <summary>
		/// RIGHT ARROW key
		/// </summary>
		RIGHT = 0x27,

		//"LangSelector"
	}
}
