using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Projeto_1DM.Interfaces;

namespace InstaDev_Projeto_1DM.Models
{
    public class Cadastro : InstadevBase , ICadastro
    {
        public string Email { get; set; }
        public string NomeCompleto { get; set; }
        public string Username { get; set;}
        public string DataDeNascimento { get; set; }
        public string Password { get; set; }
        public string ImagemPerfil { get; set; }
        public int IdUser { get; set; }

        public const string PATH = "Database/usuario.csv";

        public Cadastro()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Cadastro c)
        {
            string[] linha = { PrepararLinha(c) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Cadastro c)
        {
            return $"{c.Email};{c.NomeCompleto};{c.Username};{c.DataDeNascimento};{c.Password};{c.ImagemPerfil};{c.IdUser}";
        }

        public void Delete(int IdUser)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll(x => x.Split(";")[0] == IdUser.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Cadastro> ReadAll()
        {
            List<Cadastro> cadastros = new List<Cadastro>();
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