using CrossApp.Models;
using Newtonsoft.Json.Linq;

namespace CrossApp.Views;


//We will map the id passed in the URL with the BookId string 
[QueryProperty(nameof(BookId) , "Id")]
public partial class EditBook : ContentPage
{
    BookRepository repository = new BookRepository();
    //Create a local book object
    private Book book;
	public EditBook()
	{
		InitializeComponent();
        setSelectedItem();
	}

    //We grab the id of the selected book via the QueryProperty and bind it to a local value
    public string BookId
    {
        set
        {
            BookId = value;
        }
        get { return BookId; }
    }
    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        //Using the .. operator to direct to the parent
        Shell.Current.GoToAsync("..");
    }

    public async void setSelectedItem()
    {
        book = await repository.GetBookById(int.Parse(BookId));
        if (book != null)
        {
            entryTitle.BindingContext = book.Title;
            entryAuthor.BindingContext = book.Author;
            entryDescription.BindingContext = book.Description;
            entryPages.BindingContext = book.Pages.ToString();

        }
    }


    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        //Since no databinding we take the values frmo the entries and insert them into the local book object which we can use to update
        book.Title = entryTitle.Text;
        book.Author = entryAuthor.Text;
        book.Description = entryDescription.Text;
        book.Pages = Int32.Parse(entryPages.Text);

        await repository.UpdateBook(book);
        //After calling the update function we want to redirect to bookslist (which is mainpage)
        await Shell.Current.GoToAsync("..");
    }
}