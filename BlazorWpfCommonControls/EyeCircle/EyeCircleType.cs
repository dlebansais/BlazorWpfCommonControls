namespace CustomControls.BlazorWpfCommon;

/// <summary>
/// Represents types of eye circles.
/// </summary>
public enum EyeCircleType
{
    /// <summary>
    /// The open type (one circle, not filled).
    /// </summary>
    Open,

    /// <summary>
    /// The closed type (one circle, filled).
    /// </summary>
    Closed,

    /// <summary>
    /// The closed type (two circles).
    /// </summary>
    Mixed,

    /// <summary>
    /// The closed type (no circle).
    /// </summary>
    Empty,
}
