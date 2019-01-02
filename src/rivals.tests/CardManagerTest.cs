using Microsoft.Extensions.DependencyInjection;
using rivals.domain.Game.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rivals.tests
{
    public class CardManagerTest : IClassFixture<DependencyInjectionClassFixture>
    {
        [Fact]
        public async Task Test1()
        {
            var manager = DIFixture.ServiceProvider.GetService<logic.Game.CardManager>();

            var card = new Card();
            card.Name = "Jab";
            card.Movement = new Movement();
            card.Movement.Magnitude = 0;
            card.Movement.Type = MovementType.Neutral;
            card.Defense = new Defense();
            card.Defense.Magnitude = 0;
            card.Defense.Type = DefenseType.Neutral;
            card.Damage = new Damage();
            card.Damage.Magnitude = 3;
            card.Damage.Type = DamageType.Physical;

            var saved = await manager.InsertOrUpdateCard(card);
        }

        [Fact]
        public async Task Test2()
        {
            var manager = DIFixture.ServiceProvider.GetService<logic.Game.CardManager>();

            var cardName = "Strike";
            var retreived = await manager.GetCardByName(cardName);

            Assert.NotNull(retreived);
        }

        [Fact]
        public async Task Test3()
        {
            var manager = DIFixture.ServiceProvider.GetService<logic.Game.CardManager>();
            var cards = await manager.GetAllCards();

            Assert.NotNull(cards);
            Assert.NotEmpty(cards);
        }

        public CardManagerTest(DependencyInjectionClassFixture fixture)
        {
            this.DIFixture = fixture;
        }

        DependencyInjectionClassFixture DIFixture { get; set; }
    }
}
