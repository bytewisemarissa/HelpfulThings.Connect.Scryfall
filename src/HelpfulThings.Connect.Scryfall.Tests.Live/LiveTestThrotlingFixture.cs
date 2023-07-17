namespace HelpfulThings.Connect.Scryfall.Tests.Live;

public class LiveTestThrotlingFixture
{
    [TearDown]
    public void CleanUp()
    {
        Thread.Sleep(100);
    }
}