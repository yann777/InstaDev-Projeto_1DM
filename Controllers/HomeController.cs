using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using InstaDev_Projeto_1DM.Models;


namespace InstaDev_Projeto_1DM.Controllers
{
    public class HomeController : Controller
    {
       


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            ViewBag.User = HttpContext.Session.GetString("_User");
            Cadastro cadastroModel = new Cadastro();
            ViewBag.Cadastros = cadastroModel.ReadAll();
            Publicacao publicacaoModel = new Publicacao();
            ViewBag.Publicacoes = publicacaoModel.ReadAll(); 
            return View();
        }

    }   
}

