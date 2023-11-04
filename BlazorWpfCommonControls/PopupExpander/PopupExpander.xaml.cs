namespace CustomControls.BlazorWpfCommon;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

/// <summary>
/// Interaction logic for PopupExpander.xaml.
/// </summary>
public partial class PopupExpander : UserControl, INotifyPropertyChanged
{
    #region Init
    /// <summary>
    /// Initializes a new instance of the <see cref="PopupExpander"/> class.
    /// </summary>
    public PopupExpander()
    {
        InitializeComponent();

        if (Application.Current is Application CurrentApp)
            CurrentApp.Deactivated += OnDeactivated;

        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        ControlList.Add(Control);
    }

    private void OnUnloaded(object sender, RoutedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        _ = ControlList.Remove(Control);
    }

    private static readonly List<PopupExpander> ControlList = new();
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets a value indicating whether the control is expanded.
    /// </summary>
    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    /// <summary>
    /// The IsExpanded dependency property.
    /// </summary>
    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(PopupExpander), new UIPropertyMetadata(false, OnIsExpandedChanged));

    private static void OnIsExpandedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        bool NewIsExpanded = (bool)args.NewValue;

        Control.OnIsExpandedChanged(NewIsExpanded);
    }

    /// <summary>
    /// Called when the IsExpanded property has changed.
    /// </summary>
    /// <param name="newIsExpanded">The new value.</param>
    public virtual void OnIsExpandedChanged(bool newIsExpanded)
    {
        if (newIsExpanded)
        {
            foreach (PopupExpander Control in ControlList)
                if (Control != this)
                    Control.IsExpanded = false;
        }
    }

    /// <summary>
    /// Gets or sets the header.
    /// </summary>
    public string Header
    {
        get { return (string)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }

    /// <summary>
    /// The Header dependency property.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(PopupExpander), new UIPropertyMetadata(string.Empty, OnHeaderChanged));

    private static void OnHeaderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        if (args.NewValue is not string NewHeader)
            throw new ArgumentException(nameof(Header));

        Control.OnHeaderChanged(NewHeader);
    }

    /// <summary>
    /// Called when the Header property has changed.
    /// </summary>
    /// <param name="newHeader">The new value.</param>
    public virtual void OnHeaderChanged(string newHeader)
    {
        NotifyPropertyChanged(nameof(HeaderMargin));
    }

    /// <summary>
    /// Gets or sets the popup content.
    /// </summary>
    public new object? Content
    {
        get { return GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }

    /// <summary>
    /// The Content dependency property.
    /// </summary>
    public static readonly new DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(PopupExpander), new UIPropertyMetadata(null, OnContentChanged));

    private static void OnContentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        Control.OnContentChanged(args.NewValue);
    }

    /// <summary>
    /// Called when the Content property has changed.
    /// </summary>
    /// <param name="newContent">The new value.</param>
    public virtual void OnContentChanged(object? newContent)
    {
    }

    /// <summary>
    /// Gets or sets the popup content template.
    /// </summary>
    public new DataTemplate ContentTemplate
    {
        get { return (DataTemplate)GetValue(ContentTemplateProperty); }
        set { SetValue(ContentTemplateProperty, value); }
    }

    /// <summary>
    /// The ContentTemplate dependency property.
    /// </summary>
    public static readonly new DependencyProperty ContentTemplateProperty = DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(PopupExpander), new UIPropertyMetadata(new DataTemplate(), OnContentTemplateChanged));

    private static void OnContentTemplateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        if (args.NewValue is not DataTemplate NewContentTemplate)
            throw new ArgumentException(nameof(ContentTemplate));

        Control.OnContentTemplateChanged(NewContentTemplate);
    }

    /// <summary>
    /// Called when the ContentTemplate property has changed.
    /// </summary>
    /// <param name="newContentTemplate">The new value.</param>
    public virtual void OnContentTemplateChanged(DataTemplate newContentTemplate)
    {
    }

    /// <summary>
    /// Gets or sets the popup width.
    /// </summary>
    public double PopupWidth
    {
        get { return (double)GetValue(PopupWidthProperty); }
        set { SetValue(PopupWidthProperty, value); }
    }

    /// <summary>
    /// The PopupWidth dependency property.
    /// </summary>
    public static readonly DependencyProperty PopupWidthProperty = DependencyProperty.Register("PopupWidth", typeof(double), typeof(PopupExpander), new UIPropertyMetadata(double.NaN, OnPopupWidthChanged));

    private static void OnPopupWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        double NewPopupWidth = (double)args.NewValue;

        Control.OnPopupWidthChanged(NewPopupWidth);
    }

    /// <summary>
    /// Called when the PopupWidth property has changed.
    /// </summary>
    /// <param name="newPopupWidth">The new value.</param>
    public virtual void OnPopupWidthChanged(double newPopupWidth)
    {
    }

    /// <summary>
    /// Gets or sets the popup height.
    /// </summary>
    public double PopupHeight
    {
        get { return (double)GetValue(PopupHeightProperty); }
        set { SetValue(PopupHeightProperty, value); }
    }

    /// <summary>
    /// The PopupHeight dependency property.
    /// </summary>
    public static readonly DependencyProperty PopupHeightProperty = DependencyProperty.Register("PopupHeight", typeof(double), typeof(PopupExpander), new UIPropertyMetadata(double.NaN, OnPopupHeightChanged));

    private static void OnPopupHeightChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        double NewPopupHeight = (double)args.NewValue;

        Control.OnPopupHeightChanged(NewPopupHeight);
    }

    /// <summary>
    /// Called when the PopupHeight property has changed.
    /// </summary>
    /// <param name="newPopupHeight">The new value.</param>
    public virtual void OnPopupHeightChanged(double newPopupHeight)
    {
    }

    /// <summary>
    /// Gets or sets the horizontal offset.
    /// </summary>
    public double HorizontalOffset
    {
        get { return (double)GetValue(HorizontalOffsetProperty); }
        set { SetValue(HorizontalOffsetProperty, value); }
    }

    /// <summary>
    /// The HorizontalOffset dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(PopupExpander), new UIPropertyMetadata(0.0, OnHorizontalOffsetChanged));

    private static void OnHorizontalOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        double NewHorizontalOffset = (double)args.NewValue;

        Control.OnHorizontalOffsetChanged(NewHorizontalOffset);
    }

    /// <summary>
    /// Called when the HorizontalOffset property has changed.
    /// </summary>
    /// <param name="newHorizontalOffset">The new value.</param>
    public virtual void OnHorizontalOffsetChanged(double newHorizontalOffset)
    {
    }

    /// <summary>
    /// Gets or sets the vertical offset.
    /// </summary>
    public double VerticalOffset
    {
        get { return (double)GetValue(VerticalOffsetProperty); }
        set { SetValue(VerticalOffsetProperty, value); }
    }

    /// <summary>
    /// The VerticalOffset dependency property.
    /// </summary>
    public static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset", typeof(double), typeof(PopupExpander), new UIPropertyMetadata(0.0, OnVerticalOffsetChanged));

    private static void OnVerticalOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        double NewVerticalOffset = (double)args.NewValue;

        Control.OnVerticalOffsetChanged(NewVerticalOffset);
    }

    /// <summary>
    /// Called when the VerticalOffset property has changed.
    /// </summary>
    /// <param name="newVerticalOffset">The new value.</param>
    public virtual void OnVerticalOffsetChanged(double newVerticalOffset)
    {
    }

    /// <summary>
    /// Gets or sets the button alignment.
    /// </summary>
    public HorizontalAlignment ButtonAlignment
    {
        get { return (HorizontalAlignment)GetValue(ButtonAlignmentProperty); }
        set { SetValue(ButtonAlignmentProperty, value); }
    }

    /// <summary>
    /// The ButtonAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty ButtonAlignmentProperty = DependencyProperty.Register("ButtonAlignment", typeof(HorizontalAlignment), typeof(PopupExpander), new UIPropertyMetadata(HorizontalAlignment.Left, OnButtonAlignmentChanged));

    private static void OnButtonAlignmentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        PopupExpander Control = (PopupExpander)sender;
        HorizontalAlignment NewButtonAlignment = (HorizontalAlignment)args.NewValue;

        Control.OnButtonAlignmentChanged(NewButtonAlignment);
    }

    /// <summary>
    /// Called when the ButtonAlignment property has changed.
    /// </summary>
    /// <param name="newButtonAlignment">The new value.</param>
    public void OnButtonAlignmentChanged(HorizontalAlignment newButtonAlignment)
    {
        switch (newButtonAlignment)
        {
            default:
            case HorizontalAlignment.Left:
                HeaderButton.SetValue(DockPanel.DockProperty, Dock.Left);
                HeaderText.SetValue(DockPanel.DockProperty, Dock.Left);
                break;
            case HorizontalAlignment.Right:
                HeaderButton.SetValue(DockPanel.DockProperty, Dock.Right);
                HeaderText.SetValue(DockPanel.DockProperty, Dock.Right);
                break;
        }

        NotifyPropertyChanged(nameof(HeaderMargin));
    }

    /// <summary>
    /// Gets the header margin.
    /// </summary>
    public Thickness HeaderMargin
    {
        get
        {
            if (Header.Length == 0)
                return default;

            return ButtonAlignment switch
            {
                HorizontalAlignment.Right => new Thickness(0, 0, 5, 0),
                HorizontalAlignment.Left or
                HorizontalAlignment.Center or
                HorizontalAlignment.Stretch or _ => new Thickness(5, 0, 0, 0),
            };
        }
    }
    #endregion

    #region Events
#nullable disable annotations
    private void OnDeactivated(object sender, EventArgs args)
#nullable restore annotations
    {
        if (IsExpanded)
            IsExpanded = false;
    }

#pragma warning disable IDE0051 // Remove unused private members: called from xaml
    private CustomPopupPlacement[] OnCustomPopupPlacementCallback(Size popupSize, Size targetSize, Point offset)
#pragma warning restore IDE0051 // Remove unused private members
    {
        double HorizontalOffset = ButtonAlignment switch
        {
            HorizontalAlignment.Right => targetSize.Width - popupSize.Width,
            HorizontalAlignment.Left or
            HorizontalAlignment.Center or
            HorizontalAlignment.Stretch or _ => 0,
        };

        CustomPopupPlacement Placement = new(new Point(HorizontalOffset, targetSize.Height), PopupPrimaryAxis.None);
        return new CustomPopupPlacement[] { Placement };
    }
    #endregion

    #region Implementation of INotifyPropertyChanged
    /// <summary>
    /// Implements the PropertyChanged event.
    /// </summary>
#nullable disable annotations
    public event PropertyChangedEventHandler PropertyChanged;
#nullable restore annotations

    /// <summary>
    /// Notifies that a property has changed.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    internal void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
