using Microsoft.Extensions.DependencyInjection;

namespace PRG_MAUI_Car_Register
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();
            MainPage = shell;
        }
    }

}
