using Microsoft.SmallBasic.Library;

namespace TetrisNF.Tetris
{
    static class Field
    {
        private static int _screenWidth=25;
        private static int _screenHeight=50;
        private static bool[,] _field = new bool[ScreenWidth+2,ScreenHeight+2];
        public static int ScreenWidth
        {
            get { return _screenWidth; }
            set
            {
                _screenWidth = value;
                GraphicsWindow.Width = ScreenWidth * Configuration.CELL_SIZE;
            }
        }
        public static int ScreenHeight
        {
            get { return _screenHeight; }
            set
            {
                _screenHeight = value;
                GraphicsWindow.Height = ScreenHeight*Configuration.CELL_SIZE;
            }
        }
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
            if (x < 0 || x == ScreenWidth || y < 0 || y == ScreenHeight)
                return true;
            return _field[x, y];
        }
        public static void FigureToField(Figure figure)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (figure.FigureMatrix.Matrix[x, y])
                        _field[figure.StartPoint.X + x, figure.StartPoint.Y + y] = true;
                }
            }
        }
        internal static void CheckFieldToDrop()
        {
            for (int y = 0; y < _screenHeight; y++)
            {
                int counter = 0;
                for (int x = 0; x < _screenWidth; x++)
                {
                    if (_field[x, y])
                        counter++;
                }
                if (counter == _screenWidth)
                {
                    for (int y1 = y; y1 > 0; y1--)
                    {
                        for (int x = 0; x < _screenWidth; x++)
                        {
                            _field[x, y1] = _field[x, y1 - 1];
                        }
                    }
                    for (int x = 0; x < _screenWidth; x++)
                    {
                        _field[x, 0] = false;
                    }
                    CheckFieldToDrop();
                }
            }
        }
    }
}