using EnocaChallenge.Application.Abstractions;
using EnocaChallenge.Application.DTO;
using EnocaChallenge.ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnocaChallenge.ASPNET_MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFilmServices _filmServices;
        public AdminController(IFilmServices filmServices)
        {
            _filmServices=filmServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminPanelLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminPanelLogin(AdminPanelViewModel admin)
        {
             AdminLoginPanel_DTO model= new AdminLoginPanel_DTO();
            model.AdminName=admin.AdminName;
            model.Password=admin.Password;
            bool sonuc = _filmServices.AdminLogin(model);
            if (sonuc==true)
            {
                return RedirectToAction("AdminPanel", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage="Admin Name or password are incorrect..";
            }
            return View();
        }
        public IActionResult AdminPanel()
        {

            return View();
        }
        [HttpGet]
        public IActionResult FilmEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FilmEkle(FilmEkleViewModel film)
        {
            FilmEkle_DTO model = new FilmEkle_DTO();
            model.FilmAd=film.FilmAd;
            model.FilmYapımyıl=film.FilmYapımyıl;
            bool sonuc = _filmServices.FilmEkleme(model);
            if (sonuc==true)
            {
                return RedirectToAction("FilmEkle", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage="Film already exist";
                return View();
            }
            
           
        }
        [HttpGet]
        public IActionResult FilmGüncelle2(GüncelleViewModel film)
        {
            GüncelleViewModel model = new GüncelleViewModel();
            model.FilmID=film.FilmID;
            model.FilmAd=film.FilmAd;
            model.FilmYapımyıl=film.FilmYapımyıl;
            return View(model);
        }
        [HttpPost]
        public IActionResult FilmGüncelle3(GüncelleViewModel model)
        {
            Film_DTO film = new Film_DTO();
            film.FilmID=model.FilmID;
            film.FilmAd=model.FilmAd;
            film.FilmYapımyıl=model.FilmYapımyıl;
            bool sonuc = _filmServices.FilmGüncelleme(film);
            if (sonuc==true)
            {
                return RedirectToAction("FilmGüncelle", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage="Unsuccessfully Update";
                return View();
            }

        }
        [HttpGet]
        public IActionResult FilmGüncelle()
        {
            List<Film_DTO> list = _filmServices.FilmListele();
            List<GüncelleViewModel> model = list.Select(x => new GüncelleViewModel()
            {
                FilmID=x.FilmID,
                FilmAd=x.FilmAd,
                FilmYapımyıl=x.FilmYapımyıl
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult FilmDeleteListele()
        {
            List<Film_DTO> list = _filmServices.FilmListele();
            List<DeleteViewModel> model = list.Select(x => new DeleteViewModel()
            {
                FilmID=x.FilmID,
                FilmAd=x.FilmAd,
                FilmYapımyıl=x.FilmYapımyıl
            }).ToList();
            return View(model);
        }
        public IActionResult FilmDelete(int filmId)
        {
            bool sonuc = _filmServices.FilmSilme(filmId);
            if (sonuc ==true)
            {
                return RedirectToAction("FilmDeleteListele","Admin");
            }
            else
            {
                ViewBag.ErrorMessage="Delete Failed";
                return View();
            }
        }
        [HttpGet]
        public IActionResult FilmListeleme()
        {
            List<FilmListViewModel> aa = new List<FilmListViewModel>();
           
            return View(aa);
        }
        [HttpPost]
        public IActionResult FilmListeleme(int minYıl,int maxYıl)
        {
            List<FilmListeleme2tariharası_DTO> model = _filmServices.FilmArama1(minYıl, maxYıl);
            List<FilmListViewModel> list = model.Select(x => new FilmListViewModel()
            {
                FilmID=x.FilmID,
                FilmAd=x.FilmAd,
                FilmYapımyıl=x.FilmYapımyıl
            }).ToList();
            return View(list);
        }

        public IActionResult FilmListeleme2()
        {

            List<FilmListeleme2tariharası_DTO> list = _filmServices.FilmListeleme2();
            List<FilmListeleme2ViewModel> model = list.Select(x => new FilmListeleme2ViewModel()
            {
                FilmID=x.FilmID,
                FilmAd=x.FilmAd,
                FilmYapımyıl=x.FilmYapımyıl
            }).ToList();

            return View(model);
        }
        public IActionResult FilmListele21(int filmId)
        {
            List<FilmListele21_DTO> model = _filmServices.FilmSalonListele(filmId);
            List<FilmListele21ViewModel> list = model.Select(x => new FilmListele21ViewModel()
            {
                
                SalonAd=x.SalonAd,
                GösterimTarihi=x.GösterimTarihi,
                FilmAd=x.FilmAd
            }).ToList();
            return View(list);
        }
        public IActionResult FilmListeleme3()
        {
            List<FilmListeleme3_DTO> list = _filmServices.SalonListele();
            List<FilmListeleme3ViewModel> model = list.Select(x => new FilmListeleme3ViewModel()
            {
                SalonAd=x.SalonAd,
                SalonId=x.SalonId
          
            }).ToList();

            return View(model);
           
        }
        public IActionResult FilmListeleme33(int salonıd)
        {
            List<FilmListeleme33_DTO> model = _filmServices.FilmListele33(salonıd);
            List<FilmListeleme33ViewModel> list = model.Select(x => new FilmListeleme33ViewModel()
            {

               
                GösterimTarihi=x.GösterimTarihi,
                FilmAd=x.FilmAd
            }).ToList();
            return View(list);
           
        }
    }
}
