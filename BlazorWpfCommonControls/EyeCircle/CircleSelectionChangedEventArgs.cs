namespace CustomControls.BlazorWpfCommon;

using System.Windows;

/// <summary>
/// Contains coordinates for the selection changed event of the <see cref="EyeCirclePanel"/> control.
/// </summary>
public class CircleSelectionChangedEventArgs : RoutedEventArgs
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="CircleSelectionChangedEventArgs"/> class.
    /// </summary>
    /// <param name="routedEvent">The event this argument is associated to.</param>
    /// <param name="source">The control from which editing is left.</param>
    /// <param name="x">The horizontal coordinate.</param>
    /// <param name="y">The vertical coordinate.</param>
    internal CircleSelectionChangedEventArgs(RoutedEvent routedEvent, EyeCirclePanel source, int x, int y)
        : base(routedEvent, source)
    {
        X = x;
        Y = y;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the horizontal coordinate.
    /// </summary>
    /// <returns>The horizontal coordinate.</returns>
    public int X { get; }

    /// <summary>
    /// Gets the vertical coordinate.
    /// </summary>
    /// <returns>The vertical coordinate.</returns>
    public int Y { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the section should be cleared.
    /// </summary>
    /// <returns>A value indicating whether the section should be cleared.</returns>
    public bool ClearSelection { get; set; }
    #endregion
}
