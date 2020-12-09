using Xamarin.Forms;
using XamarinStudy.DataSource;

namespace XamarinStudy
{
    public partial class App : Application
    {

        static ContactsDatabase database;

        public static ContactsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ContactsDatabase();
                }

                return database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.MainPage());
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
