using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        [HttpPost("furnishing")]
        public Room Furnishing([FromBody] InputDto input)
        {
            Room room = new Room(input.roomWidth, input.roomHeight);





            return room;
        }
    }

    
}
