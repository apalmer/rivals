using rivals.domain.Game;
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
    }
}
