using Ejercicio1_4.Controllers;
using Ejercicio1_4.Vistas;

namespace Ejercicio1_4
{
    public partial class App : Application
    {
        static Datos basedatos;

        public static Datos BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new Datos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpleadosDB.db3"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaEmpleados());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    
    }
}