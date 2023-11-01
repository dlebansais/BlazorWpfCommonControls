namespace CustomControls.BlazorWpfCommon;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

/// <summary>
/// Interaction logic for EyeCircleControl.xaml.
/// </summary>
public partial class EyeCircleControl : UserControl, INotifyPropertyChanged
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="EyeCircleControl"/> class.
    /// </summary>
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
        NotifyPropertyChanged(nameof(WhenOpenVisibility));
        NotifyPropertyChanged(nameof(WhenClosedVisibility));
        NotifyPropertyChanged(nameof(WhenMixedVisibility));
        NotifyPropertyChanged(nameof(WhenEmptyVisibility));
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the visibility of an open type.
    /// </summary>
    public Visibility WhenOpenVisibility { get { return Type == EyeCircleType.Open ? Visibility.Visible : Visibility.Collapsed; } }

    /// <summary>
    /// Gets the visibility of a closed type.
    /// </summary>
    public Visibility WhenClosedVisibility { get { return Type == EyeCircleType.Closed ? Visibility.Visible : Visibility.Collapsed; } }

    /// <summary>
    /// Gets the visibility of a mixed type.
    /// </summary>
    public Visibility WhenMixedVisibility { get { return Type == EyeCircleType.Mixed ? Visibility.Visible : Visibility.Collapsed; } }

    /// <summary>
    /// Gets the visibility of an empty type.
    /// </summary>
    public Visibility WhenEmptyVisibility { get { return Type == EyeCircleType.Empty ? Visibility.Visible : Visibility.Collapsed; } }
    #endregion

    #region Implementation of INotifyPropertyChanged
    /// <summary>
    /// Implements the PropertyChanged event.
    /// </summary>
#nullable disable annotations
    public event PropertyChangedEventHandler PropertyChanged;
#nullable restore annotations

    /// <summary>
    /// Notifies when a property has changed.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    internal void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Notifies when a property has changed.
    /// </summary>
    /// <param name="propertyName">The property name, taken from the caller.</param>
    internal void NotifyThisPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
