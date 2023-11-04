namespace BlazorWpfCommonControls.Test;

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestPopupExpander
{
    [Test]
    public void TestSimpleLoad()
    {
        bool Success = TestTools.StaThreadWrapper((Application app) =>
        {
            PopupExpander Control = new();
            var Popup = TestTools.LoadControl(Control);
            Control.Header = "Header";
            Assert.That(Control.Header, Is.EqualTo("Header"));
            Control.Content = "Content";
            Assert.That(Control.Content, Is.EqualTo("Content"));
            using Stream DataTemplateStream = new MemoryStream(Encoding.UTF8.GetBytes(@"
<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
    <TextBlock />
</DataTemplate>
"));
            Control.ContentTemplate = (DataTemplate)XamlReader.Load(DataTemplateStream);
            Assert.That(Control.ContentTemplate.HasContent, Is.True);
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

            Control.IsExpanded = true;
            Assert.That(Control.IsExpanded, Is.True);
            Thread.Sleep(100);

            Timer AlignButtonCenterTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Control.ButtonAlignment = HorizontalAlignment.Center;
                }), DispatcherPriority.ContextIdle);
            }));
            _ = AlignButtonCenterTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);

            Timer HideTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    app.MainWindow.Hide();
                }), DispatcherPriority.ContextIdle);
            }));
            _ = HideTimer.Change(TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                    app.Shutdown();
                }), DispatcherPriority.ContextIdle);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(3), Timeout.InfiniteTimeSpan);
        });

        Assert.IsTrue(Success);
    }
}
