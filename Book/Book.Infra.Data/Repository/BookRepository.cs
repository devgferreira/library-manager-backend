using Book.Domain.Contracts;
using Book.Domain.Entities.Book;
using Book.Domain.Entities.Book.Request;
using Book.Infra.Data.Context;
using Dapper;
using MySqlX.XDevAPI;
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
                string query = @"DELETE FROM Book WHERE Id = @BookId";

                await session.ExecuteAsync(sql: query, param: new
                {
                    BookId = bookId
                });
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

        public async Task<List<BookInfo>> SelectBook(BookRequest request)
        {
            using (var session = _session.Connection)
            {
                var  query = new StringBuilder( @"SELECT 
                                    ID, TITLE, AUTHOR, GENRE, ISBN, PUBLICATIONYEAR, 
                                    PUBLISHER, QUANTITYAVAILABLE, LIBRARYLOCATION 
                                FROM Book
                                WHERE 1 = 1 ");

                if (request.Title != null)
                    query.Append(" AND TITLE = @Title ");
                if (request.Author != null) 
                    query.Append(" AND AUTHOR = @Author ");
                if (request.Genre != null)
                    query.Append(" AND GENRE = @Genre ");
                if (request.ISBN != null)
                    query.Append(" AND ISBN = @ISBN ");
                if (request.PublicationYearStart != null && request.PublicationYearEnd != null)
                    query.Append(" AND PUBLICATIONYEAR BETWEEN @PublicationYearStart AND @PublicationYearEnd ");

                var result = await session.QueryAsync<BookInfo>(sql: query.ToString(), param: request);
                return result.ToList();
            }
        }

        public async Task UpdateAsync(int bookId, BookInfo request)
        {
            using(var session = _session.Connection)
            {
                string query = @"UPDATE Book
                                SET TITLE = @Title, 
                                    AUTHOR = @Author, 
                                    GENRE = @Genre, 
                                    ISBN = @ISBN, 
                                    PUBLICATIONYEAR = @PublicationYear, 
                                    PUBLISHER = @Publisher, 
                                    QUANTITYAVAILABLE = @QuantityAvailable, 
                                    LIBRARYLOCATION = @LibraryLocation
                                WHERE ID = @BookID "
                ;
                await session.ExecuteAsync(sql: query, param: new
                {
                    Title = request.Title,
                    Author = request.Author,
                    Genre = request.Genre,
                    ISBN = request.ISBN,
                    PublicationYear = request.PublicationYear,
                    Publisher = request.Publisher,
                    QuantityAvailable = request.QuantityAvailable,
                    LibraryLocation = request.LibraryLocation,
                    BookID = bookId
                });
            }
        }
    }
}
