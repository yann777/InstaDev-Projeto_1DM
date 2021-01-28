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
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            
                Cadastro novoCadastro = new Cadastro();

                novoCadastro.Email = form["Email"];
                novoCadastro.NomeCompleto = form["NomeCompleto"];
                novoCadastro.Username = form["Username"];
                novoCadastro.DataDeNascimento = form["DataDeNascimento"];
                novoCadastro.Password = form["Senha"];
                novoCadastro.IdUser = Int32.Parse(form["IdUser"]);
                

                cadastroModel.Create(novoCadastro);

                ViewBag.Cadastros = cadastroModel.ReadAll();
                return LocalRedirect("~/Cadastro");
                
           
        }

        [Route("Cadastro/username")]
        public IActionResult Excluir(int IdUser)
        {
            cadastroModel.Delete(IdUser);
            return LocalRedirect("~/Cadastro");
        }
    }
}