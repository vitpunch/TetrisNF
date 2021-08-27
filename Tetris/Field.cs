using Microsoft.SmallBasic.Library;

namespace TetrisNF.Tetris
{
    static class Field
    {
        private static int _screenWidth=50;
        private static int _screenHeight=100;
        public static int ScreenWidth
        {
            get { return _screenWidth; }
            set
            {
                _screenWidth = value;
                GraphicsWindow.Width = (ScreenWidth-1) * Configuration.CELL_SIZE;
            }
        }
        
        public static int ScreenHeight
        {
            get { return _screenHeight; }
            set
            {
                _screenHeight = value;
                GraphicsWindow.Height = (ScreenHeight-1)*Configuration.CELL_SIZE;
            }
        }
        private static bool[,] _field = new bool[ScreenWidth+2,ScreenHeight+2];
        private static bool _figureIsDropped;
        public static bool FigureIsDropped
        {
            get
            {
                return _figureIsDropped;
            }
            set
            {
                _figureIsDropped = value;
            }
        }
        public static bool GetDot(int x, int y)
        {
            if (x < 0 || x == ScreenWidth - 1 || y < 0 || y == ScreenHeight-1)
                return true;
            return _field[x, y];
        }
        public static void FigureToField(Figure figure)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (figure.FigureMatrix.Matrix[j, i])
                        _field[figure.StartPoint.X + j, figure.StartPoint.Y + i] = true;
                }
            }
            FigureIsDropped = false;
        }
    }
}