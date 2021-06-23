
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using KeyboardControl.KeyLists;
using KeyboardControl.Enums;
using KeyboardControl.Structs;
using KeyboardControl.PInvoke;
using System.Runtime.InteropServices;
using System;

namespace KeyboardControl
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:KeyboardControl"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:KeyboardControl;assembly=KeyboardControl"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:CustomControl1/>
	///
	/// </summary>
	public class Keyboard : Control
	{
		private NumPadKeyList _numPad = new NumPadKeyList(); // пока не юзается
		public Grid BackendGrid = new Grid();

		public List<Key> NumPad => _numPad.numPad; // пока не юзается

		static Keyboard()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Keyboard), new FrameworkPropertyMetadata(typeof(Keyboard)));
			
		}

		public Keyboard()
		{

		}

		public override void OnApplyTemplate()
		{
			BackendGrid = GetTemplateChild("NumPadGrid") as Grid;
			GridGenerate();
		}

		public void GridGenerate()
		{
			BackendGrid.HorizontalAlignment = HorizontalAlignment.Center;
			BackendGrid.VerticalAlignment = VerticalAlignment.Bottom;

			for (int i = 0; i < 4; i++)
			{
				BackendGrid.RowDefinitions.Add(new RowDefinition() /*{ Height = new GridLength(30) }*/);
			}

			for (int j = 0; j < 3; j++)
			{
				BackendGrid.ColumnDefinitions.Add(new ColumnDefinition() /*{ Width = new GridLength(30) }*/);
			}

			int k = 0;

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{

					RepeatButton button = new RepeatButton
					{
						Name = NumPad[k].VKCode.ToString(),
						Content = NumPad[k].DiplayName,
						DataContext = NumPad[k].VKCode,
						Width = NumPad[k].Width,
						Height = NumPad[k].Height,
						Focusable = false
					};

					BackendGrid.Children.Add(button);
					Grid.SetRow(button, i);
					Grid.SetColumn(button, j);
					button.Click += this.RepeatButton_Click;

					k++;
				}
			}

		}

		public void RepeatButton_Click(object sender, RoutedEventArgs e)
		{
			RepeatButton button = sender as RepeatButton;
			INPUT[] Inputs = new INPUT[1];
			INPUT Input = new INPUT();
			Input.Type = (int)InputType.Keyboard;
			Input.Data.Keyboard.KeyCode = (ushort)(VirtualKeyCode)button.DataContext;
			Inputs[0] = Input;
			PInvokeMethods.SendInput(Input.Type, Inputs, Marshal.SizeOf(typeof(INPUT)));
		}

		public static readonly DependencyProperty ContentProperty =
		DependencyProperty.Register(nameof(Content), typeof(Visibility), typeof(Keyboard),
		new PropertyMetadata(default(Visibility)));

		public Visibility Content
		{
			get { return (Visibility)GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}


		public static readonly DependencyProperty KeyPadVisibilityProperty =
				DependencyProperty.Register(nameof(KeyPadVisibility), typeof(Visibility), typeof(Keyboard),
				new PropertyMetadata(default(Visibility)));

		public Visibility KeyPadVisibility
		{
			get { return (Visibility)GetValue(KeyPadVisibilityProperty); }
			set { SetValue(KeyPadVisibilityProperty, value); }
		}

		public static readonly DependencyProperty NumPadVisibilityProperty =
				DependencyProperty.Register(nameof(NumPadVisibility), typeof(Visibility), typeof(Keyboard),
				new PropertyMetadata(default(Visibility)));

		public Visibility NumPadVisibility
		{
			get { return (Visibility)GetValue(NumPadVisibilityProperty); }
			set { SetValue(NumPadVisibilityProperty, value); }
		}


	}
}
