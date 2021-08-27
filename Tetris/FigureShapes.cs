namespace TetrisNF.Tetris
{
    static class FigureShapes
    {
        static string[,] shapes;
        static FigureShapes()
        {
            shapes=new[,]
            {
                {
                    " *  ",
                    " *  ",
                    " *  ",
                    " *  "
                },
                {
                    "    ",
                    " *  ",
                    " ***",
                    "    "
                },
                {
                    "    ",
                    "   *",
                    " ***",
                    "    "
                },
                {
                    "    ",
                    " ** ",
                    "  **",
                    "    "
                },
                {
                    "    ",
                    "  **",
                    " ** ",
                    "    "
                },
                {
                    "    ",
                    "  * ",
                    " ***",
                    "    "
                },
                {
                    "    ",
                    " ** ",
                    " ** ",
                    "    "
                },
            };
        }
        public static Figure FigureGenerator(int figureNumber)
        {
            FigureMatrix matrix =new();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix.Matrix[j, i] = (shapes[figureNumber, i][j]=='*');
                }
            }
            return new Figure(new Point(Field.ScreenWidth / 2 - 2, 0), matrix);
        }
    }
}
