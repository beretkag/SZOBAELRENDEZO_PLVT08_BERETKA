namespace BACKEND.Models
{
    public class Room
    {
        public Furniture[][] Space { get; set; }


        public Room(int width, int height)
        {
            Space = new Furniture[height][];
            for (int i = 0; i < height; i++)
            {
                Space[i] = new Furniture[width];
            }
        }
    }


}
