namespace BlazorWpfCommonControls.Test;

using System.Threading;
using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestPopupExpander
{
    [Test]
    public void TestSimpleLoad()
    {
        TestTools.StaThreadWrapper(() =>
        {
            PopupExpander Control = new();
            var Popup = TestTools.LoadControl(Control);
            TestTools.UnloadControl(Popup);
        });
    }
}
