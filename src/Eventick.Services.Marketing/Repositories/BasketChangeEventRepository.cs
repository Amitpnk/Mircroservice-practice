﻿using Eventick.Services.Marketing.DbContexts;
using Eventick.Services.Marketing.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Eventick.Services.Marketing.Repositories
{
    public class BasketChangeEventRepository : IBasketChangeEventRepository
    {
        private readonly DbContextOptions<MarketingDbContext> dbContextOptions;

        public BasketChangeEventRepository(DbContextOptions<MarketingDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task AddBasketChangeEvent(BasketChangeEvent basketChangeEvent)
        {
            await using (var marketingDbContext = new MarketingDbContext(dbContextOptions))
            {
                await marketingDbContext.BasketChangeEvents.AddAsync(basketChangeEvent);
                await marketingDbContext.SaveChangesAsync();
            }
        }
    }
}
