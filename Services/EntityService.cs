
using todos.Data;

namespace todos.Services
{
    /// <summary>
    /// Service for managing TaskModel entities.
    /// </summary>
    public class EntityService : BaseEntityService<Models.Task>
    {
        public EntityService(MyDbContext context) : base(context)
        {
        }
    }
}
