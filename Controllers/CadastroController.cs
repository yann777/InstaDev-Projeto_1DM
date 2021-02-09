

using System.Linq;
using InstaDev_Projeto_1DM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
           
            return View();
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
                novoCadastro.IdUser = id+1;
                novoCadastro.Status = true;
                

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
    