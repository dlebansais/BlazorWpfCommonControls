namespace CustomControls.BlazorWpfCommon;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

/// <summary>
/// Interaction logic for a <see cref="InitControl"/>.
/// </summary>
public partial class InitControl : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InitControl"/> class.
    /// </summary>
    public InitControl()
    {
        InitializeComponent();

        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs args)
    {
        if (Parent is not Panel AsPanel)
            return;

        int ThisIndex = AsPanel.Children.IndexOf(this);
        if (ThisIndex <= 0)
            return;

        UIElement Sibling = AsPanel.Children[ThisIndex - 1];

        switch (Sibling)
        {
            case ToggleButton AsToggleButton:
                if (AsToggleButton.IsThreeState)
                {
                    if (AsToggleButton.IsChecked.HasValue)
                        OnUserInitialized();
                    else
                    {
                        AsToggleButton.Checked += OnCheckBoxUserInitialized;
                        AsToggleButton.Unchecked += OnCheckBoxUserInitialized;
                    }
                }

                break;
            case Selector AsSelector:
                if (AsSelector.SelectedIndex >= 0)
                    OnUserInitialized();
                else
                    AsSelector.SelectionChanged += OnSelectorUserInitialized;
                break;
            case TextBox AsTextBox:
                if (AsTextBox.Text.Length > 0)
                    OnUserInitialized();
                else
                    AsTextBox.TextChanged += OnTextBoxUserInitialized;
                break;
            default:
                break;
        }
    }

    private void OnCheckBoxUserInitialized(object sender, RoutedEventArgs args)
    {
        ToggleButton AsToggleButton = (ToggleButton)sender;
        AsToggleButton.IsThreeState = false;

        OnUserInitialized();
    }

    private void OnSelectorUserInitialized(object sender, SelectionChangedEventArgs args)
    {
        OnUserInitialized();
    }

    private void OnTextBoxUserInitialized(object sender, TextChangedEventArgs args)
    {
        OnUserInitialized();
    }

    private void OnUserInitialized()
    {
        Visibility = Visibility.Collapsed;
    }
}
