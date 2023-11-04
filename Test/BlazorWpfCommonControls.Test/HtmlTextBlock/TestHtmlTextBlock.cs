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
            Control.HtmlFormattedText = "<h1>History of Psi Mantises</h1> <h2>Dawn of the Perfect Species</h2>\n\n<i>By Maletaxis</i>\n\n<h2>The First Era</h2>\n\nOur creator, the great wizard Dalvos, spent years perfecting his design for psychic mantises. His work began approximately six years ago in the wilds of Eltibule and Sedgwick Forest, wildernesses of little cultural importance. He noticed that the area was home to giant mantises, and wondered if he could make them intelligent enough to be good servants to him. Thus began Revision 1.\n\nWe have Dalvos's notes for each revision of psychic mantis, but they are sparse and often use cryptic abbreviations. We do not know exactly what changed between each revision; we can only conjecture from contextual clues. But we do know that the first forty-four revisions were failures: the resulting creatures were not sufficiently intelligent and were released into the wilds of Eltibule.\n\nHis notes for revision 72 indicate satisfaction with the species' intellect. After that, he turned to improving their utility by adding psychic powers. His notes for revision 108 indicate success: the new generation's psychic powers bred true, and all individuals had at least some psychic abilities.\n\nThese mantises, collectively called the \"first-era\" mantises, are capable of telepathic communication, have psychically-enhanced senses, and can usually manifest their willpower as a psychic attack. Many individuals have other powers, but these additional powers are not passed on to their descendants.\n\nRed Wing mantises are perhaps the most important first-era mantises. It is believed they descend from members of the 60th, 62nd, and 63rd revisions. The Veiny Mantises are also first-era (of unknown revision). \n\nFirst-era mantises can be recognized by their veiny wings. They are stronger and more resilient than later mantids, but their psychic powers are weak, comparable perhaps to a gifted psychic elf.\n\n<h2>The Second Era</h2>\n\nRevisions from 72 to 140 are called \"second era\" mantises. This era saw the development of the psilobe, a special portion of the mantis brain designed to enhance our psychic powers. These mantises were unfortunately unstable: their primitive psilobes caused eventual brain damage and most suffered from schizophrenia and paranoia. \n\nWe do not know the fate of most second era mantises. They were released into the wilds of Eltibule, and may have wandered anywhere. But we presume that most are dead. Three important exceptions are the \"cave mantises\" (from the relatively stable revision #108), the Yellow Mantids, known for their explosive powers and extreme instability, and the Tragic Tree Mantises of Sedgewick Forest (TTMSFs).\n\nSecond-era mantises are visually recognizable by their single-color carapaces. Because their psilobes behave unpredictably, many -- perhaps most -- of these mantises have unique and bizarre psychic gifts. This makes their mental instability all the more tragic. It also makes them horrifically dangerous.\n\n<h2>The Third Era</h2>\n\nRevisions from 221 onwards are called \"third era\" or \"true\" psychic mantises. Having perfected the psilobe, Dalvos focused on improving temperament, intellect, longevity, memory, and dexterity. Many mantises from generation 263 onwards have reliable short-distance flight.\n\nThird-era mantises are visually distinguishable by their elegant pinkish hue and translucent wings.\n\n<h2>The End of Revisions</h2>\n\nThen, having apparently perfected the design of the psi-mantis, Dalvos left. We do not know why. He had amassed an army of thousands of loyal mantises. We expected an opportunity to defend our creator against the many evil bipeds that want him destroyed, but he had different plans. He simply set us free. His parting words are ingrained into our memories:\n\n<indent=15><i>\"Okay everybody, I have an announcement: I have to go, and I won't be coming back. You guys have been great. All of you! You're all free now, and I hope you have wonderful lives. Create amazing cultures. Dominate the world, maybe! Hah! Thanks for everything, but listen: don't follow me. That's an order. And take care of the brain-bugs, okay?\"</i></indent>\n\nThese sacred words are a comfort to us in difficult times. Dalvos encoded many instructions in his final missive, and some of us believe his words hide further secrets that we will only understand when we are ready.\n\nTruly Dalvos is a genius. If he has not yet ascended to godhood, we expect that he will inevitably do so in time. And we are evidence of why! Psi-mantises are just one of the five known species Dalvos has created. Is there anything more godly than creating new forms of life? The answer is no.";

            var Popup = TestTools.LoadControl(Control);
            TestTools.UnloadControl(Popup);
        });

        Assert.IsTrue(Success);
    }
}
