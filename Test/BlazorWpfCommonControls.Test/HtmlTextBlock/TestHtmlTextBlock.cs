namespace BlazorWpfCommonControls.Test;

using CustomControls.BlazorWpfCommon;
using NUnit.Framework;

public partial class TestHtmlTextBlock
{
    [Test]
    public void TestSimpleLoad()
    {
        bool Success = TestTools.StaThreadWrapper(() =>
        {
            HtmlTextBlock Control = new();
            Control.HtmlFormattedText = @"<h1>History of Psi Mantises</h1> <h2>Dawn of the Perfect Species</h2>

<br><hr><hr><i>By Maletaxis</i>
<indent=15><i><b><em>By Maletaxis</em></b></i>

<h2>The First Era</h2>

<span></span><span style=""color:blue"">Our creator</span>
<span style=""color:red"">Our creator</span>
<span style=""color:lightgreen"">Our creator</span>
<span style=""color:white"">Our creator</span>
<span style=""color:#FFFFFFFF"">Our creator</span>
<span style=""color:?FFFFFFFF"">Our creator</span>
<span style=""color:#FFFFFF"">Our creator</span>
<span style=""other:unknown"">Our creator</span>
<span style="""">Our creator</span>
, the great wizard Dalvos. Thus began Revision 1.
The answer is no.
<unexpected></unexpected>
";

            var Popup = TestTools.LoadControl(Control);
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
