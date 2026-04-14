namespace HelpfulThings.Connect.Scryfall.Tests.Live;

public abstract class LiveTestThrottlingFixture
{
    [TearDown]
    public void CleanUp()
    {
        Thread.Sleep(100);
    }
}