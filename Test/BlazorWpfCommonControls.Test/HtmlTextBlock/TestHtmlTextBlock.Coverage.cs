namespace BlazorWpfCommonControls.Test;

using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestHtmlTextBlock
{
    [Test]
    public void TestNullText()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            HtmlTextBlock Control = new();

            Control.HtmlFormattedText = "Test";
            Assert.That(Control.HtmlFormattedText, Is.EqualTo("Test"));
            
            Control.HtmlFormattedText = null;
            Assert.That(Control.HtmlFormattedText, Is.Null);

            var Popup = TestTools.LoadControl(Control);
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestMiscText()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            HtmlTextBlock Control = new();
            Control.HtmlFormattedText = "<";

            var Popup = TestTools.LoadControl(Control);
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
