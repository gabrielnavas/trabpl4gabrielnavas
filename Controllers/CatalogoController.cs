using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ObterProdutos()
        {
            CamadaNegocio.CatalogoCN catalogoCN = new CamadaNegocio.CatalogoCN();

            return Json( catalogoCN.ObterProdutos());
        }
    }
}