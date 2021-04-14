using System.Collections.Generic;
using System.Threading.Tasks;

using TodoifyUI.Library.Models;

namespace TodoifyUI.Library.Api
{
    public interface ITodoEndpoint
    {
        Task<List<TodoModel>> GetAllAsync();
    }
}