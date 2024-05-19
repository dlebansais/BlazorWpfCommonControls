namespace BlazorWpfCommonControls.Test;

using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Contracts;

public static partial class TestTools
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

    [RequireNotNull(nameof(control))]
    private static Popup LoadControlVerified(UIElement control)
    {
        Popup NewPopup = new();
        NewPopup.Child = control;
        NewPopup.IsOpen = true;

        return NewPopup;
    }

    [RequireNotNull(nameof(popup))]
    private static void UnloadControlVerified(Popup popup)
    {
        popup.IsOpen = false;
        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.ContextIdle);
    }
}
