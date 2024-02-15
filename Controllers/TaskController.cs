
using Microsoft.AspNetCore.Mvc;
using todos.Services;

namespace todos.Controllers
{
    /// <summary>
    /// Controller for managing Task entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : EntityController<Models.Task>
    {
        public TaskController(IEntityService<Models.Task> entityService) : base(entityService)
        {
        }
    }
}


