using FirstMVCSQL.Models;

namespace FirstMVCSQL.Data
{
    public interface IRepositorioContactos
    {
        Task<IEnumerable<Contactos>> GetAll();
        Task<Contactos> GetDetails(int id);
        Task Insert(Contactos contactos);
        Task Update(Contactos contactos);
        Task Delete(int id);

    }
}
