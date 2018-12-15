using rivals.domain.Game;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rivals.logic.Game
{
    public class DuelManager
    {
        public async Task<Duel> RegisterDuel(Player challenger, Player challenged)
        {
            var duel = new Duel(challenger, challenged);
            return duel;
        }
    }
}
