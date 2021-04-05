using Xamarin.Forms;

namespace XFBugItemsViewController
{
    public partial class MainPage : ContentPage
    {
        private View SetupLandscape()
        {
            var grid = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                }
            };
            grid.Children.Add(CreateButtons(), 0, 0);
            grid.Children.Add(CreateCollectionView(), 1, 0);
            return grid;
        }

        private View SetupPortrait()
        {
            var grid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = GridLength.Star }
                }
            };
            grid.Children.Add(CreateButtons(), 0, 0);
            grid.Children.Add(CreateCollectionView(), 0, 1);
            return grid;
        }

        private View CreateCollectionView()
        {
            var collection = new CollectionView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = new Label { TextColor = Color.Black };
                    label.SetBinding(Label.TextProperty, nameof(MyItem.Name));
                    return new Frame { Content = label, HeightRequest = 100 };
                })
            };
            collection.SetBinding(ItemsView.ItemsSourceProperty, nameof(MainPageViewModel.MyCollection));
            return collection;
        }

        private View CreateButtons()
        {
            var grid = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                },
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = GridLength.Star },
                },
            };

            var fillButton = new Button { Text = "Fill", BorderColor = Color.Black, TextColor = Color.Black };
            fillButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.FillCollection));
            grid.Children.Add(fillButton, 0, 0);

            var emptyButton = new Button { Text = "Empty", BorderColor = Color.Black, TextColor = Color.Black };
            emptyButton.SetBinding(Button.CommandProperty, nameof(MainPageViewModel.EmptyCollection));
            grid.Children.Add(emptyButton, 1, 0);
            return grid;
        }

        private void InitializeComponent()
        {
            if (App.ScreenWidth > App.ScreenHeight)
            {
                Content = SetupLandscape();
            }
            else
            {
                Content = SetupPortrait();
            }
        }

        public MainPage()
        {
            BindingContext = new MainPageViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.OrientationChanged -= App_OrientationChanged;
            App.OrientationChanged += App_OrientationChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.OrientationChanged -= App_OrientationChanged;
        }

        private void App_OrientationChanged()
        {
            Device.BeginInvokeOnMainThread(InitializeComponent);
        }
    }
}
