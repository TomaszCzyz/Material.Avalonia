using Avalonia;
using Avalonia.Controls;

namespace Material.Styles.Assists;

public static class TextFieldAssist
{
    public static readonly AvaloniaProperty<string> HintsProperty
        = AvaloniaProperty.RegisterAttached<TextBox, string>("Hints", typeof(TextBox));

    public static void SetHints(AvaloniaObject element, string value) => element.SetValue(HintsProperty, value);

    public static string GetHints(AvaloniaObject element) => (string)element.GetValue(HintsProperty)!;

    public static readonly AvaloniaProperty<string> LabelProperty
        = AvaloniaProperty.RegisterAttached<TextBox, string>("Label", typeof(TextBox));

    public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

    public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty)!;

    private static readonly CornerRadius _defaultCornerRadius = new(0);

    /// <summary>
    ///     Controls the corner radius of the surrounding box.
    /// </summary>
    public static readonly AvaloniaProperty<CornerRadius> CornerRadiusProperty = AvaloniaProperty.RegisterAttached<TextBox, CornerRadius>(
        "CornerRadius", typeof(TextFieldAssist), _defaultCornerRadius, true);

    public static CornerRadius GetCornerRadius(AvaloniaObject element)
    {
        return (CornerRadius)element.GetValue(CornerRadiusProperty)!;
    }

    public static void SetCornerRadius(AvaloniaObject element, CornerRadius value)
    {
        element.SetValue(CornerRadiusProperty, value);
    }
}
