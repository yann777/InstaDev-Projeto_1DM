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
    public class EdicaoDePerfilController : Controller
    {
        Cadastro cadastroModel = new Cadastro();
        Publicacao publicacaoModel = new Publicacao();

        public IActionResult Index()
        {
            ViewBag.User = HttpContext.Session.GetString("_User");
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.UserId = HttpContext.Session.GetString("_UserId");
            ViewBag.Cadastros = cadastroModel.ReadAll();

            ViewBag.Publicacao = publicacaoModel.ReadAll();
            ViewBag.Cadastros = new Cadastro();
            ViewBag.Comentarios = new Comentario();

            return View();
        }

        Cadastro CadastroModel = new Cadastro();

        [Route("Usuario")]
        public IActionResult Cadastro()
        {
            ViewBag.Cadastros = CadastroModel.ReadAll();
            return View();
        }

        [Route("Alterar")]
        public IActionResult Alterar(IFormCollection form)
        {
           Cadastro alterarCadastro = new Cadastro();
            
           alterarCadastro.NomeCompleto     = form["Nome"];
           alterarCadastro.ImagemPerfil     = form["Foto"];
           alterarCadastro.Username         = form["Username"]; 
           alterarCadastro.Email            = form["Email"]; 

           cadastroModel.Update(alterarCadastro);

           ViewBag.Cadastros = cadastroModel.ReadAll();

           return LocalRedirect("~/EdicaoDePerfil");
        }

        [Route("Excluir/{id}")]
        public IActionResult Delete(int id)
        {
            CadastroModel.Delete(id);

            ViewBag.Cadastros = cadastroModel.ReadAll();            

            return LocalRedirect("~/");
        }


        [Route("EditImagem")]
         public IActionResult EditImagem(IFormCollection form)
        {            
            Cadastro novoCadastro         = new Cadastro();
            novoCadastro.IdUser           = Int32.Parse(HttpContext.Session.GetString("_UserId"));
            novoCadastro.ImagemPerfil     = form["Foto"];

            if(form.Files.Count > 0)
            {
                // Upload Início
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagem/Usuarios");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagem/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novoCadastro.ImagemPerfil   = file.FileName;                
            }
            else
            {
                novoCadastro.ImagemPerfil    = "padrao.png";
            }
            // Upload Final

            cadastroModel.Create(novoCadastro);
            ViewBag.Cadastros = cadastroModel.ReadAll();
            
            return LocalRedirect("~/EdicaoDePerfil");

        }
    }
}