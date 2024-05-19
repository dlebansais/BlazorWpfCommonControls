namespace CustomControls.BlazorWpfCommon;

using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

/// <summary>
/// Represents a <see cref="TextBlock"/> that can use a subset of HTML formats.
/// </summary>
public class HtmlTextBlock : TextBlock
{
    #region Constants and types
    private struct TitleFormat
    {
        public double FontSize { get; set; }
        public string NewLines { get; set; }
    }

    private static readonly TitleFormat Level1 = new() { FontSize = 32, NewLines = "\n" };
    private static readonly TitleFormat Level2 = new() { FontSize = 24, NewLines = "\n" };
    private static readonly TitleFormat Normal = new() { FontSize = 16, NewLines = string.Empty };

    private struct Format
    {
        public TitleFormat Title { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }
        public string Indentation { get; set; }
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the HTML-formatted text.
    /// </summary>
    public string? HtmlFormattedText
    {
        get { return (string?)GetValue(HtmlFormattedTextProperty); }
        set { SetValue(HtmlFormattedTextProperty, value); }
    }

    /// <summary>
    /// The dependency property.
    /// </summary>
    public static readonly DependencyProperty HtmlFormattedTextProperty = DependencyProperty.Register("HtmlFormattedText", typeof(string), typeof(HtmlTextBlock), new UIPropertyMetadata(null, OnHtmlFormattedTextChanged));

    private static void OnHtmlFormattedTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        HtmlTextBlock Ctrl = (HtmlTextBlock)sender;
        Ctrl.OnHtmlFormattedTextChanged(args.NewValue as string);
    }

    private void OnHtmlFormattedTextChanged(string? newValue)
    {
        Inlines.Clear();

        if (newValue is not null)
        {
            int StartIndex = 0;
            bool HasNewLine = true;
            Span FormattedText = ParseText(newValue, ref StartIndex, string.Empty, new Format() { Title = Normal, Indentation = string.Empty }, ref HasNewLine);

            Inlines.Add(FormattedText);
        }
    }
    #endregion

    #region Html parsing
    private static Span ParseText(string text, ref int startIndex, string endTag, Format format, ref bool hasNewLine)
    {
        Span Result = new();
        int searchIndex = startIndex;

        while (searchIndex < text.Length)
            if (ParseTextPart(text, ref Result, ref startIndex, ref searchIndex, endTag, format, ref hasNewLine))
                return Result;

        return Result;
    }

    private static bool ParseTextPart(string text, ref Span result, ref int startIndex, ref int searchIndex, string endTag, Format format, ref bool hasNewLine)
    {
        int Index = text.IndexOf('<', searchIndex);
        if (Index < 0 || (Index >= 0 && Index + 1 < text.Length && text[Index + 1] == ' '))
        {
            AddRun(result.Inlines, text, startIndex, text.Length, format, ref hasNewLine);

            startIndex = text.Length;
            searchIndex = startIndex;
        }
        else if (endTag.Length > 0 && Index + endTag.Length <= text.Length && text.Substring(Index, endTag.Length) == endTag)
        {
            if (startIndex < Index)
                AddRun(result.Inlines, text, startIndex, Index, format, ref hasNewLine);

            startIndex = Index + endTag.Length;
            return true;
        }
        else if (Index + 4 <= text.Length && text.Substring(Index, 4) == "<br>")
        {
            searchIndex = Index + 1;
        }
        else if (Index + 4 <= text.Length && text.Substring(Index, 4) == "<hr>")
        {
            ParseSectionSeparator(text, Index, ref result, ref startIndex, ref searchIndex, endTag, format, ref hasNewLine);
        }
        else if (Index + 5 <= text.Length && text.Substring(Index, 5) == "<span")
        {
            if (startIndex < Index)
                AddRun(result.Inlines, text, startIndex, Index, format, ref hasNewLine);

            Run Nested = ParseSpan(text, ref Index);
            Nested.FontSize = format.Title.FontSize;
            result.Inlines.Add(Nested);

            startIndex = Index;
            searchIndex = startIndex;
        }
        else
            ParseSpecialText(text, Index, ref result, ref startIndex, ref searchIndex, format, ref hasNewLine);

        return false;
    }

