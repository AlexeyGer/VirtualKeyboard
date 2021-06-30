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
		OEM_3,

		/// <summary>
		/// Q key
		/// </summary>
		VK_Q,

		/// <summary>
		/// W key
		/// </summary>
		VK_W,

		/// <summary>
		/// E key
		/// </summary>
		VK_E,

		/// <summary>
		/// R key
		/// </summary>
		VK_R,

		/// <summary>
		/// T key
		/// </summary>
		VK_T,

		/// <summary>
		/// Y key
		/// </summary>
		VK_Y,

		/// <summary>
		/// U key
		/// </summary>
		VK_U,

		/// <summary>
		/// I key
		/// </summary>
		VK_I,

		/// <summary>
		/// O key
		/// </summary>
		VK_O,

		/// <summary>
		/// P key
		/// </summary>
		VK_P,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '[{' key
		/// </summary>
		OEM_4,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the ']}' key
		/// </summary>
		OEM_6,

		/// <summary>
		/// BACKSPACE key
		/// </summary>
		BACK,


		// Row 1

		/// <summary>
		/// TAB key
		/// </summary>
		TAB,

		/// <summary>
		/// A key
		/// </summary>
		VK_A,

		/// <summary>
		/// S key
		/// </summary>
		VK_S,

		/// <summary>
		/// D key
		/// </summary>
		VK_D,

		/// <summary>
		/// F key
		/// </summary>
		VK_F,

		/// <summary>
		/// G key
		/// </summary>
		VK_G,

		/// <summary>
		/// H key
		/// </summary>
		VK_H,

		/// <summary>
		/// J key
		/// </summary>
		VK_J,

		/// <summary>
		/// K key
		/// </summary>
		VK_K,

		/// <summary>
		/// L key
		/// </summary>
		VK_L,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the ';:' key 
		/// </summary>
		OEM_1,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the 'single-quote/double-quote' key
		/// </summary>
		OEM_7,

		/// <summary>
		/// ENTER key
		/// </summary>
		RETURN,


		// Row 2

		/// <summary>
		/// Left SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
		/// </summary>
		LSHIFT,

		/// <summary>
		/// Z key
		/// </summary>
		VK_Z,

		/// <summary>
		/// X key
		/// </summary>
		VK_X,

		/// <summary>
		/// C key
		/// </summary>
		VK_C,

		/// <summary>
		/// V key
		/// </summary>
		VK_V,

		/// <summary>
		/// B key
		/// </summary>
		VK_B,

		/// <summary>
		/// N key
		/// </summary>
		VK_N,

		/// <summary>
		/// M key
		/// </summary>
		VK_M,

		/// <summary>
		/// Windows 2000/XP: For any country/region, the ',' key
		/// </summary>
		OEM_COMMA,

		/// <summary>
		/// Windows 2000/XP: For any country/region, the '.' key
		/// </summary>
		OEM_PERIOD,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '/?' key 
		/// </summary>
		OEM_2,


		// Row 3

		SYMB, //"@123"

		/// <summary>
		/// SPACEBAR
		/// </summary>
		SPACE,

		/// <summary>
		/// LEFT ARROW key
		/// </summary>
		LEFT,

		/// <summary>
		/// RIGHT ARROW key
		/// </summary>
		RIGHT,

		//"LangSelector"
	}
}
