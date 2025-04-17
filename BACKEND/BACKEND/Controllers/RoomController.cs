using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Room> Furnishing([FromBody] InputDto input)
        {
            Room room = input.Room;





            return Ok(room);
        }
    }
}
