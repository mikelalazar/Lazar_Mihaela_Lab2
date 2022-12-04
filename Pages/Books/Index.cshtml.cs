using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lazar_Mihaela_Lab2.Data;
using Lazar_Mihaela_Lab2.Models;
using Microsoft.Data.SqlClient;

namespace Lazar_Mihaela_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Lazar_Mihaela_Lab2.Data.Lazar_Mihaela_Lab2Context _context;

        public IndexModel(Lazar_Mihaela_Lab2.Data.Lazar_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sort0rder, string searchString)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s => s.Author.FirstName.Contains(searchString)

               || s.Author.LastName.Contains(searchString)
               || s.Title.Contains(searchString));
                if (_context.Book != null)
                {
                    Book = await _context.Book
                        .Include(b => b.Publisher)
                        .ToListAsync();
                }
                switch (sortOrder)
                {
                    case "title_desc":
                        Book.Books = BookD.Books.OrderByDescending(s => s.Title);
                        break;
                    case "author_desc":
                        Book.Books = BookD.Books.OrderByDescending(s => s.Author.FullName);
                        break;

                }
            }
        }
    }
}
 
