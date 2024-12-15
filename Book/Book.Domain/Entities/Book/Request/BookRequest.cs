using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.Entities.Book.Request
{
    public class BookRequest
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? ISBN { get; set; }
        public int? PublicationYearStart {  get; set; }
        public int? PublicationYearEnd { get; set; }
    }
}
