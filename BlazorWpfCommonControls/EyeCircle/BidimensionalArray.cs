namespace CustomControls.BlazorWpfCommon;

/// <summary>
/// Represents a two-dimensions array of objects.
/// </summary>
/// <typeparam name="T">The object type.</typeparam>
public class BidimensionalArray<T>
{
    /// <summary>
    /// Gets the empty array.
    /// </summary>
    public static readonly BidimensionalArray<T> Empty = new();

    private BidimensionalArray()
    {
        Internal = System.Array.Empty<T[]>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BidimensionalArray{T}"/> class.
    /// </summary>
    /// <param name="cx">The first dimension length.</param>
    /// <param name="cy">The second dimension length.</param>
    /// <param name="initialValue">The value to use for initializing each array cell.</param>
    public BidimensionalArray(int cx, int cy, T initialValue)
    {
        Internal = new T[cx][];

        for (int x = 0; x < cx; x++)
        {
            Internal[x] = new T[cy];

            for (int y = 0; y < cy; y++)
                Internal[x][y] = initialValue;
        }
    }

    /// <summary>
    /// Gets the length of the first dimension.
    /// </summary>
    public int LengthX { get { return Internal.GetLength(0); } }

    /// <summary>
    /// Gets the length of the second dimension.
    /// </summary>
    public int LengthY { get { return Internal.GetLength(1); } }

    /// <summary>
    /// Gets the value at the provided coordinates.
    /// </summary>
    /// <param name="x">The first coordinate.</param>
    /// <param name="y">The second coordinate.</param>
    /// <returns>The value at the provided coordinates.</returns>
    public T At(int x, int y)
    {
        return Internal[x][y];
    }

    /// <summary>
    /// Sets the value at the provided coordinates.
    /// </summary>
    /// <param name="x">The first coordinate.</param>
    /// <param name="y">The second coordinate.</param>
    /// <param name="value">The value to set.</param>
    public void Set(int x, int y, T value)
    {
        Internal[x][y] = value;
    }

    private readonly T[][] Internal;
}
