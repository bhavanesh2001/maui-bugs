using System.Collections.ObjectModel;

namespace maui_bugs
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string>? _items;

        public ObservableCollection<string>? Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            cView.SelectedItem = "Item 1";
            cView.ItemsSource = null;
        }
       
    }
}
