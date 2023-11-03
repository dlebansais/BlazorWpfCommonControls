namespace BlazorWpfCommonControls.Test;

using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestSelection()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Grid InternalGrid = (Grid)Panel.GetType().GetField("InternalGrid", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Panel);
            EyeCircleControl FirstEyeCircle = (EyeCircleControl)InternalGrid.Children[0];
            var EventArgs = new MouseButtonEventArgs(InputManager.Current.PrimaryMouseDevice, 0, MouseButton.Left);
            EventArgs.RoutedEvent = UIElement.MouseLeftButtonDownEvent;

            Panel.SelectionChanged += OnSelectionChangedNoClear;

            Thread.Sleep(100);
            Panel.Selectable = true;
            Assert.That(Panel.Selectable, Is.True);

            FirstEyeCircle.RaiseEvent(EventArgs);

            Thread.Sleep(100);
            Panel.Selectable = false;
            Assert.That(Panel.Selectable, Is.False);

            FirstEyeCircle.RaiseEvent(EventArgs);

            Panel.SelectionChanged -= OnSelectionChangedNoClear;

            Panel.SelectionChanged += OnSelectionChangedClear;

            Thread.Sleep(100);
            Panel.Selectable = true;
            Assert.That(Panel.Selectable, Is.True);

            FirstEyeCircle.RaiseEvent(EventArgs);

            Thread.Sleep(100);
            Panel.Selectable = false;
            Assert.That(Panel.Selectable, Is.False);

            FirstEyeCircle.RaiseEvent(EventArgs);

            Panel.SelectionChanged -= OnSelectionChangedNoClear;

            FirstEyeCircle.RaiseEvent(EventArgs);

            TestTools.UnloadControl(Popup);
        });
    }

    private void OnSelectionChangedNoClear(object sender, CircleSelectionChangedEventArgs args)
    {
        Assert.That(args.X, Is.EqualTo(0));
        Assert.That(args.Y, Is.EqualTo(0));

        args.ClearSelection = false;
    }

    private void OnSelectionChangedClear(object sender, CircleSelectionChangedEventArgs args)
    {
        Assert.That(args.X, Is.EqualTo(0));
        Assert.That(args.Y, Is.EqualTo(0));

        args.ClearSelection = true;
    }

    [Test]
    public void TestSizeNaN()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Panel.Width = double.NaN;
            Panel.Height = double.NaN;

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestSizeNaNWidth()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Panel.Width = double.NaN;
            Panel.Height = 100;

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestSizeNaNHeight()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Panel.Width = 100;
            Panel.Height = double.NaN;

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestSizeZero()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Panel.Width = 0;
            Panel.Height = 0;

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestSizeNotZero()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Panel.Width = 100;
            Panel.Height = 100;

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestLargeLoad()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            Thread.Sleep(100);

            Panel.TypeArray = new(8, 2, EyeCircleType.Open);
            Panel.ForegroundArray = new(8, 2, Brushes.Black);
            Panel.ToolTipArray = new(8, 2, "Test");
            Panel.MaskArray = new(8, 2, true);
            Panel.HighlightArray = new(8, 2, true);

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestEnlarge()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            var Popup = TestTools.LoadControl(Panel);

            Thread.Sleep(100);

            Panel.TypeArray = new(8, 2, EyeCircleType.Open);
            Panel.ForegroundArray = new(8, 2, Brushes.Black);
            Panel.ToolTipArray = new(8, 2, "Test");
            Panel.MaskArray = new(8, 2, true);
            Panel.HighlightArray = new(8, 2, true);

            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestShrink()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            Panel.TypeArray = new(8, 2, EyeCircleType.Open);
            Panel.ForegroundArray = new(8, 2, Brushes.Black);
            Panel.ToolTipArray = new(8, 2, "Test");
            Panel.MaskArray = new(8, 2, true);
            Panel.HighlightArray = new(8, 2, true);

            var Popup = TestTools.LoadControl(Panel);

            Thread.Sleep(100);

            Panel.TypeArray = new(4, 1, EyeCircleType.Empty);
            Panel.ForegroundArray = new(4, 1, Brushes.Transparent);
            Panel.ToolTipArray = new(4, 1, null);
            Panel.MaskArray = new(4, 1, false);
            Panel.HighlightArray = new(4, 1, false);

            TestTools.UnloadControl(Popup);
        });
    }
}
