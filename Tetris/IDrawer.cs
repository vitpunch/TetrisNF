namespace TetrisNF.Tetris
{
    interface IDrawer
    {
        public void Draw(Figure figure);
        public void Clear(Figure figure);
        void RedarawField();
    }
}
