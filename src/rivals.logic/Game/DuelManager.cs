using rivals.domain.Game;
using rivals.persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rivals.logic.Game
{
    public class DuelManager
    {
        private DuelRepo _duelRepo;
        public async Task<Duel> RegisterDuel(Player challenger, Player challenged)
        {
            var duel = new Duel(challenger, challenged);
            var inserted = await _duelRepo.Insert(duel);
            return inserted ? duel: null;
        }

        public DuelManager(DuelRepo duelRepo)
        {
            _duelRepo = duelRepo;
        }
    }
}
