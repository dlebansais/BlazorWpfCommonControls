namespace BlazorWpfCommonControls.Test;

using System.Globalization;
using System.Windows;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestEyeCircleControl
{
    [Test]
    public void ConverterCoverage()
    {
        EyeCircleTypeToVisibilityConverter TestObject = new();
        var Result = TestObject.ConvertBack(Visibility.Collapsed, typeof(EyeCircleType), string.Empty, CultureInfo.InvariantCulture);

        Assert.That(Result, Is.EqualTo(DependencyProperty.UnsetValue));
    }
}
