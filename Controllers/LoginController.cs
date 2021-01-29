using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using InstaDev_Projeto_1DM.Models;


namespace InstaDev_Projeto_1DM.Controllers
{
        [Route("Login")]

    public class LoginController : Controller
    {     

        [TempData]
        public string Mensagem { get; set; }

        Cadastro cadastroModel = new Cadastro();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]

        public IActionResult Logar(IFormCollection form)
        {
          
            // Lemos todos os arquivos do CSV

            Cadastro usuario = new Cadastro();
            List<string> csv = usuario.ReadAllLinesCSV("Database/usuario.csv");



            // Verificamos se as informações passadas existe na lista de string
            var logado = 
            csv.Find(
                x => 
                x.Split(";")[0] == form["Email"] &&  x.Split(";")[4] == form["Senha"] || x.Split(";")[2] == form["Username"] && 
                x.Split(";")[4] == form["Senha"]
            );


            // Redirecionamos o usuário logado caso encontrado
            if(logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                HttpContext.Session.SetString("_User" , logado.Split(";")[2]);
                return LocalRedirect("~/Publicacao");
            } else
            {
                Mensagem = "Dados incorretos, tente novamente...";
                return LocalRedirect("~/Login");
            }
     
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/Login");
        }
    }
}
