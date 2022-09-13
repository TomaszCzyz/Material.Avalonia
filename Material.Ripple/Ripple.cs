using System;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Layout;

namespace Material.Ripple;

public class Ripple : Ellipse
{
    public static Easing Easing { get; set; } = new CircularEaseOut();

    public static readonly TimeSpan Duration = new(0, 0, 0, 0, 500);

    private readonly double _maxDiam;
    private readonly double _endX;
    private readonly double _endY;

    public Ripple(double outerWidth, double outerHeight)
    {
        Width = 0;
        Height = 0;

        _maxDiam = Math.Sqrt(Math.Pow(outerWidth, 2) + Math.Pow(outerHeight, 2));
        _endY = _maxDiam - outerHeight;
        _endX = _maxDiam - outerWidth;
        HorizontalAlignment = HorizontalAlignment.Left;
        VerticalAlignment = VerticalAlignment.Top;
        Opacity = 1;
    }

    public void SetupInitialValues(PointerPressedEventArgs e, Control parent)
    {
        var pointer = e.GetPosition(parent);
        Margin = new Thickness(pointer.X, pointer.Y, 0, 0);
    }

    public void RunFirstStep()
    {
        Width = _maxDiam;
        Height = _maxDiam;
        Margin = new Thickness(-_endX / 2, -_endY / 2, 0, 0);
    }

    public void RunSecondStep()
    {
        Opacity = 0;
    }
}
