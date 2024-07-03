using Framework.IoC;
using FrameworkDesign.CounterApp.Model;
using FrameworkDesign.CounterApp.Utility;

namespace FrameworkDesign.CounterApp.IoC
{
    public static class App
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

            s_container.RegisterSingleton<IStorage, PlayerPreferencesStorage>();
            s_container.RegisterSingleton<CounterModel, CounterModel>();
        }
    }
}
