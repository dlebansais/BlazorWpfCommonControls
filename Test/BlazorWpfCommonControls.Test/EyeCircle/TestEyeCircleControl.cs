namespace BlazorWpfCommonControls.Test;

using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public class TestEyeCircleControl
{
    [Test]
    public void TestSimpleLoad()
    {
        TestTools.StaThreadWrapper(() =>
        {
            var Popup = TestTools.LoadControl(new EyeCircleControl());
            TestTools.UnloadControl(Popup);
        });
    }
}
