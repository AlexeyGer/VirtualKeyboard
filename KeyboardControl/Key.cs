using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using KeyboardControl.Enums;

namespace KeyboardControl
{
	public class Key
	{
		private string _diplayName;
		private VirtualKeyCode _vkcode;
		private int _width = 50;
		private int _height = 50;
		private int _proportion;

		public string DiplayName
		{
			get
			{
				return _diplayName;
			}
			set
			{
				_diplayName = value;
			}
		}

		public VirtualKeyCode VKCode
		{
			get
			{
				return _vkcode;
			}
			set
			{
				_vkcode = value;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}


		public int Proportion
		{
			get
			{
				return _proportion;
			}
			set
			{
				_proportion = value;
			}
		}

		public Key(VirtualKeyCode vkcode, int proportion = 1)
		{
			DiplayName = Convert.ToChar(vkcode).ToString();
			VKCode = vkcode;
			Proportion = proportion;
			//Width = 50;
			//Height = 50;
		}

		public Key(string name, VirtualKeyCode vkcode, int proportion = 1)
		{
			DiplayName = name;
			VKCode = vkcode;
			Proportion = proportion;
			//Width = 50;
			//Height = 50;
		}
	}
}
