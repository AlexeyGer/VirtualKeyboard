
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
using KeyboardControl.Metadata;
using System.Windows.Input;
using KeyboardControl.Utils;

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
	public class Keyboard : Control //TODO: KeyboardTypeSwitcher()
	{
		//public Grid BackendGrid = new Grid();
		public List<UIElement> charPadKeys = new List<UIElement>();
		public List<UIElement> numPadKeys = new List<UIElement>();

		public ItemsControl CharPadType;
		public ItemsControl NumPadType;


		public List<KeyData> NumPad => new NumPadKeyList().GetNumPadKeyList();
		public List<KeyData> CharPad => new CharPadKeyList().GetCharPadKeyList();

		KeyBoardType keyboardType;

		public List<UIElement> CharPadKeys
		{
			get { return charPadKeys; }
		}

		public List<UIElement> NumPadKeys
		{
			get { return numPadKeys; }
		}


		public static readonly DependencyProperty KeyMetadataProperty = DependencyProperty.RegisterAttached(
			  "KeyMetadata",
			  typeof(KeyData),
			  typeof(ButtonBase)
		);


		public static KeyData GetKeyMetadata(UIElement element)
		{
			return (KeyData)element.GetValue(KeyMetadataProperty);
		}

		public static void SetKeyMetadata(UIElement element, KeyData keyData)
		{
			element.SetValue(KeyMetadataProperty, keyData);
		}




		public static readonly DependencyProperty KeyboardTypeProperty = DependencyProperty.RegisterAttached(
			  "KeyboardType",
			  typeof(KeyBoardType),
			  typeof(TextBox)
		);

		public static KeyBoardType GetKeyboardType(DependencyObject element)
		{
			return (KeyBoardType)element.GetValue(KeyboardTypeProperty);
		}

		public static void SetKeyboardType(DependencyObject element, KeyBoardType type)
		{
			element.SetValue(KeyboardTypeProperty, type);
		}


		internal void GetFocus(object sender, RoutedEventArgs e)
		{

			if (sender is TextBox)
			{
				keyboardType = GetKeyboardType(sender as DependencyObject);
			}

			KeyboardTypeSwitcher(keyboardType);
		}

		

		static Keyboard()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Keyboard), new FrameworkPropertyMetadata(typeof(Keyboard)));
		}

		public Keyboard()
		{
			EventManager.RegisterClassHandler(
					typeof(UIElement),
					GotKeyboardFocusEvent,
					new RoutedEventHandler(GetFocus)
			);

			Application.Current.Exit += OnExit;
		}

		public void KeyboardTypeSwitcher(KeyBoardType KeyboardTypeProperty)
		{
			if (KeyboardTypeProperty == KeyBoardType.Full)
			{
				CharPadType.Visibility = Visibility.Visible;
				NumPadType.Visibility = Visibility.Visible;
			}

			if (KeyboardTypeProperty == KeyBoardType.CharPad)
			{
				CharPadType.Visibility = Visibility.Visible;
				NumPadType.Visibility = Visibility.Collapsed;
			}

			if (KeyboardTypeProperty == KeyBoardType.NumPad)
			{
				CharPadType.Visibility = Visibility.Collapsed;
				NumPadType.Visibility = Visibility.Visible;
			}
		}


		public override void OnApplyTemplate()
		{
			//BackendGrid = GetTemplateChild("NumPadGrid") as Grid;
			//GridGenerate();
			GetCharPadList();
			GetNumPadList();
			CharPadType = GetTemplateChild("CharPadLayout") as ItemsControl;
			NumPadType = GetTemplateChild("NumPadLayout") as ItemsControl;
		}

		public void GetCharPadList()
		{
			foreach (KeyData keyData in CharPad)
			{
				if (keyData.VKCode == VirtualKeyCode.LSHIFT)
				{
					ToggleButton button = new ToggleButton
					{
						Name = keyData.VKCode.ToString(),
						Content = keyData.UIName,
						DataContext = keyData,

						Focusable = false
					};

					SetKeyMetadata(button, keyData);
					CharPadKeys.Add(button);
					//button.Click += this.Shift_Click;
					button.Checked += ShiftChecked;
					button.Unchecked += ShiftUnchecked;
				}

				else
				{
					RepeatButton button = new RepeatButton
					{
						Name = keyData.VKCode.ToString(),
						Content = keyData.UIName,
						DataContext = keyData,

						Focusable = false
					};

					SetKeyMetadata(button, keyData);
					CharPadKeys.Add(button);
					button.Click += this.RepeatButton_Click;
				}

			}
		}

		public void GetNumPadList()
		{
			foreach (KeyData keyData in NumPad)
			{
				RepeatButton button = new RepeatButton
				{
					Name = keyData.VKCode.ToString(),
					Content = keyData.UIName,
					DataContext = keyData,

					Focusable = false
				};

				SetKeyMetadata(button, keyData);
				NumPadKeys.Add(button);
				button.Click += this.RepeatButton_Click;
			}
		}


		public void RepeatButton_Click(object sender, RoutedEventArgs e)
		{
			RepeatButton button = sender as RepeatButton;
			INPUT[] Inputs = new INPUT[1];
			INPUT Input = new INPUT();
			Input.Type = (int)Enums.InputType.Keyboard;
			//Input.Data.Keyboard.KeyCode = (ushort)(VirtualKeyCode)button.DataContext;
			Input.Data.Keyboard.KeyCode = (ushort)(VirtualKeyCode)Keyboard.GetKeyMetadata(button).VKCode;

			Inputs[0] = Input;
			PInvokeMethods.SendInput(Input.Type, Inputs, Marshal.SizeOf(typeof(INPUT)));
		}


		private void ShiftChecked (object sender, RoutedEventArgs e)
		{
			ToggleButton button = sender as ToggleButton;
			INPUT[] Inputs = new INPUT[1];
			INPUT Input = new INPUT();
			Input.Type = (int)Enums.InputType.Keyboard;
			Input.Data.Keyboard.KeyCode = (ushort)(VirtualKeyCode)Keyboard.GetKeyMetadata(button).VKCode;
			Inputs[0] = Input;
			PInvokeMethods.SendInput(Input.Type, Inputs, Marshal.SizeOf(typeof(INPUT)));

			foreach (var key in charPadKeys)
			{
				ButtonBase but = key as ButtonBase;
				//but.Content = Keyboard.GetKeyMetadata(key).VKCode.ToString().ToUpper();
				////but.Content = ToUnicodeConverter.GetKeyUIName(Keyboard.GetKeyMetadata(key).VKCode).ToUpper();
				//but.Content = ToUnicodeConverter.GetKeyUIName((VirtualKeyCode)but.Name.To).ToUpper();

				switch (but.Content)
				{
					case "BS":
					case "TAB":
					case "ENTER":
					case "SHIFT":
					case "EN":
					case "@123":
					case "<":
					case ">":
						break;
					default:
						but.Content = but.Content.ToString().ToUpperInvariant();
						break;
				}
			}

			//InvalidateVisual();
		}

		private void ShiftUnchecked(object sender, RoutedEventArgs e)
		{
			ToggleButton button = sender as ToggleButton;
			INPUT[] Inputs = new INPUT[1];
			INPUT Input = new INPUT();
			Input.Type = (int)Enums.InputType.Keyboard;
			Input.Data.Keyboard.KeyCode = (ushort)(VirtualKeyCode)Keyboard.GetKeyMetadata(button).VKCode;
			Input.Data.Keyboard.Flags = (uint)KeyboardFlag.KeyUp;
			Inputs[0] = Input;
			PInvokeMethods.SendInput(Input.Type, Inputs, Marshal.SizeOf(typeof(INPUT)));

			foreach (var key in charPadKeys)
			{
				ButtonBase but = key as ButtonBase;

				//ButtonBase but = key as ButtonBase;
				//but.Content = but.Content.ToString().ToUpper();
				switch (but.Content)
				{
					case "BS":
					case "TAB":
					case "ENTER":
					case "SHIFT":
					case "EN":
					case "@123":
					case "<":
					case ">":
						break;
					default:
						but.Content = but.Content.ToString().ToLowerInvariant();
						break;
				}
			}
		}

		public virtual void OnExit(object sender, ExitEventArgs args)
		{
			//byte[] buffer = new byte[255];
			short state = PInvokeMethods.GetAsyncKeyState((ushort)VirtualKeyCode.LSHIFT);

			if (state != 0)
			{
				ToggleButton button = sender as ToggleButton;
				INPUT[] Inputs = new INPUT[1];
				INPUT Input = new INPUT();
				Input.Type = (int)Enums.InputType.Keyboard;
				Input.Data.Keyboard.KeyCode = (ushort)VirtualKeyCode.LSHIFT;
				Input.Data.Keyboard.Flags = (uint)KeyboardFlag.KeyUp;
				Inputs[0] = Input;
				PInvokeMethods.SendInput(Input.Type, Inputs, Marshal.SizeOf(typeof(INPUT)));
			}
		}
	}
}
