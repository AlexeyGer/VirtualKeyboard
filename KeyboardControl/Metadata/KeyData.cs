using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KeyboardControl.Enums;

namespace KeyboardControl.Metadata
{
	public class KeyData : INotifyPropertyChanged
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
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
				NotifyPropertyChanged();
			}
		}

		public KeyData(string name, VirtualKeyCode vkcode, int rowPosition, double widthCoefficient = 1)
		{
			UIName = name;
			VKCode = vkcode;
			RowPosition = rowPosition;
			WidthCoefficient = widthCoefficient;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
