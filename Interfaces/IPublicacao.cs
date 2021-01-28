using System.Collections.Generic;
using InstaDev_Projeto_1DM.Models;

namespace InstaDev_Projeto_1DM.Interfaces
{
    public interface IPublicacao
    {
        void Create(Publicacao p); 

        List<Publicacao> ReadAll();

        void Delete(int IdPublicacao);

        void Update(Publicacao alterarPublicacao);
    }
}