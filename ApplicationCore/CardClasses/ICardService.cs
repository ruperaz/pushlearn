using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.CardClasses
{
    public interface ICardService
    {
        Task<List<Card>> GetAll();

        Task<Card> GetNextTodayCard(int categoryId,int userId);
        Task<int> Update(Card card);
        Task<int> Add(Card card);
    }
}
