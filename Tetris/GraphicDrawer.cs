using Microsoft.SmallBasic.Library;

namespace TetrisNF.Tetris
{
    class GraphicDrawer : IDrawer
    {
        Figure _figure;
        public void Clear(Figure figure)
        {
            this._figure = figure;
            GraphicsWindow.PenColor = "White";
            GraphicsWindow.PenWidth = 3;
            DrawToScreen();
        }

        public void Draw(Figure figure)
        {
            this._figure = figure;
            GraphicsWindow.PenWidth = 2; 
            GraphicsWindow.PenColor = "Red";
            DrawToScreen();
        }

        void DrawToScreen()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_figure.FigureMatrix.Matrix[j, i])
                        GraphicsWindow.DrawRectangle((_figure.StartPoint.X + j) * Configuration.CELL_SIZE, (_figure.StartPoint.Y + i) * Configuration.CELL_SIZE, Configuration.CELL_SIZE-1, Configuration.CELL_SIZE-1);
                }
            }
        }
    }
}