using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Projeto_1DM.Interfaces;

namespace InstaDev_Projeto_1DM.Models
{
    public class Publicacao : IPublicacao , InstadevBase
    {
        public int IdPublicacao {get;set;}
        public string ImgPublicao {get;set;}
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

        private string PrepararLinha(Publicacoes p)
        {
            return $"{p.IdPublicacao};{p.ImgPublicacao};{p.Legenda};{p.Comentarios}";
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

                Cadastro cadastro = new Cadastro();
                cadastro.Email                  = linha[0];
                cadastro.NomeCompleto           = linha[1];
                cadastro.Username               = linha[2];
                cadastro.DataDeNascimento       = linha[3];
                cadastro.ImagemPerfil           = linha[5];
                cadastro.IdUser                 = Int32.Parse( linha[6] );

                cadastros.Add(cadastro);
            }

            return cadastros;
        }

        public void Update(Cadastro alterarCadastro)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[1] == alterarCadastro.NomeCompleto);
            linhas.RemoveAll(x => x.Split(";")[2] == alterarCadastro.Username);
            linhas.RemoveAll(x => x.Split(";")[3] == alterarCadastro.DataDeNascimento);
            linhas.RemoveAll(x => x.Split(";")[5] == alterarCadastro.ImagemPerfil);
            linhas.Add( PrepararLinha(alterarCadastro) );                        
            RewriteCSV(PATH, linhas); 
        }
    }
}