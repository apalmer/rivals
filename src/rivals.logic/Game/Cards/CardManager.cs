using rivals.domain.Game;
using rivals.domain.Game.Cards;
using rivals.persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rivals.logic.Game
{
    public class CardManager
    {
        private ICardRepo _cardRepo;
        
        public CardManager(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }

        public Task<Boolean> InsertCard(Card card)
        {
            return _cardRepo.Insert(card);
        }

        public Task<Card> GetCardByName(String cardName)
        {
            return _cardRepo.GetByName(cardName);
        }

    }
}
