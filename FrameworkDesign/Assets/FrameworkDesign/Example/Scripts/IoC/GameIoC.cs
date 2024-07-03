using Framework.IoC;
using FrameworkDesign.Example.Model;

namespace FrameworkDesign.Example.IoC
{
    public static class GameIoC
    {
        private static Container s_container;

        public static Container Container
        {
            get
            {
                if (s_container == null)
                {
                    Register();
                }

                return s_container;
            }
        }

        private static void Register()
        {
            s_container = new Container();

            s_container.RegisterSingleton<GameModel, GameModel>();
        }
    }
}
