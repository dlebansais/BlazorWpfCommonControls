namespace BlazorWpfCommonControls.Test;

using System;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public class TestEyeCircleControl
{
    [Test]
    [STAThread]
    public void TestSimpleLoad()
    {
        TestTools.StaThreadWrapper(() =>
        {
            var Popup = TestTools.LoadControl(new EyeCircleControl());
            TestTools.UnloadControl(Popup);
        });
    }
}
