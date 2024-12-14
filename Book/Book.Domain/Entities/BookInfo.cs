using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.Entities
{
    public class BookInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        public int QuantityAvailable { get; set; }
        public string LibraryLocation { get; set; }

        public BookInfo(int id, string title, string author, string genre, string iSBN, int publicationYear, string publisher, int quantityAvailable, string libraryLocation)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Publisher = publisher;
            QuantityAvailable = quantityAvailable;
            LibraryLocation = libraryLocation;
        }

        public BookInfo()
        {
        }
    }
}
