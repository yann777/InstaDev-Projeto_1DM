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
    public class PerfilController : Controller 
    {
        public IActionResult Index()
        {
            Cadastro cadastroModel = new Cadastro();
            ViewBag.Cadastros = cadastroModel.ReadAll();
            return View();
        }
    }
}