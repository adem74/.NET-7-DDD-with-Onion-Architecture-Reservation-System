
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Menu;

namespace Dinner.Infrastructure.Persistence.Repositories;
public class MenuRepository : IMenuRepository
{  
    private readonly DinnerDbContext _dbContext;

    public MenuRepository(DinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}