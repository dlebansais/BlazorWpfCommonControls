namespace BlazorWpfCommonControls.Test;

using System.Threading;
using System.Windows.Media;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestEyeCirclePanel
{
    [Test]
    public void TestSimpleLoad()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            Thread.Sleep(100);

            BidimensionalArray<EyeCircleType> TypeArray = new(4, 1, EyeCircleType.Empty);
            TypeArray.Set(0, 0, EyeCircleType.Open);
            TypeArray.Set(1, 0, EyeCircleType.Closed);
            TypeArray.Set(2, 0, EyeCircleType.Mixed);
            TypeArray.Set(3, 0, EyeCircleType.Empty);
            Panel.TypeArray = TypeArray;

            BidimensionalArray<Brush> ForegroundArray = new(4, 1, Brushes.Transparent);
            ForegroundArray.Set(0, 0, Brushes.Red);
            ForegroundArray.Set(1, 0, Brushes.Green);
            ForegroundArray.Set(2, 0, Brushes.Blue);
            ForegroundArray.Set(3, 0, Brushes.Transparent);
            Panel.ForegroundArray = ForegroundArray;

            BidimensionalArray<string?> ToolTipArray = new(4, 1, null);
            ToolTipArray.Set(0, 0, "Red");
            ToolTipArray.Set(1, 0, "Green");
            ToolTipArray.Set(2, 0, "Blue");
            ToolTipArray.Set(3, 0, null);
            Panel.ToolTipArray = ToolTipArray;

            BidimensionalArray<bool> MaskArray = new(4, 1, false);
            MaskArray.Set(0, 0, true);
            MaskArray.Set(1, 0, true);
            MaskArray.Set(2, 0, true);
            MaskArray.Set(3, 0, false);
            Panel.MaskArray = MaskArray;

            BidimensionalArray<bool> HighlightArray = new(4, 1, false);
            HighlightArray.Set(0, 0, true);
            HighlightArray.Set(1, 0, true);
            HighlightArray.Set(2, 0, true);
            HighlightArray.Set(3, 0, false);
            Panel.HighlightArray = HighlightArray;

            Thread.Sleep(100);
            Panel.Selectable = true;

            TestTools.UnloadControl(Popup);
        });
    }
}
