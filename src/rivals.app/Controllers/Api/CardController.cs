using Microsoft.AspNetCore.Mvc;
using rivals.domain.Game.Cards;
using rivals.logic.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private CardManager _cardManger { get; set; }

        public CardController(CardManager cardManager)
        {
            _cardManger = cardManager;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _cardManger.GetAllCards();
        }

        [HttpGet("[action]")]
        public async Task<Card> GetByName(String cardName)
        {
            return await _cardManger.GetCardByName(cardName);
        }

        [HttpPost("[action]")]
        public async Task<Boolean> Upsert(Card card)
        {
            return null;// await _cardManger.InsertOrUpdateCard(card);
        }

        [HttpPost("[action]")]
        public async Task<Boolean> Delete(String id)
        {
            return await _cardManger.DeleteCard(id);
        }

    }
}
