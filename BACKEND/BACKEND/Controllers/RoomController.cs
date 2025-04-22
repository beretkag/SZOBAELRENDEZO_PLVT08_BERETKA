using Microsoft.AspNetCore.Mvc;
using BACKEND.Models;

namespace BACKEND.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        [HttpPost("furnishing")]
        public ActionResult<Room> Furnishing([FromBody] InputDto input)
        {
            Room room = new Room(input.roomWidth, input.roomHeight);

            if (TryPlaceAllFurnitures(room, input.Furnitures.ToList()))
            {
                return Ok(room);
            }
            else
            {
                return BadRequest(room);
            }

            
        }

        public static bool TryPlaceAllFurnitures(Room room, List<Furniture> furnitures, int index = 0)
        {
            if (index == furnitures.Count) return true;

            Furniture furniture = furnitures[index];
            List<Furniture> variations = new List<Furniture> { furniture, furniture.CloneRotated() };

            foreach (Furniture variant in variations)
            {
                for (int row = 0; row <= room.Space.Length - variant.Height; row++)
                {
                    for (int col = 0; col <= room.Space[0].Length - variant.Width; col++)
                    {
                        if (room.CanPlace(variant, row, col))
                        {
                            room.Place(variant, row, col);
                            if (TryPlaceAllFurnitures(room, furnitures, index + 1))
                            {
                                return true;
                            }
                            room.Remove(variant, row, col);
                        }
                    }
                }
            }

            return false;
        }
    }
}
