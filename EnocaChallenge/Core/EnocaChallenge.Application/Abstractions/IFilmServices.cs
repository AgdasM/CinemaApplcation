using EnocaChallenge.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Application.Abstractions
{
    public interface IFilmServices
    {
        List<FilmListeleme3_DTO> SalonListele();
        List<FilmListeleme33_DTO> FilmListele33(int id);
        bool AdminLogin(AdminLoginPanel_DTO admin);
        bool FilmEkleme(FilmEkle_DTO film);
        List<Film_DTO> FilmListele();
        List<FilmListeleme2tariharası_DTO> FilmListeleme2();
        List<FilmListele21_DTO> FilmSalonListele(int id);

        bool FilmGüncelleme(Film_DTO model);
        bool FilmSilme(int id);

        List<FilmListeleme2tariharası_DTO> FilmArama1(int minYıl,int maxYıl);

    }
}
