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

        public async Task<Boolean> InsertOrUpdateCard(Card card)
        {
            var upserted = false;
            var existing = await GetCardByName(card.Name);

            if(existing == null)
            {
                upserted = await _cardRepo.Insert(card);
            }
            else
            {
                card.ID = existing.ID;
                upserted = await _cardRepo.Update(card);
            }

            return upserted;
        }

        public Task<Card> GetCardByName(String cardName)
        {
            return _cardRepo.GetByName(cardName);
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _cardRepo.GetAll();
        }

        public async Task<Boolean> DeleteCard(String id)
        {
            return await _cardRepo.Delete(id);
        }
    }
}
