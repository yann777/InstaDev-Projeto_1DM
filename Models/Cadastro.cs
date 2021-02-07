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
        public int[] seguidos = new int[45];
        public string Buscar{get;set;}
        public bool Status { get; set;}
        
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
            return $"{c.Email};{c.NomeCompleto};{c.Username};{c.DataDeNascimento};{c.Password};{c.ImagemPerfil};{c.IdUser};{c.Status}";
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
                cadastro.Password               = linha[4];
                cadastro.ImagemPerfil           = linha[5];
                cadastro.IdUser                 = Int32.Parse(linha[6]);
                cadastro.Status                 = bool.Parse( linha[7] );

                cadastros.Add(cadastro);
            }

            return cadastros;
        }

        public void Update(Cadastro p, int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            linhas.Add( PrepararLinha(p) );                        
            RewriteCSV(PATH, linhas); 
        }

          public bool GerarIdUsuario(int id)
        {
            bool existe = false;

            List<string> csv = new List<string>();

            csv = ReadAllLinesCSV(PATH);

            foreach (var item in csv)
            {
                string[] linha = item.Split(";");

                
                
                if (id == int.Parse(linha[6]))
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            
            return existe;
        }
        public List<Cadastro> BuscarNome(int id_user)
        {
            List<Cadastro> usersId = ReadAll().FindAll(x => x.IdUser == id_user);
            return usersId;
        }

    }
}