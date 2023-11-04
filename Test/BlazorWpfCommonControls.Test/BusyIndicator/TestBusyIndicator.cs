namespace BlazorWpfCommonControls.Test;

using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestBusyIndicator
{
    [Test]
    public void TestSimpleLoad()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            BusyIndicator Control = new();
            var Popup = TestTools.LoadControl(Control);
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
