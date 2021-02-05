using InstaDev_Projeto_1DM.Models;

namespace InstaDev_Projeto_1DM.Interfaces
{
    public interface IEdicao
    {
       void CadastrarUsuario(Usuario e);
       void EditarUsuario(Usuario e);
       void DeleteUsuario(int id);
    }
}