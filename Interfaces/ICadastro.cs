using System.Collections.Generic;
using InstaDev_Projeto_1DM.Models;

namespace InstaDev_Projeto_1DM.Interfaces
{
    public interface ICadastro
    {
        void Create(Cadastro c); 

        List<Cadastro> ReadAll();

        void Delete(string username);
    }
}