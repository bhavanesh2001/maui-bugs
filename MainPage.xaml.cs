using System.Diagnostics;

namespace maui_bugs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"Old Value: {e.OldTextValue}, New Value: {e.NewTextValue}");
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"Old Value: {e.OldTextValue}, New Value: {e.NewTextValue}");
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"Old Vlaue: {e.OldTextValue}, New Value: {e.NewTextValue}");
        }
    }
}
