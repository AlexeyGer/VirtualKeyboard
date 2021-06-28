using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using KeyboardControl.Enums;

namespace KeyboardControl.Metadata
{
	public class Key : INotifyPropertyChanged
	{
		private string _UIName;
		private VirtualKeyCode _vkcode;
		private int _rowPosition;
		private int _width = 50;
		private int _height = 50;
		private double _margin = 5;
		private double _widthCoefficient;

		public string UIName
		{
			get
			{
				return _UIName;
			}
			set
			{
				_UIName = value;
				OnPropertyChanged(nameof(_UIName));
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

		public int RowPosition
		{
			get
			{
				return _rowPosition;
			}
			set
			{
				_rowPosition = value;
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

		public double Margin
		{
			get
			{
				return _margin;
			}
			set
			{
				_margin = value;
				OnPropertyChanged(nameof(_margin));
			}
		}

		public double WidthCoefficient
		{
			get
			{
				return _widthCoefficient;
			}
			set
			{
				_widthCoefficient = value;
				OnPropertyChanged(nameof(_widthCoefficient));
			}
		}

		//public Key(VirtualKeyCode vkcode, int widthCoefficient = 1)
		//{
		//	UIName = Convert.ToChar(vkcode).ToString();
		//	VKCode = vkcode;
		//	WidthCoefficient = widthCoefficient;
		//}

		public Key(string name, VirtualKeyCode vkcode, int rowPosition, double widthCoefficient = 1)
		{
			UIName = name;
			VKCode = vkcode;
			RowPosition = rowPosition;
			WidthCoefficient = widthCoefficient;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
