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
    public class PublicacaoController : Controller
    {

        Publicacao publicacaoModel = new Publicacao();

        public IActionResult Index()
        {

            ViewBag.User = HttpContext.Session.GetString("_User");
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.UserId = HttpContext.Session.GetString("_UserId");

            Cadastro cadastroModel = new Cadastro();
            ViewBag.Cadastros = cadastroModel.ReadAll();
            
            ViewBag.Publicacoes = publicacaoModel.ReadAll();
            return View();
        }

        [Route("CadastrarPublicacao")]
        public IActionResult Cadastrar(IFormCollection form)
        {
           
                Publicacao novaPublicacao = new Publicacao();
                Cadastro usuario = new Cadastro();

                ViewBag.UserId = HttpContext.Session.GetString("_UserId");

                var id = publicacaoModel.ReadAll().Count(); //Count() Serve para contar as linhas de um arquivo ou a quantidade de objetos

                novaPublicacao.Legenda = form["Legenda"];
                novaPublicacao.IdPublicacao = id+1;
                novaPublicacao.IdUsuario = ViewBag.UserId;
                
                novaPublicacao.Status = true;

                if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgPublicacao/Publicacoes");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgPublicacao/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }

                novaPublicacao.ImgPublicacao   = file.FileName;                
            }
            else
            {
                novaPublicacao.ImgPublicacao =  "padrao.png";
            }

                publicacaoModel.Create(novaPublicacao);

                ViewBag.Publicacoes = publicacaoModel.ReadAll();
                return LocalRedirect("~/Publicacao");
                
           
        }

        [Route("Publicacao/{idPublicacao}")]
        public IActionResult Excluir(int IdPublicacao)
        {
            publicacaoModel.Delete(IdPublicacao);
            return LocalRedirect("~/Publicacao");

        }


    }
}