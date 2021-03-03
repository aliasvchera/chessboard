using Microsoft.AspNetCore.Mvc;


namespace ChessBoard.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
