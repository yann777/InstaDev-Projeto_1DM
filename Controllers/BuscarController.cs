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
    public class BuscarController : Controller
    {
        
        public IActionResult Buscar(IFormCollection form)
        {
            Cadastro usuario = new Cadastro();
            List<string> csv = usuario.ReadAllLinesCSV("Database/usuario.csv");

            var busca = csv.Find(
                x => 
                x.Split(";")[2] == form["Username"] &&
                x.Split(";")[7] == form["pesquisar"]
            );

            return LocalRedirect("~/");

        }


    }
}