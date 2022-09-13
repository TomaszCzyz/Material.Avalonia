using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Material.Styles.Assists;

public static class SelectionControlAssist
{
    public static readonly AvaloniaProperty<double> SizeProperty
        = AvaloniaProperty.RegisterAttached<Button, double>("Size", typeof(SelectionControlAssist));

    public static double GetSize(Button element) => (double)element.GetValue(SizeProperty)!;

    public static void SetSize(Button element, double checkBoxSize) => element.SetValue(SizeProperty, checkBoxSize);

    public static readonly AvaloniaProperty<IBrush> ForegroundProperty
        = AvaloniaProperty.RegisterAttached<Button, IBrush>("Foreground", typeof(SelectionControlAssist));

    public static IBrush GetForeground(Button element) => (IBrush)element.GetValue(ForegroundProperty)!;

    public static void SetForeground(Button element, IBrush brush) => element.SetValue(ForegroundProperty, brush);

    public static readonly AvaloniaProperty<IBrush> InnerForegroundProperty
        = AvaloniaProperty.RegisterAttached<Button, IBrush>("InnerForeground", typeof(SelectionControlAssist));

    public static IBrush GetInnerForeground(Button element) => (IBrush)element.GetValue(InnerForegroundProperty)!;

    public static void SetInnerForeground(Button element, IBrush brush) => element.SetValue(InnerForegroundProperty, brush);
}
