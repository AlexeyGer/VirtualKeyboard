using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyboardControl.Enums;
using KeyboardControl.Metadata;
using KeyboardControl.Utils;

namespace KeyboardControl.KeyLists
{
	class CharPadKeyList
	{
		public List<Key> charPad = new List<Key>();
		//public List<UIElement> charPadKeys = new List<UIElement>();


		string enumKeyName;
		VirtualKeyCode keyCodeValue;
		public int rowPosition;
		double widthCoefficient = 1;

		public List<Key> GetCharPadKeyList()
		{
			foreach (CharPadArrange i in Enum.GetValues(typeof(CharPadArrange)))
			{
				if ((int)i <= (int)CharPadArrange.BACK)
				{
					rowPosition = 0;
				}
				else if ((int)i <= (int)CharPadArrange.RETURN)
				{
					rowPosition = 1;
				}
				else if ((int)i <= (int)CharPadArrange.OEM_2)
				{
					rowPosition = 2;
				}
				else if ((int)i <= (int)CharPadArrange.RIGHT)
				{
					rowPosition = 3;
				}

				enumKeyName = Enum.GetName(typeof(CharPadArrange), i);
				keyCodeValue = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), enumKeyName);

				if ((int)i == (int)CharPadArrange.BACK)
				{
					widthCoefficient = 2;
				}

				if ((int)i == (int)CharPadArrange.RETURN)
				{
					widthCoefficient = 3;
				}

				if ((int)i == (int)CharPadArrange.SPACE)
				{
					widthCoefficient = 6;
				}

				if ((int)i == (int)CharPadArrange.BACK)
				{
					widthCoefficient = 2;
				}

				charPad.Add(new Key(ToUnicodeConverter.GetKeyUIName(keyCodeValue), keyCodeValue, rowPosition, widthCoefficient));
				widthCoefficient = 1;


			}

			return charPad;
		}


	}
}
