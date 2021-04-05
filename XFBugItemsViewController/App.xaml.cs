using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFBugItemsViewController
{
    public partial class App : Application
    {
        public static double ScreenWidth { get; set; }
        public static double ScreenHeight { get; set; }

        public static event Action OrientationChanged;
        public static void OnOrientationChanged()
        {
            OrientationChanged?.Invoke();
        }


        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
