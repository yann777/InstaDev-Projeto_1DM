using Projeto_InstaDev.Models;

namespace Projeto_InstaDev.Interfaces
{
    public interface IEdicao
    {
       void CadastrarUsuario(Usuario e);
       void EditarUsuario(Usuario e);
       void DeleteUsuario(int id);
    }
}