    private static void ParseSectionSeparator(string text, int index, ref Span result, ref int startIndex, ref int searchIndex, string endTag, Format format, ref bool hasNewLine)
    {
        if (startIndex < index)
            AddRun(result.Inlines, text, startIndex, index, format, ref hasNewLine);

        Run Separator = new("~~~~");
        Separator.FontSize = format.Title.FontSize;
        result.Inlines.Add(Separator);
        result.Inlines.Add(new LineBreak());

        startIndex = index + 4;
        searchIndex = startIndex;
    }

    private static void ParseSpecialText(string text, int index, ref Span result, ref int startIndex, ref int searchIndex, Format format, ref bool hasNewLine)
    {
        if (!ParseSpecialText(text, result, index, ref startIndex, ref searchIndex, "<h1>", "</h1>", format, new Format() { Title = Level1, IsBold = true, IsItalic = format.IsItalic, IsUnderline = format.IsUnderline, Indentation = format.Indentation }, ref hasNewLine) &&
            !ParseSpecialText(text, result, index, ref startIndex, ref searchIndex, "<h2>", "</h2>", format, new Format() { Title = Level2, IsBold = format.IsBold, IsItalic = format.IsItalic, IsUnderline = true, Indentation = format.Indentation }, ref hasNewLine) &&
            !ParseSpecialText(text, result, index, ref startIndex, ref searchIndex, "<indent=15>", "</indent>", format, new Format() { Title = Normal, IsBold = format.IsBold, IsItalic = format.IsItalic, IsUnderline = format.IsUnderline, Indentation = "               " }, ref hasNewLine) &&
            !ParseSpecialText(text, result, index, ref startIndex, ref searchIndex, "<b>", "</b>", format, new Format() { Title = Normal, IsBold = true, IsItalic = format.IsItalic, IsUnderline = format.IsUnderline, Indentation = format.Indentation }, ref hasNewLine) &&
            !ParseSpecialText(text, result, index, ref startIndex, ref searchIndex, "<i>", "</i>", format, new Format() { Title = Normal, IsBold = format.IsBold, IsItalic = true, IsUnderline = format.IsUnderline, Indentation = format.Indentation }, ref hasNewLine) &&
            !ParseSpecialText(text, result, index, ref startIndex, ref searchIndex, "<em>", "</em>", format, new Format() { Title = Normal, IsBold = format.IsBold, IsItalic = true, IsUnderline = format.IsUnderline, Indentation = format.Indentation }, ref hasNewLine))
        {
            string TagText = text.Length >= searchIndex + 10 ? text.Substring(searchIndex, 10) : text.Substring(searchIndex, text.Length - searchIndex);
            Debug.WriteLine($"WARNING Unexpected tag: <{TagText}");

            searchIndex = index + 1;
        }
    }

    private static bool ParseSpecialText(string text, Span span, int index, ref int startIndex, ref int searchIndex, string startTag, string endTag, Format oldFormat, Format newFormat, ref bool hasNewLine)
    {
        if (index + startTag.Length <= text.Length && text.Substring(index, startTag.Length) == startTag)
        {
            if (index > startIndex)
                AddRun(span.Inlines, text, startIndex, index, oldFormat, ref hasNewLine);

            startIndex = index + startTag.Length;
            Span SubText = ParseText(text, ref startIndex, endTag, newFormat, ref hasNewLine);

            if (SubText.Inlines.Count > 0)
                span.Inlines.Add(SubText);

            searchIndex = startIndex;
            return true;
        }
        else
            return false;
    }

