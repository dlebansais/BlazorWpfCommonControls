namespace BlazorWpfCommonControls.Test;

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

public static class TestTools
{
    public static void StaThreadWrapper(Action action)
    {
        var NewThread = new Thread(new ThreadStart(() =>
        {
            action();
            Dispatcher.Run();
        }));

        NewThread.SetApartmentState(ApartmentState.STA);
        NewThread.Start();
        NewThread.Join();
    }

    public static Popup LoadControl(Control control)
    {
        Debug.Assert(control is not null);

        Popup NewPopup = new();
        NewPopup.Child = control;
        NewPopup.IsOpen = true;

        while (!control.IsLoaded)
            Thread.Sleep(1);

        return NewPopup;
    }

    public static void UnloadControl(Popup popup)
    {
        Debug.Assert(popup is not null);

        popup.IsOpen = false;
        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.ContextIdle);
    }
}
