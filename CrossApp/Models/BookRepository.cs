using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CrossApp.Models
{
    public class BookRepository
    {
        Uri baseAddress = new Uri("https://localhost:32768/BooksApi");
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BookRepository()
        {
            try
            {
                _client = new HttpClient();
                _client.BaseAddress = baseAddress;

                _jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            }
            catch
            {
                Console.WriteLine("Failed to connect to API");
            }

            
        }

        //TODO 
        //Replace the current hard coded values with the response of the WEB API
        //public static List<Book> _books = new List<Book>()
        //{

        //};


        //Get all the books from the MySQL database via the API
        //public static List<Book> GetBooks() => _books;

        //public static Book getBookById(int id)
        //{
        //    var book =  _books.FirstOrDefault(x => x.BookId == id);
        //    if (book != null)
        //    {
        //        //Make new book to return
        //        return new Book
        //        {
        //            BookId = book.BookId,
        //            Title = book.Title,
        //            Description = book.Description,
        //            Author = book.Author,
        //            Pages = book.Pages,
        //        };
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public static void UpdateBook(int bookId, Book book) 
        //{
        //    if (bookId != book.BookId) return;

        //    //We grab the book that has to be updated (Passed as a parameter) from the Repo
        //    var bookToUpdate = _books.FirstOrDefault(x => x.BookId == bookId);
        //    //We check whether the book that has to be updated actually has a record in the Repo
        //    if (bookToUpdate != null)
        //    {
        //        bookToUpdate.Title = book.Title;
        //        bookToUpdate.Description = book.Description;
        //        bookToUpdate.Author = book.Author;
        //        bookToUpdate.Pages = book.Pages;
        //    }
        //}

        //public static void AddBook(Book book)
        //{
        //    var maxId = _books.Max(x => x.BookId);
        //    book.BookId = maxId;
        //    _books.Add(book);
        //}

        //public static void DeleteBook(int bookId)
        //{
        //    //Find the book out of the Repo with the ID that is passed as a parameter, see if it exists, if it does, remove it
        //    var book = _books.FirstOrDefault(x => x.BookId == bookId);
        //    if(book != null)
        //    {
        //        _books.Remove(book);
        //    }
        //}

        

        //API IMPLEMENTATIONS
        [HttpGet]
        public async Task<List<Book>> GetBooks()  
        {
            List<Book> books = new List<Book>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{_client.BaseAddress}/books/get");
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<List<Book>>(data);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return books;
        }

        [HttpGet]
        public async Task<Book> GetBookById(int bookId)
        {
            Book book = new Book();
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{_client.BaseAddress}/books/{bookId}");
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<Book>(data);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return book;
        }

        [HttpPost]
        public async Task AddBook(Book book)
        {
            try
            {
                string jsonBook = JsonSerializer.Serialize<Book>(book, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync($"{_client.BaseAddress}/books", content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        [HttpPut]
        public async Task UpdateBook(Book book)
        {
            try
            {
                string jsonBook = JsonSerializer.Serialize<Book>(book, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync($"{_client.BaseAddress}/books/{book.BookId}", content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }
        [HttpDelete]
        public async Task DeleteBook(int bookId)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"{_client.BaseAddress}/books/{bookId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}
