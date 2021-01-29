using System.Collections.Generic;
using InstaDev_Projeto_1DM.Models;

namespace InstaDev_Projeto_1DM.Interfaces
{
    public interface IComentario
    {
        void Create(Comentario c); 

        List<Comentario> ReadAll();

        void Delete(int IdComentario);

        void Update(Comentario Mensagem);
    }
}