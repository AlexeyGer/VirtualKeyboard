using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyboardControl.Enums;

namespace KeyboardControl.KeyLists
{
	public class NumPadKeyList
	{
		public List<Key> numPad = new List<Key>();

		public NumPadKeyList()
		{
			numPad.Add(new Key("7", VirtualKeyCode.NUMPAD7));
			numPad.Add(new Key("8", VirtualKeyCode.NUMPAD8));
			numPad.Add(new Key("9", VirtualKeyCode.NUMPAD9));
			numPad.Add(new Key("4", VirtualKeyCode.NUMPAD4));
			numPad.Add(new Key("5", VirtualKeyCode.NUMPAD5));
			numPad.Add(new Key("6", VirtualKeyCode.NUMPAD6));
			numPad.Add(new Key("1", VirtualKeyCode.NUMPAD1));
			numPad.Add(new Key("2", VirtualKeyCode.NUMPAD2));
			numPad.Add(new Key("3", VirtualKeyCode.NUMPAD3));
			numPad.Add(new Key("0", VirtualKeyCode.NUMPAD0, 2));
			numPad.Add(new Key(".", VirtualKeyCode.DECIMAL));
			numPad.Add(new Key("", VirtualKeyCode.DECIMAL));
		}
	}
}
