using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationCore.CardClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Utils;

namespace WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CardController : ControllerBase
    {
        public CardController(ICardService service)
        {
            Service = service;
        }

        public ICardService Service { get; }

        public async Task<List<Card>> GetAll()
        {
            return await Service.GetAll();
        }

        public async Task<ActionResult<Card>> GetNextTodayCard(int categoryId)
        {
            var userId=  User.GetLoggedInUserId<int>();
            var nextCard = (await Service.GetNextTodayCard(categoryId, userId));
            if (nextCard == null)
                return Ok(new Card());
            return nextCard;
        }

        [HttpPost]
        public async Task<int> Update(Card card)
        {
            return await Service.Update(card);
        }
        
        [HttpPost]
        public async Task<int> Add(Card card)
        {
            card.userId=  User.GetLoggedInUserId<int>();
            return await Service.Add(card);
        }
    }
}