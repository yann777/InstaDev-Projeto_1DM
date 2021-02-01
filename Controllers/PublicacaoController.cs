using System.Collections.Generic;
using System.IO;
using System.Linq;
using InstaDev_Projeto_1DM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Projeto_1DM.Controllers
{
    public class PublicacaoController : Controller
    {
        Publicacao publicacaoModel = new Publicacao();

        public IActionResult Index()
        {
            ViewBag.Publicacoes = publicacaoModel.ReadAll();
            return View();
        }

        [Route("CadastrarPublicacao")]
        public IActionResult Cadastrar(IFormCollection form)
        {
           
                Publicacao novaPublicacao = new Publicacao();
            
                var id = publicacaoModel.ReadAll().Count(); //Count() Serve para contar as linhas de um arquivo ou a quantidade de objetos


                novaPublicacao.Legenda = form["Legenda"];
                novaPublicacao.IdPublicacao = id+1;
                
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
        public IActionResult Excluir(int IdUser)
        {
            publicacaoModel.Delete(IdUser);
            return LocalRedirect("~/Publicacao");

        }

    }
}