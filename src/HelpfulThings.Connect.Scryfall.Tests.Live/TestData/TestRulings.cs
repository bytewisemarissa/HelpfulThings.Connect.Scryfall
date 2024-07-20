using HelpfulThings.Connect.Scryfall.Enums;
using HelpfulThings.Connect.Scryfall.Models;

namespace HelpfulThings.Connect.Scryfall.Tests.Live.TestData;

public static class TestRulings
{
    public static readonly Dictionary<Guid, Ruling[]> Rulings = new()
    {
        {
            TestCards.DereviEmpyrialTactician.ScryfallId,
            [
                new Ruling()
                {
                    OracleId = new Guid("afa49a09-146f-4439-850e-dd1938c93cef"),
                    Source = Sources.Scryfall,
                    PublishedAt = new DateOnly(2015,1,19),
                    Comment = "Derevi, Empyrial Tactician is banned as a commander in Duel Commander format, but it may be part of your deck."
                },
                new Ruling()
                {
                    OracleId = new Guid("afa49a09-146f-4439-850e-dd1938c93cef"),
                    Source = Sources.WizardsOfTheCoast,
                    PublishedAt = new DateOnly(2020, 11, 10),
                    Comment = "You can activate Derevi's last ability only when it is in the command zone."
                },
                new Ruling()
                {
                    OracleId = new Guid("afa49a09-146f-4439-850e-dd1938c93cef"),
                    Source = Sources.WizardsOfTheCoast,
                    PublishedAt = new DateOnly(2020, 11, 10),
                    Comment = "When you activate Derevi's last ability, you're not casting Derevi as a spell. The ability can't be countered by something that counters only spells. The ability isn't subject to the commander tax, nor does it increase the tax if you cast Derevi from the command zone later in the game."
                }
            ]
        }
    };
}