namespace BlazorWpfCommonControls.Test;

using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestInitControl
{
    [Test]
    public void TestNoPanel()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();

            var Popup = TestTools.LoadControl(Control);

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
        });

        Assert.That(Success, Is.True);
    }

    [Test]
    public void TestNoSibling()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();

            Grid NewGrid = new();
            _ = NewGrid.Children.Add(Control);

            var Popup = TestTools.LoadControl(NewGrid);

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
        });

        Assert.That(Success, Is.True);
    }
}
