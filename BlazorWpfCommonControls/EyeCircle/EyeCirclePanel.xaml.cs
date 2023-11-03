namespace CustomControls.BlazorWpfCommon;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

/// <summary>
/// Interaction logic for EyeCirclePanel.xaml.
/// </summary>
public partial class EyeCirclePanel : UserControl
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="EyeCirclePanel"/> class.
    /// </summary>
    public EyeCirclePanel()
    {
        InitializeComponent();
    }
    #endregion

    #region Dependency Properties
    /// <summary>
    /// Gets or sets the type array.
    /// </summary>
    public BidimensionalArray<EyeCircleType> TypeArray
    {
        get { return (BidimensionalArray<EyeCircleType>)GetValue(TypeArrayProperty); }
        set { SetValue(TypeArrayProperty, value); }
    }

    /// <summary>
    /// The TypeArray dependency property.
    /// </summary>
    public static readonly DependencyProperty TypeArrayProperty = DependencyProperty.Register("TypeArray", typeof(BidimensionalArray<EyeCircleType>), typeof(EyeCirclePanel), new UIPropertyMetadata(BidimensionalArray<EyeCircleType>.Empty, OnTypeArrayChanged));

    private static void OnTypeArrayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCirclePanel Control = (EyeCirclePanel)sender;
        if (args.NewValue is not BidimensionalArray<EyeCircleType> NewTypeArray)
            throw new ArgumentException(nameof(TypeArray));

        Control.OnTypeArrayChanged(NewTypeArray);
    }

    /// <summary>
    /// Called when the TypeArray property has changed.
    /// </summary>
    /// <param name="newTypeArray">The new value.</param>
    public void OnTypeArrayChanged(BidimensionalArray<EyeCircleType> newTypeArray)
    {
        UpdateArray(newTypeArray, ForegroundArray, ToolTipArray, MaskArray, HighlightArray);
    }

    /// <summary>
    /// Gets or sets the foreground array.
    /// </summary>
    public BidimensionalArray<Brush> ForegroundArray
    {
        get { return (BidimensionalArray<Brush>)GetValue(ForegroundArrayProperty); }
        set { SetValue(ForegroundArrayProperty, value); }
    }

    /// <summary>
    /// The ForegroundArray dependency property.
    /// </summary>
    public static readonly DependencyProperty ForegroundArrayProperty = DependencyProperty.Register("ForegroundArray", typeof(BidimensionalArray<Brush>), typeof(EyeCirclePanel), new UIPropertyMetadata(BidimensionalArray<Brush>.Empty, OnForegroundArrayChanged));

    private static void OnForegroundArrayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCirclePanel Control = (EyeCirclePanel)sender;
        if (args.NewValue is not BidimensionalArray<Brush> NewForegroundArray)
            throw new ArgumentException(nameof(ForegroundArray));

        Control.OnForegroundArrayChanged(NewForegroundArray);
    }

    /// <summary>
    /// Called when the ForegroundArray property has changed.
    /// </summary>
    /// <param name="newForegroundArray">The new value.</param>
    public void OnForegroundArrayChanged(BidimensionalArray<Brush> newForegroundArray)
    {
        UpdateArray(TypeArray, newForegroundArray, ToolTipArray, MaskArray, HighlightArray);
    }

    /// <summary>
    /// Gets or sets the tooltip array.
    /// </summary>
    public BidimensionalArray<string?> ToolTipArray
    {
        get { return (BidimensionalArray<string?>)GetValue(ToolTipArrayProperty); }
        set { SetValue(ToolTipArrayProperty, value); }
    }

    /// <summary>
    /// The ToolTipArray dependency property.
    /// </summary>
    public static readonly DependencyProperty ToolTipArrayProperty = DependencyProperty.Register("ToolTipArray", typeof(BidimensionalArray<string?>), typeof(EyeCirclePanel), new UIPropertyMetadata(BidimensionalArray<string?>.Empty, OnToolTipArrayChanged));

    private static void OnToolTipArrayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCirclePanel Control = (EyeCirclePanel)sender;
        if (args.NewValue is not BidimensionalArray<string?> NewToolTipArray)
            throw new ArgumentException(nameof(ToolTipArray));

        Control.OnToolTipArrayChanged(NewToolTipArray);
    }

    /// <summary>
    /// Called when the ToolTipArray property has changed.
    /// </summary>
    /// <param name="newToolTipArray">The new value.</param>
    public void OnToolTipArrayChanged(BidimensionalArray<string?> newToolTipArray)
    {
        UpdateArray(TypeArray, ForegroundArray, newToolTipArray, MaskArray, HighlightArray);
    }

    /// <summary>
    /// Gets or sets the mask array.
    /// </summary>
    public BidimensionalArray<bool> MaskArray
    {
        get { return (BidimensionalArray<bool>)GetValue(MaskArrayProperty); }
        set { SetValue(MaskArrayProperty, value); }
    }

    /// <summary>
    /// The MaskArray dependency property.
    /// </summary>
    public static readonly DependencyProperty MaskArrayProperty = DependencyProperty.Register("MaskArray", typeof(BidimensionalArray<bool>), typeof(EyeCirclePanel), new UIPropertyMetadata(BidimensionalArray<bool>.Empty, OnMaskArrayChanged));

    private static void OnMaskArrayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCirclePanel Control = (EyeCirclePanel)sender;
        if (args.NewValue is not BidimensionalArray<bool> NewMaskArray)
            throw new ArgumentException(nameof(MaskArray));

        Control.OnMaskArrayChanged(NewMaskArray);
    }

    /// <summary>
    /// Called when the MaskArray property has changed.
    /// </summary>
    /// <param name="newMaskArray">The new value.</param>
    public void OnMaskArrayChanged(BidimensionalArray<bool> newMaskArray)
    {
        UpdateArray(TypeArray, ForegroundArray, ToolTipArray, newMaskArray, HighlightArray);
    }

    /// <summary>
    /// Gets or sets the highlight array.
    /// </summary>
    public BidimensionalArray<bool> HighlightArray
    {
        get { return (BidimensionalArray<bool>)GetValue(HighlightArrayProperty); }
        set { SetValue(HighlightArrayProperty, value); }
    }

    /// <summary>
    /// The HighlightArray dependency property.
    /// </summary>
    public static readonly DependencyProperty HighlightArrayProperty = DependencyProperty.Register("HighlightArray", typeof(BidimensionalArray<bool>), typeof(EyeCirclePanel), new UIPropertyMetadata(BidimensionalArray<bool>.Empty, OnHighlightArrayChanged));

    private static void OnHighlightArrayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCirclePanel Control = (EyeCirclePanel)sender;
        if (args.NewValue is not BidimensionalArray<bool> NewHighlightArray)
            throw new ArgumentException(nameof(HighlightArray));

        Control.OnHighlightArrayChanged(NewHighlightArray);
    }

    /// <summary>
    /// Called when the HighlightArray property has changed.
    /// </summary>
    /// <param name="newHighlightArray">The new value.</param>
    public void OnHighlightArrayChanged(BidimensionalArray<bool> newHighlightArray)
    {
        UpdateArray(TypeArray, ForegroundArray, ToolTipArray, MaskArray, newHighlightArray);
    }

    /// <summary>
    /// Gets or sets a value indicating whether a circle can be selected.
    /// </summary>
    public bool Selectable
    {
        get { return (bool)GetValue(SelectableProperty); }
        set { SetValue(SelectableProperty, value); }
    }

    /// <summary>
    /// The Selectable dependency property.
    /// </summary>
    public static readonly DependencyProperty SelectableProperty = DependencyProperty.Register("Selectable", typeof(bool), typeof(EyeCirclePanel), new UIPropertyMetadata(false, OnSelectableChanged));

    private static void OnSelectableChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        EyeCirclePanel Control = (EyeCirclePanel)sender;
        bool NewSelectable = (bool)args.NewValue;

        Control.OnSelectableChanged(NewSelectable);
    }

    /// <summary>
    /// Called when the Selectable property has changed.
    /// </summary>
    /// <param name="newSelectable">The new value.</param>
    public void OnSelectableChanged(bool newSelectable)
    {
        if (!newSelectable)
            ClearSelection();
    }
    #endregion

    #region Custom Events
    /// <summary>
    /// Identifies the <see cref="SelectionChanged"/> routed event.
    /// </summary>
    /// <returns>
    /// The identifier for the <see cref="SelectionChanged"/> routed event.
    /// </returns>
    public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(EventHandler<CircleSelectionChangedEventArgs>), typeof(EyeCirclePanel));

    /// <summary>
    /// Reports that the selection changed.
    /// </summary>
    public event EventHandler<CircleSelectionChangedEventArgs> SelectionChanged
    {
        add { AddHandler(SelectionChangedEvent, value); }
        remove { RemoveHandler(SelectionChangedEvent, value); }
    }

    /// <summary>
    /// Sends a <see cref="SelectionChanged"/> event.
    /// </summary>
    /// <param name="x">The horizontal coordinate.</param>
    /// <param name="y">The vertical coordinate.</param>
    /// <param name="clearSelection">True upon return to clear the selection.</param>
    protected virtual void NotifySelectionChanged(int x, int y, out bool clearSelection)
    {
        CircleSelectionChangedEventArgs Args = CreateSelectionChangedEvent(x, y);
        RaiseEvent(Args);

        clearSelection = Args.ClearSelection;
    }

    /// <summary>
    /// Creates arguments for the SelectionChanged routed event.
    /// </summary>
    /// <param name="x">The horizontal coordinate.</param>
    /// <param name="y">The vertical coordinate.</param>
    /// <returns>The <see cref="CircleSelectionChangedEventArgs"/> object created.</returns>
    protected virtual CircleSelectionChangedEventArgs CreateSelectionChangedEvent(int x, int y)
    {
        return new CircleSelectionChangedEventArgs(SelectionChangedEvent, this, x, y);
    }
    #endregion

    #region Events
    private void OnSizeChanged(object sender, SizeChangedEventArgs args)
    {
        GetLength(TypeArray, ForegroundArray, ToolTipArray, MaskArray, out int LengthX, out int LengthY);
        UpdateInternalSize(LengthX, LengthY);
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
    {
        EyeCircleControl Control = (EyeCircleControl)sender;

        if (Selectable)
        {
            int Column = Grid.GetColumn(Control);
            int Row = Grid.GetRow(Control);
            int X = Column - (Column / 5);
            int Y = Row;
            NotifySelectionChanged(X, Y, out bool ClearSelection);

            if (ClearSelection)
                InternalSelection.Visibility = Visibility.Hidden;
            else
            {
                Grid.SetColumn(InternalSelection, Column);
                Grid.SetRow(InternalSelection, Row);
                InternalSelection.Visibility = Visibility.Visible;
            }
        }
    }
    #endregion

    #region Client Interface
    /// <summary>
    /// Clears the selection.
    /// </summary>
    public void ClearSelection()
    {
        InternalSelection.Visibility = Visibility.Hidden;
    }
    #endregion

    #region Implementation
    private void UpdateArray(BidimensionalArray<EyeCircleType> modeArray, BidimensionalArray<Brush> foregroundArray, BidimensionalArray<string?> toolTipArray, BidimensionalArray<bool> maskArray, BidimensionalArray<bool> highlightArray)
    {
        GetLength(modeArray, foregroundArray, toolTipArray, maskArray, out int LengthX, out int LengthY);
        UpdateInternalSize(LengthX, LengthY);
        Populate(modeArray, foregroundArray, toolTipArray, maskArray, highlightArray, LengthX, LengthY);
        ClearSelection();
    }

    private static void GetLength(BidimensionalArray<EyeCircleType> modeArray, BidimensionalArray<Brush> foregroundArray, BidimensionalArray<string?> toolTipArray, BidimensionalArray<bool> maskArray, out int lengthX, out int lengthY)
    {
        lengthX = Math.Min(Math.Min(modeArray.LengthX, foregroundArray.LengthX), Math.Min(toolTipArray.LengthX, maskArray.LengthX));
        lengthY = Math.Min(Math.Min(modeArray.LengthY, foregroundArray.LengthY), Math.Min(toolTipArray.LengthY, maskArray.LengthY));
    }

    private void UpdateInternalSize(int lengthX, int lengthY)
    {
        if (double.IsNaN(ActualWidth) || double.IsNaN(ActualHeight))
            return;

        if (lengthX == 0 || lengthY == 0)
        {
            InternalGrid.Width = 0;
            InternalGrid.Height = 0;
        }
        else
        {
            double RatioX = ActualWidth / lengthX;
            double RatioY = ActualHeight / lengthY;

            double UniformRatio;

            if (!double.IsNaN(Width) && double.IsNaN(Height))
                UniformRatio = RatioX;
            else if (double.IsNaN(Width) && !double.IsNaN(Height))
                UniformRatio = RatioY;
            else
                UniformRatio = Math.Min(RatioX, RatioY);

            InternalGrid.Width = UniformRatio * lengthX;
            InternalGrid.Height = UniformRatio * lengthY;
        }
    }

    private static void UpdateColumnRowCollection(IList collection, int length, bool hasSeparator, Func<GridLength, DefinitionBase> activator)
    {
        int CollectionLength = hasSeparator ? collection.Count - (collection.Count / 5) : collection.Count;

        if (CollectionLength < length)
        {
            for (int i = CollectionLength; i < length; i++)
            {
                int InsertionIndex;

                if (hasSeparator && (i % 4 == 0) && i > 0)
                {
                    GridLength SeparatorGridLength = new(1, GridUnitType.Star);
                    DefinitionBase SeparatorDefinition = activator(SeparatorGridLength);

                    InsertionIndex = collection.Add(SeparatorDefinition);
                    Debug.Assert(InsertionIndex >= 0);
                }

                GridLength NewItemGridLength = new(hasSeparator ? 2 : 1, GridUnitType.Star);
                DefinitionBase NewItemDefinition = activator(NewItemGridLength);

                InsertionIndex = collection.Add(NewItemDefinition);
                Debug.Assert(InsertionIndex >= 0);
            }
        }
        else
        {
            while (CollectionLength > length)
            {
                collection.RemoveAt(collection.Count - 1);
                CollectionLength = collection.Count - (collection.Count / 5);
            }
        }
    }

    private void Populate(BidimensionalArray<EyeCircleType> modeArray, BidimensionalArray<Brush> foregroundArray, BidimensionalArray<string?> toolTipArray, BidimensionalArray<bool> maskArray, BidimensionalArray<bool> highlightArray, int lengthX, int lengthY)
    {
        UpdateColumnRowCollection(InternalGrid.ColumnDefinitions, lengthX, hasSeparator: true, (GridLength gridLength) => new ColumnDefinition() { Width = gridLength });
        UpdateColumnRowCollection(InternalGrid.RowDefinitions, lengthY, hasSeparator: false, (GridLength gridLength) => new RowDefinition() { Height = gridLength });

        List<EyeCircleControl> AddedControlList = new();
        UIElementCollection Children = InternalGrid.Children;
        const int SelectionControlCount = 1;

        for (int j = 0; j < lengthY; j++)
        {
            for (int i = 0; i < lengthX; i++)
            {
                int ChildPosition = (j * lengthX) + i;

                EyeCircleControl Control;
                if (ChildPosition < Children.Count - SelectionControlCount)
                    Control = (EyeCircleControl)Children[ChildPosition];
                else
                {
                    Control = new EyeCircleControl();
                    Children.Insert(Children.Count - SelectionControlCount, Control);

                    Control.MouseLeftButtonDown += OnMouseLeftButtonDown;
                }

                UpdateControl(Control, modeArray, foregroundArray, toolTipArray, maskArray, highlightArray, i, j);
            }
        }

        while (Children.Count - SelectionControlCount > (lengthX * lengthY))
            Children.RemoveAt(Children.Count - SelectionControlCount - 1);
    }

    private static void UpdateControl(EyeCircleControl control, BidimensionalArray<EyeCircleType> modeArray, BidimensionalArray<Brush> foregroundArray, BidimensionalArray<string?> toolTipArray, BidimensionalArray<bool> maskArray, BidimensionalArray<bool> highlightArray, int x, int y)
    {
        control.Type = maskArray.At(x, y) ? modeArray.At(x, y) : EyeCircleType.Empty;
        control.ToolTip = toolTipArray.At(x, y);

        Brush ControlForeground = foregroundArray.At(x, y);

        if (x < highlightArray.LengthX && y < highlightArray.LengthY && highlightArray.At(x, y) == true && ControlForeground is SolidColorBrush AsSolidColorBrush)
            control.Foreground = CreateAnimatedBrush(AsSolidColorBrush.Color);
        else
            control.Foreground = ControlForeground;

        int ConvertedX = x + (x / 4);
        Grid.SetColumn(control, ConvertedX);
        Grid.SetRow(control, y);
    }

    private static Brush CreateAnimatedBrush(Color color)
    {
        ColorAnimation Animation = new()
        {
            From = Colors.Transparent,
            To = color,
            Duration = new Duration(TimeSpan.FromSeconds(0.5)),
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever,
        };

        Animation.Completed += new EventHandler(OnAnimationCompleted);
        SolidColorBrush Brush = new(Colors.Transparent);
        Animation.AccelerationRatio = 0.5;

        Brush.BeginAnimation(SolidColorBrush.ColorProperty, Animation);
        return Brush;
    }

    private static void OnAnimationCompleted(object? sender, EventArgs e)
    {
    }
    #endregion
}
