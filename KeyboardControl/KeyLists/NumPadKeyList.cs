using System;
using System.Collections.Generic;
using KeyboardControl.Enums;
using KeyboardControl.Metadata;
using KeyboardControl.Utils;

namespace KeyboardControl.KeyLists
{
	public class NumPadKeyList
	{
		public List<KeyData> numPad = new List<KeyData>();

		string enumKeyName;
		VirtualKeyCode keyCodeValue;
		public int rowPosition;
		double widthCoefficient = 1;

		public List<KeyData> GetNumPadKeyList()
		{
			foreach (NumPadArrange i in Enum.GetValues(typeof(NumPadArrange)))
			{
				if ((int)i <= (int)NumPadArrange.NUMPAD9)
				{
					rowPosition = 0;
				}
				else if ((int)i <= (int)NumPadArrange.NUMPAD6)
				{
					rowPosition = 1;
				}
				else if ((int)i <= (int)NumPadArrange.NUMPAD3)
				{
					rowPosition = 2;
				}
				else if ((int)i <= (int)NumPadArrange.DECIMAL)
				{
					rowPosition = 3;
				}

				enumKeyName = Enum.GetName(typeof(NumPadArrange), i);
				keyCodeValue = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), enumKeyName);

				if ((int)i == (int)NumPadArrange.NUMPAD0)
				{
					widthCoefficient = 2;
				}

				numPad.Add(new KeyData(ToUnicodeConverter.GetKeyUIName(keyCodeValue), keyCodeValue, rowPosition, widthCoefficient));
				widthCoefficient = 1;
			}

			return numPad;
		}
	}
}
