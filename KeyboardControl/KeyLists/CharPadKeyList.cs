using System;
using System.Collections.Generic;
using KeyboardControl.Enums;
using KeyboardControl.Metadata;
using KeyboardControl.Utils;

namespace KeyboardControl.KeyLists
{
	class CharPadKeyList
	{
		public List<KeyData> charPad = new List<KeyData>();

		string enumKeyName;
		VirtualKeyCode keyCodeValue;
		public int rowPosition;


		public List<KeyData> GetCharPadKeyList()
		{
			foreach (CharPadArrange i in Enum.GetValues(typeof(CharPadArrange)))
			{
				double widthCoefficient = 1;

				if ((int)i <= (int)CharPadArrange.BACK)
				{
					rowPosition = 0;
				}
				else if ((int)i <= (int)CharPadArrange.RETURN)
				{
					rowPosition = 1;
				}
				else if ((int)i <= (int)CharPadArrange.EN)
				{
					rowPosition = 2;
				}
				else if ((int)i <= (int)CharPadArrange.RIGHT)
				{
					rowPosition = 3;
				}

				enumKeyName = Enum.GetName(typeof(CharPadArrange), i);
				keyCodeValue = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), enumKeyName);
				string name = ToUnicodeConverter.GetKeyUIName(keyCodeValue);

				switch (i)
				{
					case CharPadArrange.BACK:
						widthCoefficient = 3;
						name = "BS";
						break;
					case CharPadArrange.TAB:
						name = "TAB";
						break;
					case CharPadArrange.RETURN:
						widthCoefficient = 3;
						name = "ENTER";
						break;
					case CharPadArrange.LSHIFT:
						name = "SHIFT";
						break;
					case CharPadArrange.EN:
						widthCoefficient = 2;
						name = "EN";
						break;
					case CharPadArrange.SYMB:
						name = "@123";
						break;
					case CharPadArrange.SPACE:
						widthCoefficient = 10;
						break;
					case CharPadArrange.LEFT:
						widthCoefficient = 2;
						name = "<";
						break;
					case CharPadArrange.RIGHT:
						widthCoefficient = 2;
						name = ">";
						break;
				}

				charPad.Add(new KeyData(name, keyCodeValue, rowPosition, widthCoefficient));
			}

			return charPad;
		}
	}
}
