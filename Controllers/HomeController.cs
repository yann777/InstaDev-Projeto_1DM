﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstaDev_Projeto_1DM.Models;
using Microsoft.AspNetCore.Http;

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
            // ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            // ViewBag.User = HttpContext.Session.GetString("_User");
            // ViewBag.UserId = HttpContext.Session.GetString("_UserId");
            
            Publicacao publicacaoModel = new Publicacao();
            ViewBag.Publicacoes = publicacaoModel.ReadAll(); 
            return View();
        }
    }
}
