using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;



public class ActivityService : BaseService<Activity, IActivityRepository>, IActivityService
{
    public ActivityService(IActivityRepository repository) : base(repository,new List<Expression<Func<Activity, object>>> 
    { 
        
    })
    {
    }
}