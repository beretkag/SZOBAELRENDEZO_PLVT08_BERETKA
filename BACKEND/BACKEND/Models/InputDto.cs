namespace BACKEND.Models
{
    public class InputDto
    {
        public Room Room { get; set; }
        public IEnumerable<Furniture> Furnitures { get; set; }
    }
}
