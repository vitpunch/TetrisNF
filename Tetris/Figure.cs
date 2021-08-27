using System;

namespace TetrisNF.Tetris
{
    public class Figure
    {
        public Figure(Point startPoint, FigureMatrix figureMatrix)
        {
            this.FigureMatrix = figureMatrix;
            this.StartPoint = startPoint;
        }
        public Point StartPoint { get; set; }

        FigureMatrix rotatedFigure = new();
        public FigureMatrix FigureMatrix;
        public void Draw()
        {
            DriverProvider.Drawer.Draw(this);
        }
        public void Clear()
        {
            DriverProvider.Drawer.Clear(this);
        }
        public void Move(Direction direction)
        {
            Clear();
            switch (direction)
            {
                case Direction.Rotate:
                    TryRotate();
                    break;
                case Direction.Left:
                    StartPoint.X--;
                    if (!IsCorrect())
                        StartPoint.X++;
                    break;
                case Direction.Right:
                    StartPoint.X++;
                    if (!IsCorrect())
                        StartPoint.X--;
                    break;
                case Direction.Down:
                    StartPoint.Y++;
                    if (!IsCorrect())
                    {
                        StartPoint.Y--;
                        Field.FigureToField(this);
                        Field.FigureIsDropped = true;
                    }
                    break;
            }
            Draw();
        }
        public static Figure CreateNewFigure()
        {
            Random rand = new();
            int figureNumber = rand.Next(0, 7);
            return FigureShapes.FigureGenerator(figureNumber);
        }
        private void TryRotate()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    rotatedFigure.Matrix[i, j] = FigureMatrix.Matrix[j, 3 - i];
                }
            }
            if (IsCorrect(rotatedFigure))
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        FigureMatrix.Matrix[i, j] = rotatedFigure.Matrix[i, j];
                    }
                }
            }
        }

        bool IsCorrect()
        {
            return IsCorrect(FigureMatrix);
        }
        bool IsCorrect(FigureMatrix matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix.Matrix[j, i] && Field.GetDot(StartPoint.X + j, StartPoint.Y + i))
                        return false;
                }
            }
            return true;
        }
    }


}
