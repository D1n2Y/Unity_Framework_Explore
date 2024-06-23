using System;

namespace FrameworkDesign.Example.Model
{
    public static class GameModel
    {
        public const int GamePassClickedCnt = 10;

        private static int s_clickedCnt;

        public static int ClickedCnt
        {
            get => s_clickedCnt;
            set
            {
                if (s_clickedCnt == value)
                {
                    return;
                }

                s_clickedCnt = value;
                ClickedCntChanged?.Invoke();
            }
        }

        public static event Action ClickedCntChanged;
    }
}
