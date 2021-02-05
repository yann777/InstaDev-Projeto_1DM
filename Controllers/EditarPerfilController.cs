using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_InstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    [Route("Editar")]
    public class EditarPerfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        Usuario usuarioModel = new Usuario();

        [Route("Usuario")]
        public IActionResult Usuario()
        {
            ViewBag.Usuarios = usuarioModel.ReadAll();
            return View();
        }

        [Route("Alterar")]
        public IActionResult Alterar(IFormCollection form)
        {
           Usuario alterarUsuario = new Usuario();
           
         
           alterarUsuario.Nome     = (form["Nome"]);
           alterarUsuario.Foto     = (form["Foto"]);
           alterarUsuario.Username = (form["Username"]); 
           alterarUsuario.Email    = (form["Email"]); 

           usuarioModel.EditarUsuario(alterarUsuario);

           ViewBag.Usuarios = usuarioModel.ReadAll();

           return LocalRedirect("~/Editar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Delete(int id)
        {
            usuarioModel.DeleteUsuario(id);

            ViewBag.Usuarios = usuarioModel.ReadAll();            

            return LocalRedirect("~/");
        }


        [Route("EditImagem")]
         public IActionResult EditImagem(IFormCollection form)
        {            
            Usuario novoUsuario   = new Usuario();
            novoUsuario.IdUsuario = Int32.Parse(form["IdUsuario"]);
            novoUsuario.Foto      = form["Foto"];

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
                novoUsuario.Foto   = file.FileName;                
            }
            else
            {
                novoUsuario.Foto   = "padrao.png";
            }
            // Upload Final

            usuarioModel.CadastrarUsuario(novoUsuario);
            ViewBag.Usuarios = usuarioModel.ReadAll();
            
            return LocalRedirect("~/Editar");

        }

    }
}