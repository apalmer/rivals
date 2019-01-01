using rivals.logic.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rivals.app.Controllers
{
    public class CardController
    {
        private CardManager _cardManger { get; set; }

        public CardController(CardManager cardManager)
        {
            _cardManger = cardManager;
        }
    }
}
