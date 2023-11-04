namespace BlazorWpfCommonControls.Test;

using System.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestEyeCircleControl
{
    [Test]
    public void TestSimpleLoad()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            EyeCircleControl Control = new();
            var Popup = TestTools.LoadControl(Control);
            Control.Type = EyeCircleType.Closed;
            Assert.That(Control.Type, Is.EqualTo(EyeCircleType.Closed));
            Thread.Sleep(100);
            Control.Type = EyeCircleType.Mixed;
            Assert.That(Control.Type, Is.EqualTo(EyeCircleType.Mixed));
            Thread.Sleep(100);
            Control.Type = EyeCircleType.Open;
            Assert.That(Control.Type, Is.EqualTo(EyeCircleType.Open));
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
