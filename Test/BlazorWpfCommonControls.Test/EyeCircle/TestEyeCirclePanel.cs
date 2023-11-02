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
            TypeArray.Set(0, 1, EyeCircleType.Closed);
            TypeArray.Set(0, 2, EyeCircleType.Mixed);
            TypeArray.Set(0, 3, EyeCircleType.Empty);
            Panel.TypeArray = TypeArray;

            BidimensionalArray<Brush> ForegroundArray = new(4, 1, Brushes.Transparent);
            ForegroundArray.Set(0, 0, Brushes.Red);
            ForegroundArray.Set(0, 1, Brushes.Green);
            ForegroundArray.Set(0, 2, Brushes.Blue);
            ForegroundArray.Set(0, 3, Brushes.Transparent);
            Panel.ForegroundArray = ForegroundArray;

            BidimensionalArray<string?> ToolTipArray = new(4, 1, null);
            ToolTipArray.Set(0, 0, "Red");
            ToolTipArray.Set(0, 1, "Green");
            ToolTipArray.Set(0, 2, "Blue");
            ToolTipArray.Set(0, 3, null);
            Panel.ToolTipArray = ToolTipArray;

            BidimensionalArray<bool> MaskArray = new(4, 1, false);
            MaskArray.Set(0, 0, true);
            MaskArray.Set(0, 1, true);
            MaskArray.Set(0, 2, true);
            MaskArray.Set(0, 3, false);
            Panel.MaskArray = MaskArray;

            BidimensionalArray<bool> HighlightArray = new(4, 1, false);
            HighlightArray.Set(0, 0, true);
            HighlightArray.Set(0, 1, true);
            HighlightArray.Set(0, 2, true);
            HighlightArray.Set(0, 3, false);
            Panel.HighlightArray = HighlightArray;

            Thread.Sleep(100);
            Panel.Selectable = true;

            TestTools.UnloadControl(Popup);
        });
    }
}
