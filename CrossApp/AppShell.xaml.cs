using CrossApp.Views;

namespace CrossApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Books), typeof(Books));
            Routing.RegisterRoute(nameof(AddBook), typeof(AddBook));
            Routing.RegisterRoute(nameof(EditBook), typeof(EditBook));
        }
    }
}