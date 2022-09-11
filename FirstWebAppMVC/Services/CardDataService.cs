using Bogus;
using FirstWebAppMVC.Models;

namespace FirstWebAppMVC.Services
{
    public class CardDataService
    {
        static List<CardModel> list = new List<CardModel>();

        public List<CardModel> GetAllCards()
        {
            if (list.Count == 0)
            {
                // Generate fake cards

                list.Add(new CardModel
                {
                    Id = 2492001,
                    Name = "Ash Blossom & Joyous Spring",
                    Type = "Monster",
                    Effect = "Negate any effect that would search.",
                    ReleaseDate = new DateTime(2022, 1, 19)
                });
                list.Add(new CardModel
                {
                    Id = 2492002,
                    Name = "Raigeki",
                    Type = "Spell",
                    Effect = "Destroy all monsters your opponent controls.",
                    ReleaseDate = new DateTime(2022, 1, 19)
                });

                string[] cardTypes = new string[3] { "Monster", "Spell", "Trap" };

                for (int i = 2; i < 50; i++)
                {
                    list.Add(new Faker<CardModel>()
                        .RuleFor(c => c.Id, f => f.Random.Number(1000000, 9999999))
                        .RuleFor(c => c.Name, f => 
                        ( (f.Random.Float() > 0.2 ? f.Commerce.ProductAdjective() : "") + " " + f.Random.Word()
                        + ( f.Random.Float() > 0.4 ? (" of " + f.Commerce.Department()) : ("") ) ))
                        .RuleFor(c => c.Type, f => f.PickRandom(cardTypes))
                        .RuleFor(c => c.Effect, f => f.Company.Bs())
                        .RuleFor(c => c.ReleaseDate, f => f.Date.Recent())
                        );
                }

            }

            return list;

        }    
    }
}
