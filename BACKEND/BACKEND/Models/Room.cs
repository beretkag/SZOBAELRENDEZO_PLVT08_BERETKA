namespace BACKEND.Models
{
    public class Room
    {
        public Furniture[,] Space { get; set; }

        public Room(int width, int height)
        {
            Space = new Furniture[width, height];
        }
    }


}
