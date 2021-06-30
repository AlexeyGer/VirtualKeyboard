using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardControl.Panels
{
	public class KeyboardPanel : Panel
	{
		//double[] rowHeight = new double[4] { 0, 0, 0, 0 };
		//private List<Double> ColumnWidth = new List<double>();
		double rowWidth;
		double rowHeight;

		List<UIElement> firstRowElements = new List<UIElement>();
		List<UIElement> secondRowElements = new List<UIElement>();
		List<UIElement> thirdRowElements = new List<UIElement>();
		List<UIElement> fourthRowElements = new List<UIElement>();

		public double KeyMargin = 5;

		//public double KeyMargin
		//{
		//	get { return (double)GetValue(KeyMarginProperty); }
		//	set { SetValue(KeyMarginProperty, value); }
		//}

		//public static readonly DependencyProperty KeyMarginProperty =
		//		DependencyProperty.Register(nameof(KeyMargin), typeof(double), typeof(KeyboardPanel),
		//		new FrameworkPropertyMetadata(5, FrameworkPropertyMetadataOptions.AffectsArrange
		//		| FrameworkPropertyMetadataOptions.AffectsMeasure));

		public void GetRowsElements()
		{
			foreach (UIElement child in this.Children)
			{
				int row = Keyboard.GetKeyMetadata(child).RowPosition;

				switch (row)
				{
					case 0:
						firstRowElements.Add(child);
						break;
					case 1:
						secondRowElements.Add(child);
						break;
					case 2:
						thirdRowElements.Add(child);
						break;
					case 3:
						fourthRowElements.Add(child);
						break;
				}
			}
		}

		public double AvailableWidthForFistElement(List<UIElement> targertRowElements)
		{
			double widthSum = 0;
			double availableWidthForFistElement = 0;

			for (int i = 1; i < targertRowElements.Count; i++)
			{
				widthSum += Keyboard.GetKeyMetadata(targertRowElements[i]).Width + KeyMargin * 2;
			}

			availableWidthForFistElement = rowWidth - widthSum;

			return availableWidthForFistElement;
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			foreach (UIElement child in this.Children)
			{

				if (Keyboard.GetKeyMetadata(child).RowPosition == 0)
				{
					rowWidth += Keyboard.GetKeyMetadata(child).Width + KeyMargin * 2;
				}

				rowHeight = Keyboard.GetKeyMetadata(this.Children[0]).Height + KeyMargin * 2;
			}

			GetRowsElements();

			foreach (UIElement child in this.Children)
			{
				if (child == secondRowElements[0])
				{
					Size childSize = new Size ((double)AvailableWidthForFistElement(secondRowElements), rowHeight);
					child.Measure(childSize);
				}
				if (child == thirdRowElements[0])
				{
					Size childSize = new Size((double)AvailableWidthForFistElement(thirdRowElements), rowHeight);
					child.Measure(childSize);
				}
				if (child == fourthRowElements[0])
				{
					Size childSize = new Size((double)AvailableWidthForFistElement(fourthRowElements), rowHeight);
					child.Measure(childSize);
				}
				else
				{
					Size childSize = new Size((double)Keyboard.GetKeyMetadata(child).Width + KeyMargin * 2, rowHeight);
					child.Measure(childSize);
				}
			}

			return new Size(rowWidth, rowHeight*4);
		}

		protected override Size ArrangeOverride(Size arrangeSize)
		{
			double cellWidth;
			double cellHeight;
			//int rowCounter = 0;
			//int keyCounter = 0;
			double currentX = 0;
			double currentY = 0;

			foreach (UIElement child in this.Children)
			{
				cellHeight = rowHeight;
				cellWidth = (double)child.DesiredSize.Width /*+ KeyMargin * 2*/;

				//cellWidth = Keyboard.GetKeyMetadata(child).Width + KeyMargin * 2;

				child.Arrange(new Rect(currentX, currentY, cellWidth, cellHeight));

				//keyCounter++;
				currentX += cellWidth;
				if (child == firstRowElements[firstRowElements.Count - 1]
					|| child == secondRowElements[secondRowElements.Count - 1]
					|| child == thirdRowElements[thirdRowElements.Count - 1])
				{
					//rowCounter++;
					//colcounter = 0;
					currentY += cellHeight;
					currentX = 0;
				}
			}

			return arrangeSize;
		}

	}
}
