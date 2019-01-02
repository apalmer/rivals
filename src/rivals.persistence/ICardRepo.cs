using rivals.domain.Game.Cards;
using rivals.domain.Session;
using System;
using System.Threading.Tasks;

namespace rivals.persistence
{
    public interface ICardRepo : IRepo<Card>
    {
        Task<Card> GetByName(String cardName);
    }
}