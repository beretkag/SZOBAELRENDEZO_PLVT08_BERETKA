namespace BACKEND.Models
{
    public class Furniture
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Furniture CloneRotated()
        {
            return new Furniture
            {
                Name = this.Name,
                Width = this.Height,
                Height = this.Width
            };
        }
    }
}
