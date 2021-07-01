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

		//public NumPadKeyList()
		//{
		//	numPad.Add(new Key("7", VirtualKeyCode.NUMPAD7));
		//	numPad.Add(new Key("8", VirtualKeyCode.NUMPAD8));
		//	numPad.Add(new Key("9", VirtualKeyCode.NUMPAD9));
		//	numPad.Add(new Key("4", VirtualKeyCode.NUMPAD4));
		//	numPad.Add(new Key("5", VirtualKeyCode.NUMPAD5));
		//	numPad.Add(new Key("6", VirtualKeyCode.NUMPAD6));
		//	numPad.Add(new Key("1", VirtualKeyCode.NUMPAD1));
		//	numPad.Add(new Key("2", VirtualKeyCode.NUMPAD2));
		//	numPad.Add(new Key("3", VirtualKeyCode.NUMPAD3));
		//	numPad.Add(new Key("0", VirtualKeyCode.NUMPAD0, 2));
		//	numPad.Add(new Key(".", VirtualKeyCode.DECIMAL));
		//	numPad.Add(new Key("", VirtualKeyCode.DECIMAL));
		//}
	}
}
