namespace TetrisNF.Tetris
{
    static class DriverProvider
    {
        private static IDrawer _drawer = new GraphicDrawer();
        public static IDrawer Drawer
        {
            get
            {
                return _drawer;
            }
        }
    }
}
