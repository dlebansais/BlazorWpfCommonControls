namespace BlazorWpfCommonControls.Test;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestInitControl
{
    [Test]
    public void TestTwoStateCheckBox()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            CheckBox NewCheckBox = new();
            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewCheckBox);
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

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestThreeStateCheckBox()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            CheckBox NewCheckBox = new();
            NewCheckBox.IsThreeState = true;
            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewCheckBox);
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

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestThreeStateUninitializedCheckBox()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            CheckBox NewCheckBox = new();
            NewCheckBox.IsThreeState = true;
            NewCheckBox.IsChecked = null;
            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewCheckBox);
            _ = NewGrid.Children.Add(Control);

            var Popup = TestTools.LoadControl(NewGrid);

            Timer ClickTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var EventArgs = new MouseButtonEventArgs(InputManager.Current.PrimaryMouseDevice, 0, MouseButton.Left);
                    EventArgs.RoutedEvent = ToggleButton.CheckedEvent;
                    NewCheckBox.RaiseEvent(EventArgs);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = ClickTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestListBox()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            ListBoxItem NewListBoxItem = new();
            NewListBoxItem.Content = "Test";
            ListBox NewListBox = new();
            _ = NewListBox.Items.Add(NewListBoxItem);
            NewListBox.SelectedIndex = 0;

            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewListBox);
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

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestListBoxUnselected()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            ListBoxItem NewListBoxItem = new();
            NewListBoxItem.Content = "Test";
            ListBox NewListBox = new();
            _ = NewListBox.Items.Add(NewListBoxItem);

            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewListBox);
            _ = NewGrid.Children.Add(Control);

            var Popup = TestTools.LoadControl(NewGrid);

            Timer ClickTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var EventArgs = new SelectionChangedEventArgs(Selector.SelectionChangedEvent, new List<object>(), new List<object>());
                    NewListBox.RaiseEvent(EventArgs);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = ClickTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestTextBox()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            TextBox NewTextBox = new();
            NewTextBox.Text = "Test";

            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewTextBox);
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

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestEmptyTextBox()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            TextBox NewTextBox = new();

            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewTextBox);
            _ = NewGrid.Children.Add(Control);

            var Popup = TestTools.LoadControl(NewGrid);

            Timer InputTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var EventArgs = new TextChangedEventArgs(TextBoxBase.TextChangedEvent, UndoAction.None);
                    NewTextBox.RaiseEvent(EventArgs);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = InputTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);

            Timer StopTimer = new(new TimerCallback((object parameter) =>
            {
                _ = Control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TestTools.UnloadControl(Popup);
                }), DispatcherPriority.ContextIdle);
            }));
            _ = StopTimer.Change(TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestUnsupportedSibling()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            InitControl Control = new();
            Border NewBorder = new();
            Grid NewGrid = new();
            _ = NewGrid.Children.Add(NewBorder);
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

        Assert.IsTrue(Success);
    }
}
