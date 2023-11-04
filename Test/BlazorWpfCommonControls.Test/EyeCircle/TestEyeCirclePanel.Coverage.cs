namespace BlazorWpfCommonControls.Test;

using System;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestEyeCirclePanel
{
    [Test]
    public void TestNullTypeArray()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.TypeArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.TypeArray)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestNullForegroundArray()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.ForegroundArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.ForegroundArray)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestNullToolTipArray()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.ToolTipArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.ToolTipArray)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestMaskToolTipArray()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.MaskArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.MaskArray)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }

    [Test]
    public void TestHighlightToolTipArray()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            EyeCirclePanel Panel = new();
            var Popup = TestTools.LoadControl(Panel);
            ArgumentException Exception = Assert.Throws<ArgumentException>(() => Panel.HighlightArray = null!);
            Assert.That(Exception.Message, Is.EqualTo(nameof(EyeCirclePanel.HighlightArray)));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
