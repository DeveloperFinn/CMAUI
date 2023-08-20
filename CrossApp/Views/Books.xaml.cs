using CrossApp.Models;
using System.Collections.ObjectModel;

namespace CrossApp.Views;

public partial class Books : ContentPage
{
    BookRepository repository = new BookRepository();
	public Books()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        refreshList();
    }

    private async void listBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		//Workaround for selecteditems, This selection event handler only triggers when the itemselected has changed
		//Therefor we use the ItemTapped aswell, this will reset the selected book so the system does not recognize the same selected item
		if (listBooks.SelectedItem != null)
		{
			//We grab the selected item, cast it into the Book object and grab the Id from it to pass it on to the Edit page
			await Shell.Current.GoToAsync($"{nameof(EditBook)}?Id={((Book)listBooks.SelectedItem).BookId}");
		}
    }

    private void listBooks_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //When the user taps on any book we reset the selected item
		//This event handler will trigger after the ItemSelected event handler
        listBooks.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddBook));
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var book = menuItem.CommandParameter as Book;
        await repository.DeleteBook(book.BookId);
        refreshList();
    }

    private async void refreshList()
    {
        var books = new ObservableCollection<Book>(await repository.GetBooks());
        listBooks.ItemsSource = books;
    }
}