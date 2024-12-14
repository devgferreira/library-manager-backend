using Book.Domain.Contracts;
using Book.Domain.Entities.Book;
using Book.Domain.Entities.Book.Request;
using Book.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infra.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private DbSession _session;

        public BookRepository(DbSession session)
        {
            _session = session;
        }

        public Task DeleteAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<BookInfo> InsertAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookInfo> SelectBook(BookRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BookInfo> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
