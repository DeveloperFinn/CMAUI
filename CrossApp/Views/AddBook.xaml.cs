using CrossApp.Models;

namespace CrossApp.Views;

public partial class AddBook : ContentPage
{
    BookRepository repository = new BookRepository();
    public AddBook()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		//Using the .. operator to direct to the parent
		Shell.Current.GoToAsync("..");
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await repository.AddBook(new Models.Book
        {
            Title = entryTitle.Text,
            Description = entryDescription.Text,
            Author = entryAuthor.Text,
            Pages = Int32.Parse(entryPages.Text)
        });
        await Shell.Current.GoToAsync("..");
    }
}