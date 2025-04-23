namespace BACKEND.Models
{
    public class InputDto
    {
        public int roomWidth { get; set; }
        public int roomHeight { get; set; }
        public int furnitureGap { get;set; }
        public IEnumerable<Furniture> Furnitures { get; set; }
    }
}
