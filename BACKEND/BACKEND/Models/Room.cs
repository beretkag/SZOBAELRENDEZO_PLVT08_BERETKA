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

        public void Place(Furniture furniture, int row, int col)
        {
            for (int i = 0; i < furniture.Height; i++)
            {
                for (int j = 0; j < furniture.Width; j++)
                {
                    Space[row + i][col + j] = furniture;
                }
            }
        }

        public void Remove(Furniture furniture, int row, int col)
        {
            for (int i = 0; i < furniture.Height; i++)
            {
                for (int j = 0; j < furniture.Width; j++)
                {
                    Space[row + i][col + j] = null;
                }
            }
        }
    }


}
