namespace BlazorWpfCommonControls.Test;

using System.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestEyeCircleControl
{
    [Test]
    public void TestSimpleLoad()
    {
        TestTools.StaThreadWrapper(() =>
        {
            EyeCircleControl Control = new();
            var Popup = TestTools.LoadControl(Control);
            Control.Type = EyeCircleType.Closed;
            Thread.Sleep(100);
            Control.Type = EyeCircleType.Mixed;
            Thread.Sleep(100);
            Control.Type = EyeCircleType.Open;
            TestTools.UnloadControl(Popup);
        });
    }
}
