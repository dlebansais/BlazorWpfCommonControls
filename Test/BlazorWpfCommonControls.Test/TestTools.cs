namespace BlazorWpfCommonControls.Test;

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Contracts;

public static class TestTools
{
    public static bool StaThreadWrapper(Action action)
    {
        bool Success = true;

        var NewThread = new Thread(new ThreadStart(() =>
        {
            try
            {
                action();
                Dispatcher.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                Success = false;
            }
        }));

        NewThread.SetApartmentState(ApartmentState.STA);
        NewThread.Start();
        NewThread.Join();

        return Success;
    }

    public static bool StaThreadWrapper(Action<Application> action)
    {
        bool Success = true;

        var NewThread = new Thread(new ThreadStart(() =>
        {
            try
            {
                Window NewWindow = new();
                NewWindow.Content = new Grid();

                Application NewApp = new();
                NewApp.MainWindow = NewWindow;

                NewWindow.Show();

                action(NewApp);
                bool succ = NewWindow.Activate();

                Dispatcher.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                Success = false;
            }
        }));

        NewThread.SetApartmentState(ApartmentState.STA);
        NewThread.Start();
        NewThread.Join();

        return Success;
    }

    public static Popup LoadControl(UIElement control)
    {
        Contract.RequireNotNull(control, out UIElement Control);

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
