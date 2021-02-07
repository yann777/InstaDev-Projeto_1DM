using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstaDev_Projeto_1DM.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace InstaDev_Projeto_1DM.Controllers
{
    public class CadastroController : Controller
    {
        Cadastro cadastroModel = new Cadastro();
        

        public IActionResult Index()
        {
            ViewBag.Cadastros = cadastroModel.ReadAll();
            ViewBag.UserName = cadastroModel.ReadAll();
            ViewBag.User = cadastroModel.ReadAll();
            ViewBag.UserId = cadastroModel.ReadAll();
            ViewBag.Email = HttpContext.Session.GetString("_Email");

            return View();
        }

        public int GerarId()
        {
            Random numAleatorio = new Random();

            int id = numAleatorio.Next(100, 999);

            cadastroModel.GerarIdUsuario(id);
            
            while (cadastroModel.GerarIdUsuario(id))
            {
                id = numAleatorio.Next(100, 999);
                cadastroModel.GerarIdUsuario(id);
            }
            return id;
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {

                var id = cadastroModel.ReadAll().Count(); //Count() Serve para contar as linhas de um arquivo ou a quantidade de objetos e vai gerar um valor inteiro

           
            
                Cadastro novoCadastro = new Cadastro();

                novoCadastro.Email = form["Email"];
                novoCadastro.NomeCompleto = form["NomeCompleto"];
                novoCadastro.Username = form["Username"];
                novoCadastro.DataDeNascimento = form["DataDeNascimento"];
                novoCadastro.Password = form["Senha"];
                novoCadastro.IdUser = GerarId();
                novoCadastro.Status = true;

                 if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Usuarios");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }

                novoCadastro.ImagemPerfil   = file.FileName;                
            }
            else
            {
                novoCadastro.ImagemPerfil =  "padrao.png";
            }

                

                cadastroModel.Create(novoCadastro);

                ViewBag.Cadastros = cadastroModel.ReadAll();
                return LocalRedirect("~/Cadastro");
                
                
           
        }

        [Route("Cadastro/username")]
        public IActionResult Excluir(int IdUser)
        {
            cadastroModel.Delete(IdUser);
            return LocalRedirect("~/Login");
        }
    }
}