    private static void AddRun(InlineCollection inlines, string text, int startIndex, int endIndex, Format format, ref bool hasNewLine)
    {
        string RunText = text.Substring(startIndex, endIndex - startIndex);

        if (format.Title.NewLines.Length > 0)
        {
            if (!hasNewLine)
                RunText = "\n" + RunText;

            RunText = RunText + format.Title.NewLines;
            hasNewLine = true;
        }
        else
        {
            if (hasNewLine && RunText.Length > 0 && RunText[0] == '\n')
                RunText = RunText.Substring(1);

            if (format.Indentation.Length > 0)
            {
                if (!hasNewLine)
                    RunText = $"\n{format.Indentation}{RunText}";
                else
                    RunText = $"{format.Indentation}{RunText}";

#if NET5_0_OR_GREATER
                RunText = RunText.Replace("<br> ", $"\n{format.Indentation}", StringComparison.InvariantCulture);
#else
                RunText = RunText.Replace("<br> ", $"\n{format.Indentation}");
#endif
            }

            int NonSpaceIndex = RunText.Length - 1;
            while (NonSpaceIndex >= 0 && RunText[NonSpaceIndex] == ' ')
                NonSpaceIndex--;

            hasNewLine = NonSpaceIndex >= 0 && RunText[NonSpaceIndex] == '\n';
        }

        Debug.Assert(RunText.Length > 0);

        Run NewElement = new(RunText);

        NewElement.FontSize = format.Title.FontSize;

        if (format.IsBold)
            NewElement.FontWeight = FontWeights.Bold;

        if (format.IsItalic)
            NewElement.FontStyle = FontStyles.Italic;

        if (format.IsUnderline)
            inlines.Add(new Underline(NewElement));
        else
            inlines.Add(NewElement);
    }

    private static Run ParseSpan(string text, ref int index)
    {
        Run Result = new();

        index += 5;

        int StartIndex = index;
        while (StartIndex + 1 < text.Length && text[StartIndex] != '>')
            StartIndex++;

        if (TryParseSpanForeground(text, index, StartIndex, out Brush Foreground))
            Result.Foreground = Foreground;

        int EndIndex = StartIndex + 1;
        index = EndIndex;
        while (EndIndex + 7 < text.Length && text.Substring(EndIndex, 7) != "</span>")
        {
            EndIndex++;
            index = EndIndex + 7;
        }

        string Content;

        if (StartIndex + 1 <= text.Length)
            Content = text.Substring(StartIndex + 1, EndIndex - StartIndex - 1);
        else
            Content = text;

        Result.Text = Content;

        return Result;
    }

    private static bool TryParseSpanForeground(string text, int index, int startIndex, out Brush foreground)
    {
        string SpanClass = text.Substring(index, startIndex - index).Trim();
        if (SpanClass.Length > 8 && SpanClass.StartsWith("style=\"", StringComparison.Ordinal) &&
#if NETFRAMEWORK
            SpanClass.EndsWith("\"", StringComparison.Ordinal))
#else
            SpanClass.EndsWith('"'))
#endif
        {
            string SpanStyle = SpanClass.Substring(7, SpanClass.Length - 8);
            if (SpanStyle.StartsWith("color:", StringComparison.Ordinal))
            {
                string SpanColor = SpanStyle.Substring(6).Trim();

                switch (SpanColor)
                {
                    case "red":
                        foreground = Brushes.Red;
                        return true;
                    case "lightgreen":
                        foreground = Brushes.LightGreen;
                        return true;
                    case "white":
                        foreground = Brushes.White;
                        return true;
                    default:
                        return TryParseSpanColor(SpanColor, out foreground);
                }
            }
        }

        foreground = Brushes.Transparent;
        return false;
    }

    private static bool TryParseSpanColor(string spanColor, out Brush foreground)
    {
        if (spanColor.Length == 9 && spanColor[0] == '#')
        {
            _ = byte.TryParse(spanColor.Substring(1, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte R);
            _ = byte.TryParse(spanColor.Substring(3, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte G);
            _ = byte.TryParse(spanColor.Substring(5, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte B);
            _ = byte.TryParse(spanColor.Substring(7, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out byte A);
            foreground = new SolidColorBrush(Color.FromArgb(A, R, G, B));
            return true;
        }

        foreground = Brushes.Transparent;
        return false;
    }
    #endregion
}
