namespace CustomControls.BlazorWpfCommon;

using System.Windows;
using System.Windows.Controls;

/// <summary>
/// Interaction logic for EyeCircleControl.xaml.
/// </summary>
public partial class EyeCircleControl : UserControl
{
    #region Constants
    private const EyeCircleType DefaultType = EyeCircleType.Open;
    #endregion

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
    public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(nameof(TypeProperty)[..^8], typeof(EyeCircleType), typeof(EyeCircleControl), new UIPropertyMetadata(DefaultType));
    #endregion
}
