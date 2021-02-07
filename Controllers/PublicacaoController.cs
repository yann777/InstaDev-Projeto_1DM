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

        Cadastro cadastroModel = new Cadastro();

        Comentario comentario = new Comentario();
        
        public IActionResult Index()
        {

            ViewBag.User = HttpContext.Session.GetString("_User");
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.UserId = HttpContext.Session.GetString("_UserId");
            ViewBag.Email = HttpContext.Session.GetString("_Email");
            ViewBag.Imagem = HttpContext.Session.GetString("_Imagem");
            
            ViewBag.Cadastros = cadastroModel.ReadAll();

            ViewBag.Publicacao = publicacaoModel.ReadAll();
            ViewBag.Cadastros = new Cadastro();
            ViewBag.Comentarios = new Comentario();

            
            ViewBag.Publicacoes = publicacaoModel.ReadAll();
            return View();
        }

        public int GerarId()
        {
            Random numAleatorio = new Random();
            int id = numAleatorio.Next(100, 999);
            publicacaoModel.GerarIdPostagem(id);
            while (publicacaoModel.GerarIdPostagem(id))
            {
                id = numAleatorio.Next(100, 999);
                publicacaoModel.GerarIdPostagem(id);
            }
            return id;
        }


        [Route("CadastrarPublicacao")]
        public IActionResult Cadastrar(IFormCollection form)
        {
           
                Publicacao novaPublicacao = new Publicacao();
                Cadastro usuario = new Cadastro();

               
                var id = publicacaoModel.ReadAll().Count(); //Count() Serve para contar as linhas de um arquivo ou a quantidade de objetos e vai gerar um valor inteiro //O problema está nesta linha

                novaPublicacao.Legenda = form["Legenda"];
                
                novaPublicacao.IdPublicacao = GerarId();

                novaPublicacao.IdUsuario = int.Parse(HttpContext.Session.GetString("_UserId"));  //Armazenei dentro de uma váriavel string //Variavel está dendo eero ao cadastrar devido ao tipo da variavel idUsuario
                
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

        [Route("Publicacao/{id}")]
        public IActionResult Excluir(int id)
        {
            publicacaoModel.Delete(id);
            comentario.Delete(id);
            ViewBag.Publicacoes = publicacaoModel.ReadAll();
            ViewBag.Comentarios = new Comentario();
            
            return LocalRedirect("~/Publicacao");
        }



        [Route("Comentario/{id}")]
        public IActionResult ExcluirComent(int id)
        {
            comentario.Delete(id);
            ViewBag.Comentarios = new Comentario();
            
            return LocalRedirect("~/Publicacao");
        }



          [Route("Comentar")]
        public IActionResult Comentar(IFormCollection form)
        {
            Publicacao publicacao = new Publicacao();
            Comentario coment = new Comentario();

            coment.IdComentario = GerarId();
            coment.IdPublicacao = int.Parse(form["id_publicacao"]);
            coment.IdUsuario = Int32.Parse(HttpContext.Session.GetString("_UserId")); 
            coment.UserName =   HttpContext.Session.GetString("_User");
            coment.Mensagem = form["Comentario"];
            comentario.Create(coment);

            return Redirect("~/Publicacao");
        }

    }
}