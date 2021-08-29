using System;
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

        public void RedarawField()
        {
            GraphicsWindow.BrushColor="White";
            GraphicsWindow.FillRectangle(0,0,Configuration.FIELD_WIDTH*Configuration.CELL_SIZE,Configuration.FIELD_HEIGHT*Configuration.CELL_SIZE);
            for (int y = 0; y < Field.ScreenHeight; y++)
            {
                for (int x = 0; x < Field.ScreenWidth; x++)
                {
                    if (Field.GetDot(x, y))
                        DrawDot(x, y);
                    else
                        ClearDot(x, y);
                }
            }
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

        void DrawDot(int x, int y)
        {
            GraphicsWindow.PenWidth = 2; 
            GraphicsWindow.PenColor = "Red";
            GraphicsWindow.DrawRectangle(x * Configuration.CELL_SIZE, y * Configuration.CELL_SIZE, Configuration.CELL_SIZE-1, Configuration.CELL_SIZE-1);
        }
        void ClearDot(int x, int y)
        {
            GraphicsWindow.PenColor = "White";
            GraphicsWindow.PenWidth = 3;
            GraphicsWindow.DrawRectangle(x * Configuration.CELL_SIZE, y * Configuration.CELL_SIZE, Configuration.CELL_SIZE-1, Configuration.CELL_SIZE-1);
        }
    }
}