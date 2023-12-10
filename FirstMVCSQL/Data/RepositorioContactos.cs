using Dapper;
using FirstMVCSQL.Models;
using System.Data;

namespace FirstMVCSQL.Data
{
    public class RepositorioContactos : IRepositorioContactos
    {
        private readonly IDbConnection _dbConnection;

        public RepositorioContactos(IDbConnection dbConnection)
        {
            
                _dbConnection = dbConnection;
        
        }

        public async Task Delete(int id)
        {
            var sql = @"DELETE FROM Contactos
                        WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Contactos>> GetAll()
        {
            var sql = @"SELECT Id, FirstName, LastName, Phone, Address
                        FROM Contactos";

            return await _dbConnection.QueryAsync<Contactos>(sql, new { });
        }

        public async Task<Contactos> GetDetails(int id)
        {
            var sql = @"SELECT Id, FirstName, LastName, Phone, Address
                        FROM Contactos 
                        WHERE Id = @Id";

            return await _dbConnection.QueryFirstOrDefaultAsync<Contactos>(sql, new { Id = id});
        }

        public async Task Insert(Contactos contactos)
        {
            var sql = @"INSERT INTO Contactos (FirstName, LastName, Phone, Address)
                         VALUES(@FirstName,@LastName,@Phone,@Address)"; 

            await _dbConnection.ExecuteAsync(sql, new { 
                contactos.FirstName,
                contactos.LastName,
                contactos.Phone,
                contactos.Address
            });
        }

        public async Task Update(Contactos contactos)
        {
            var sql = @"UPDATE Contactos 
                         SET FirstName = @FirstName, 
                                    LastName = @LastName, 
                                    Phone = @Phone, 
                                    Address = @Address 
                             WHERE Id = @Id";
                                

            await _dbConnection.ExecuteAsync(sql, new
            {
                contactos.FirstName,
                contactos.LastName,
                contactos.Phone,
                contactos.Address,
                contactos.Id
            });
        }
    }
}
