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
            var produtos = catalogoCN.ObterProdutos();
            return Json( produtos );
        }

        public IActionResult ObterUmaFoto(int id, int numero)
        {
            CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();

            byte[] foto = produtoCN.ObterUmaFoto(id, numero);


            if (foto == null)
            {
                return File("~/img/sem_foto.jpg", "image/jpg");
            }
            return File(foto, "image/jpg");

        }
    }
}