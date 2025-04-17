namespace BACKEND.Models
{
    public class Room
    {
        Furniture[,] Space { get; set; }

        public Room(int width, int height)
        {
            Space = new Furniture[width, height];
        }
    }


}
