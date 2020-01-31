using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.CardClasses
{
    public class CardService : ICardService
    {

        public CardService(ICardRepository repository)
        {
            Repository = repository;
        }

        public ICardRepository Repository { get; }

        public async Task<List<Card>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<Card> GetNextTodayCard(int categoryId, int userId)
        {
            return await Repository.GetNextTodayCard(categoryId,userId);
        }

        public async Task<int> Update(Card card)
        {
            return await Repository.Update(card);
        }

        public async Task<int> Add(Card card)
        {
            return await Repository.Add(card);
        }
    }
}
