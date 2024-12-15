using Book.Domain.Contracts;
using Book.Domain.Entities.Book;
using Book.Domain.Entities.Book.Request;
using Book.Infra.Data.Context;
using Dapper;
using Org.BouncyCastle.Asn1.Ocsp;
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

        public async Task DeleteAsync(int bookId)
        {
            using (var session = _session.Connection)
            {
                string query = @"DELETE FROM BOOK WHERE ID = @BookId"
                ;

                await session.ExecuteAsync(sql: query, param: bookId);
            }
        }

        public async Task InsertAsync(BookInfo request)
        {
            using (var session = _session.Connection)
            {
                string query = @"INSERT 
                                INTO Book (
                                    Title, Author, Genre, ISBN, PublicationYear, 
                                    Publisher, QuantityAvailable, LibraryLocation)
                                VALUES 
                                    (@Title, @Author, @Genre, @ISBN, @PublicationYear, 
                                    @Publisher, @QuantityAvailable, @LibraryLocation)";

                await session.ExecuteAsync(sql: query, param: request);
            }
        }

        public Task<List<BookInfo>> SelectBook(BookRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BookInfo> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
