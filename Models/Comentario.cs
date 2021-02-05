using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Projeto_1DM.Interfaces;

namespace InstaDev_Projeto_1DM.Models
{
    public class Comentario : InstadevBase , IComentario
    {
        public int IdComentario { get; set;}
        public string Mensagem { get; set;}
        public int IdUsuario { get; set;}
        public int IdPublicacao { get; set;}
        public string UserName { get; set;}

        public const string PATH = "Database/Comentarios.csv";

        public Comentario()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Comentario c)
        {
            string[] linha = { PrepararLinha(c) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Comentario c)
        {
            return $"{c.IdComentario};{c.Mensagem};{c.IdUsuario};{c.IdPublicacao};{c.UserName}";
        }

        public void Delete(int IdComentario)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdComentario.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Comentario> ReadAll()
        {
            List<Comentario> comentarios = new List<Comentario>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(';');

                Comentario comentario = new Comentario();

                comentario.IdComentario = Int32.Parse( linha[0] );
                comentario.Mensagem = linha[1];
                comentario.IdUsuario = Int32.Parse( linha[2] );
                comentario.IdPublicacao = Int32.Parse( linha[3] );

                comentarios.Add(comentario);
            }

            return comentarios;
        }

        public void Update(Comentario Mensagem)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[1] == Mensagem.Mensagem);
            linhas.Add( PrepararLinha(Mensagem) );                        
            RewriteCSV(PATH, linhas); 
        }

        public List<Comentario> BuscarId(int id_publi)
        {
            List<Comentario> comentarios = ReadAll().FindAll(x => x.IdPublicacao == id_publi);
            return comentarios;
        }

    }
}