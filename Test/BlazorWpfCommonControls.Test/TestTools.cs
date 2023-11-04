namespace BlazorWpfCommonControls.Test;

using System;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Contracts;

public static class TestTools
{
    public static void StaThreadWrapper(Action action)
    {
        var NewThread = new Thread(new ThreadStart(() =>
        {
            Window NewWindow = new();
            NewWindow.Content = new Grid();

            Application NewApp = new();
            NewApp.MainWindow = NewWindow;

            NewWindow.Show();

            action();
            Dispatcher.Run();
        }));

        NewThread.SetApartmentState(ApartmentState.STA);
        NewThread.Start();
        NewThread.Join();
    }

    public static Popup LoadControl(Control control)
    {
        Contract.RequireNotNull(control, out Control Control);

        Popup NewPopup = new();
        NewPopup.Child = Control;
        NewPopup.IsOpen = true;

        return NewPopup;
    }

    public static void UnloadControl(Popup popup)
    {
        Contract.RequireNotNull(popup, out Popup Popup);

        Popup.IsOpen = false;
        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.ContextIdle);
    }
}
