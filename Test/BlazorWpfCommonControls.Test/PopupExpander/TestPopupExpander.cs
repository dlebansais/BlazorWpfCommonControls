namespace BlazorWpfCommonControls.Test;

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestPopupExpander
{
    [Test]
    public void TestSimpleLoad()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            PopupExpander Control = new();
            var Popup = TestTools.LoadControl(Control);
            Control.Header = "Header";
            Assert.That(Control.Header, Is.EqualTo("Header"));
            Control.Content = "Content";
            Assert.That(Control.Content, Is.EqualTo("Content"));
            FrameworkElementFactory VisualTree = new();
            Control.ContentTemplate = new DataTemplate() { VisualTree = VisualTree };
            Assert.That(Control.ContentTemplate.VisualTree, Is.EqualTo(VisualTree));
            Control.PopupWidth = 100;
            Assert.That(Control.PopupWidth, Is.EqualTo(100));
            Control.PopupHeight = 200;
            Assert.That(Control.PopupHeight, Is.EqualTo(200));
            Control.HorizontalOffset = 300;
            Assert.That(Control.HorizontalOffset, Is.EqualTo(300));
            Control.VerticalOffset = 400;
            Assert.That(Control.VerticalOffset, Is.EqualTo(400));

            Control.ButtonAlignment = HorizontalAlignment.Right;
            Assert.That(Control.ButtonAlignment, Is.EqualTo(HorizontalAlignment.Right));

            Assert.That(Control.HeaderMargin.Left, Is.EqualTo(0));
            Assert.That(Control.HeaderMargin.Top, Is.EqualTo(0));
            Assert.That(Control.HeaderMargin.Right, Is.EqualTo(5));
            Assert.That(Control.HeaderMargin.Bottom, Is.EqualTo(0));

            Control.ButtonAlignment = HorizontalAlignment.Left;
            Assert.That(Control.ButtonAlignment, Is.EqualTo(HorizontalAlignment.Left));

            Assert.That(Control.HeaderMargin.Left, Is.EqualTo(5));
            Assert.That(Control.HeaderMargin.Top, Is.EqualTo(0));
            Assert.That(Control.HeaderMargin.Right, Is.EqualTo(0));
            Assert.That(Control.HeaderMargin.Bottom, Is.EqualTo(0));

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                }), DispatcherPriority.Send);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);

            //Control.IsExpanded = true;
            //Thread.Sleep(100);
            Control.IsExpanded = false;
            Thread.Sleep(100);
        }, createApp: true);

        Assert.IsTrue(Success);
    }
}
