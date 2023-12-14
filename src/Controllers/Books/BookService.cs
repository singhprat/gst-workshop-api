
using Dapper;
using System.Data.SqlClient;

namespace Workshop_POC.Controllers.Books
{
    public class BookService
    {
        private readonly string _connectionString;

        public BookService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Models.Book>> GetAllBooksAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return await connection.QueryAsync<Models.Book>("SELECT * FROM Book");
        }
        // Add methods for Create, Update, and Delete
        public async Task<int> CreateBookAsync(Models.Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Book (Title, Author, PublishedYear, ISBN, Genre) VALUES (@Title, @Author, @PublishedYear, @ISBN, @Genre); SELECT SCOPE_IDENTITY();";
            return await connection.ExecuteScalarAsync<int>(sql, book);
        }

        public async Task<int> UpdateBookAsync(Models.Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Book SET Title = @Title, Author = @Author, PublishedYear = @PublishedYear, ISBN = @ISBN, Genre = @Genre WHERE BookId = @BookId";
            return await connection.ExecuteAsync(sql, book);
        }

        public async Task<int> DeleteBookAsync(int bookId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Books WHERE BookId = @BookId";
            return await connection.ExecuteAsync(sql, new { BookId = bookId });
        }
    }
}
