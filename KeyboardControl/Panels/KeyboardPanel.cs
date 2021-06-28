using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KeyboardControl.Panels
{
	//public class KeyboardPanel : Panel
	//{
	//	public double KeyMargin
	//	{
	//		get { return (double)GetValue(KeyMarginProperty); }
	//		set { SetValue(KeyMarginProperty, value); }
	//	}

	//	public static readonly DependencyProperty KeyMarginProperty =
	//			DependencyProperty.Register(nameof(KeyMargin), typeof(double), typeof(KeyboardPanel),
	//			new FrameworkPropertyMetadata(0.0d, FrameworkPropertyMetadataOptions.AffectsArrange
	//			| FrameworkPropertyMetadataOptions.AffectsMeasure));

	//	protected override Size MeasureOverride(Size constraint)
	//	{
	//		double rowHeight = 0;

	//		RowHeights.Clear();
	//		// First, measure all the left column children
	//		for (int i = 0; i < VisualChildrenCount; i += 2)
	//		{
	//			var child = Children[i];
	//			child.Measure(constraint);
	//			col1Width = Math.Max(child.DesiredSize.Width, col1Width);
	//			RowHeights.Add(child.DesiredSize.Height);
	//		}
	//		// Then, measure all the right column children, they get whatever remains in width
	//		var newWidth = Math.Max(0, constraint.Width - col1Width - ColumnSpacing);
	//		Size newConstraint = new Size(newWidth, constraint.Height);
	//		for (int i = 1; i < VisualChildrenCount; i += 2)
	//		{
	//			var child = Children[i];
	//			child.Measure(newConstraint);
	//			col2Width = Math.Max(child.DesiredSize.Width, col2Width);
	//			RowHeights[i / 2] = Math.Max(RowHeights[i / 2], child.DesiredSize.Height);
	//		}

	//		Column1Width = col1Width;
	//		return new Size(
	//			col1Width + ColumnSpacing + col2Width,
	//			RowHeights.Sum() + ((RowHeights.Count - 1) * RowSpacing));
	//	}

	//}
}
