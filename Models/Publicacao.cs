using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Projeto_1DM.Interfaces;

namespace InstaDev_Projeto_1DM.Models
{
    public class Publicacao : InstadevBase , IPublicacao 
    {
        public int IdPublicacao {get;set;}
        public string ImgPublicacao {get;set;}
        public string UserPublicacao {get;set;}
        public string Legenda {get;set;}
        public string Comentarios {get;set;}

        public const string PATH = "Database/publicacoes.csv";

        public Publicacao()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Publicacao  p)
        {
            string[] linha = { PrepararLinha(p) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Publicacao p)
        {
            Cadastro newCadastro = new Cadastro();

            return $"{p.IdPublicacao};{p.ImgPublicacao};{p.Legenda};{p.UserPublicacao = newCadastro.Username}";
        }

        public void Delete(int IdPublicacao)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdPublicacao.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Publicacao> ReadAll()
        {
            List<Publicacao> publicacoes = new List<Publicacao>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(';');

                Publicacao publicar = new Publicacao();
                publicar.IdPublicacao           = Int32.Parse( linha[0] );
                publicar.ImgPublicacao          = linha[1];
                publicar.Legenda                = linha[2];

                publicacoes.Add(publicar);
            }

            return publicacoes;
        }

        public void Update(Publicacao alterarPublicacao)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[1] == alterarPublicacao.ImgPublicacao);
            linhas.RemoveAll(x => x.Split(";")[2] == alterarPublicacao.Legenda);
            linhas.Add( PrepararLinha(alterarPublicacao) );                        
            RewriteCSV(PATH, linhas); 
        }
    }
}