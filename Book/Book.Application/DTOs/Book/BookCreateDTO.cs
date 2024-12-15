using Book.Domain.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.DTOs.Book
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        public double QuantityAvailable { get; set; }
        public string LibraryLocation { get; set; }

        public BookCreateDTO(string title, string author, string genre, string iSBN, int publicationYear, string publisher, double quantityAvailable, string libraryLocation)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Publisher = publisher;
            QuantityAvailable = quantityAvailable;
            LibraryLocation = libraryLocation;
        }
    }
}
