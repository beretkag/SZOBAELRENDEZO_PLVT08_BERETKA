namespace BACKEND.Models
{
    public class Room
    {
        public Furniture[][] Space { get; set; }
        public int Width => Space[0].Length;
        public int Height => Space.Length;


        public Room(int width, int height)
        {
            Space = new Furniture[height][];
            for (int i = 0; i < height; i++)
            {
                Space[i] = new Furniture[width];
            }
        }
        public bool IsInside(int row, int col)
        {
            return row >= 0 && row < this.Height && col >= 0 && col < this.Width;
        }

        public bool CanPlace(Furniture furniture, int row, int col)
        {
            if (!IsInside(row + furniture.Height - 1, col + furniture.Width - 1)) return false;

            for (int i = -1; i <= furniture.Height; i++)
            {
                for (int j = -1; j <= furniture.Width; j++)
                {
                    int r = row + i;
                    int c = col + j;
                    if (IsInside(r, c) && Space[r][c] != null) return false;
                }
            }
            return true;
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
