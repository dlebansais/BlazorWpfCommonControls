namespace CustomControls.BlazorWpfCommon;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

/// <summary>
/// Interaction logic for EyeCircleControl.xaml
/// </summary>
public partial class EyeCircleControl : UserControl, INotifyPropertyChanged
{
    #region Init
    public EyeCircleControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Dependency Properties
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public EyeCircleType Type
    {
        get { return (EyeCircleType)GetValue(TypeProperty); }
        set { SetValue(TypeProperty, value); }
    }

    /// <summary>
    /// The Type dependency property.
    /// </summary>
    public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(EyeCircleType), typeof(EyeCircleControl), new UIPropertyMetadata(EyeCircleType.Open, OnTypeChanged));

    private static void OnTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCircleControl Control = (EyeCircleControl)sender;
        if (args.NewValue is EyeCircleType NewType)
            Control.OnTypeChanged(NewType);
    }

    /// <summary>
    /// Called when the Type property has changed.
    /// </summary>
    /// <param name="newType">The new value.</param>
    public void OnTypeChanged(EyeCircleType newType)
    {
        NotifyPropertyChanged(nameof(IsTypeOpen));
        NotifyPropertyChanged(nameof(IsTypeClosed));
        NotifyPropertyChanged(nameof(IsTypeMixed));
        NotifyPropertyChanged(nameof(IsTypeEmpty));
    }
    #endregion

    #region Properties
    public Visibility IsTypeOpen { get { return Type == EyeCircleType.Open ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility IsTypeClosed { get { return Type == EyeCircleType.Closed ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility IsTypeMixed { get { return Type == EyeCircleType.Mixed ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility IsTypeEmpty { get { return Type == EyeCircleType.Empty ? Visibility.Visible : Visibility.Collapsed; } }
    #endregion

    #region Implementation of INotifyPropertyChanged
    /// <summary>
    /// Implements the PropertyChanged event.
    /// </summary>
#nullable disable annotations
    public event PropertyChangedEventHandler PropertyChanged;
#nullable restore annotations

    internal void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal void NotifyThisPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
