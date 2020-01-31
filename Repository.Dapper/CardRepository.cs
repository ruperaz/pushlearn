using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.CardClasses;

namespace Repository.Dapper
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Card>> GetAll()
        {
            var query = "select * from Cards";
            return (await SqlServerDbConnection.QueryAsync<Card>(query)).ToList();
        }

        public async Task<Card> GetNextTodayCard(int categoryId, int userId)
        {
            var query = @"select top 1 cards.id,
                               question,
                               answer,
                               card_level,
                               updateAt,
                               categoryId,
                               cards.isActive,
                               cards.userId
                        from cards
                                 inner join categories on cards.categoryId = categories.Id
                        where DATEDIFF(DAY, updateAt, getdate()) >= POWER(2, card_level)
                          and cards.userId = @userId
                          and (categoryId > CASE WHEN @categoryId = 0 THEN 0 END
                            OR categoryId = CASE WHEN @categoryId <> 0 THEN @categoryId END)
                        order by updateAt";
            return (await SqlServerDbConnection.QueryAsync<Card>(query, new {categoryId, userId}))
                .FirstOrDefault();
        }

        public async Task<int> Update(Card card)
        {
            var query = @"update cards set card_level=@card_level , updateAt=GetDate() where Id=@Id";
            return await SqlServerDbConnection.ExecuteAsync(query, new {card.Id, card.card_level});
        }

        public async Task<int> Add(Card card)
        {
            var query =
                @"Insert cards (question,answer,categoryId,userId) values (@question , @answer , @categoryId, @userId)";
            return await SqlServerDbConnection.ExecuteAsync(query,
                new {card.question, card.answer, card.categoryId, card.userId});
        }
    }
}