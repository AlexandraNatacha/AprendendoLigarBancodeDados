using Microsoft.AspNetCore.Mvc;

namespace AprendendoLigarBancodeDados.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
