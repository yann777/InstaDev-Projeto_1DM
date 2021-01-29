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
            Cadastro cadastroModel = new Cadastro();
            ViewBag.Cadastros = cadastroModel.ReadAll();
            ViewBag.Publicacoes = publicacaoModel.ReadAll();
            return View();
        }

        [Route("CadastrarPublicacao")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            
                Publicacao novaPublicacao = new Publicacao();
           
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

        [Route("Feed/{idPublicacao}")]
        public IActionResult Excluir(int IdUser)
        {
            publicacaoModel.Delete(IdUser);
            return LocalRedirect("~/Publicacao");

        }


    }
}