namespace BlazorWpfCommonControls.Test;

using System;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestPopupExpander
{
    [Test]
    public void TestNullHeader()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            PopupExpander Control = new();
            var Popup = TestTools.LoadControl(Control);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Control.Header = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(PopupExpander.Header)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestNullContentTemplate()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            PopupExpander Control = new();
            var Popup = TestTools.LoadControl(Control);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Control.ContentTemplate = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(PopupExpander.ContentTemplate)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
