namespace BlazorWpfCommonControls.Test;

using System;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestEyeCirclePanel
{
    [Test]
    public void TestNullTypeArray()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.TypeArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.TypeArray)));
            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestNullForegroundArray()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.ForegroundArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.ForegroundArray)));
            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestNullToolTipArray()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.ToolTipArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.ToolTipArray)));
            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestMaskToolTipArray()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.MaskArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.MaskArray)));
            TestTools.UnloadControl(Popup);
        });
    }

    [Test]
    public void TestHighlightToolTipArray()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.HighlightArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.HighlightArray)));
            TestTools.UnloadControl(Popup);
        });
    }
}
