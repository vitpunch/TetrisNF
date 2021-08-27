using System.Threading;
using Microsoft.SmallBasic.Library;

namespace TetrisNF.Tetris
{
    class Program
    {
        private static Figure _currentFigure;
        static void Main()
        {
            Field.ScreenWidth=25;
            Field.ScreenHeight=40;
            _currentFigure=Figure.CreateNewFigure();
            _currentFigure.Draw();
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Thread.Sleep(Timeout.Infinite);
        }
        private static void GraphicsWindow_KeyDown()
        {
            switch (GraphicsWindow.LastKey.ToString())
            {
                case "Right":
                    _currentFigure.Move(Direction.Right);
                    break;
                case "Left":
                    _currentFigure.Move(Direction.Left);
                    break;
                case "Up":
                case "Space":
                    _currentFigure.Move(Direction.Rotate);
                    break;
                case "Down":
                    default:
                    _currentFigure.Move(Direction.Down);
                    if (Field.FigureIsDropped)
                    {
                        _currentFigure= Figure.CreateNewFigure();
                        Field.FigureIsDropped=false;
                    }
                    break;
            }
        }
    }
}
