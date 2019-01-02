using Microsoft.Extensions.DependencyInjection;
using rivals.domain.Game.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rivals.tests
{
    public class CardManagerTest
    {
        [Fact]
        public async Task Test1()
        {
            var services = TestHelper.GetServices();
            var manager = services.GetService<logic.Game.CardManager>();

            var card = new Card();
            card.Name = "Strike";
            card.Movement = new Movement();
            card.Movement.Magnitude = 0;
            card.Movement.Type = MovementType.Neutral;
            card.Defense = new Defense();
            card.Defense.Magnitude = 0;
            card.Defense.Type = DefenseType.Neutral;
            card.Damage = new Damage();
            card.Damage.Magnitude = 10;
            card.Damage.Type = DamageType.Physical;

            var saved = await manager.InsertCard(card);
        }

        [Fact]
        public async Task Test2()
        {
            var services = TestHelper.GetServices();
            var manager = services.GetService<logic.Game.CardManager>();

            var cardName = "Strike";
            var retreived = await manager.GetCardByName(cardName);

            Assert.NotNull(retreived);
        }
    }
}
