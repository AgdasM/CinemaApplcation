using EnocaChallenge.Application.Abstractions;
using EnocaChallenge.Application.DTO;
using EnocaChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge.Persistence.Concretes
{
    public class FilmServices : IFilmServices
    {

        EnocaContext context = new EnocaContext();

        public bool AdminLogin(AdminLoginPanel_DTO admin)
        {
            try
            {
                var sorgu = context.AdminTbls.SingleOrDefault(x => x.AdminName==admin.AdminName && x.Password==admin.Password);
                if (sorgu!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
       
        }

        public List<FilmListeleme2tariharası_DTO> FilmArama1(int minYıl, int maxYıl)
        {
            try
            {
                List<FilmListeleme2tariharası_DTO> model = context.FilmTbls.Select(x => new FilmListeleme2tariharası_DTO()
                {
                    FilmID=x.FilmId,
                    FilmAd=x.FilmAd,
                    FilmYapımyıl=x.FilmYapımyıl
                }).Where(x => Convert.ToInt32(x.FilmYapımyıl)>minYıl && Convert.ToInt32(x.FilmYapımyıl)<maxYıl).ToList();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public bool FilmEkleme(FilmEkle_DTO film)
        {
            try
            {
                var Sorgu = context.FilmTbls.SingleOrDefault(x => x.FilmAd==film.FilmAd && x.FilmYapımyıl==film.FilmYapımyıl);
                if (Sorgu==null)
                {
                    FilmTbl model = new FilmTbl();
                    model.FilmAd=film.FilmAd;
                    model.FilmYapımyıl=film.FilmYapımyıl;
                    context.FilmTbls.Add(model);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
            
           
        }

        public bool FilmGüncelleme(Film_DTO model)
        {
            try
            {
                var sorgu = context.FilmTbls.SingleOrDefault(x => x.FilmId==model.FilmID);
                if (sorgu!=null)
                {

                    sorgu.FilmAd=model.FilmAd;
                    sorgu.FilmYapımyıl=model.FilmYapımyıl;
                    context.FilmTbls.Update(sorgu);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public List<Film_DTO> FilmListele()
        {
            try
            {
                List<Film_DTO> list = context.FilmTbls.Select(x => new Film_DTO()
                {
                    FilmAd=x.FilmAd,
                    FilmID=x.FilmId,
                    FilmYapımyıl=x.FilmYapımyıl
                }).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        public List<FilmListeleme33_DTO> FilmListele33(int id)
        {
            try
            {
                var sonuc = from F in context.FilmTbls
                            join G in context.GösterimTbls on F.FilmId equals G.FilmId
                            join S in context.SalonTbls on G.SalonId equals S.SalonId
                            where S.SalonId==id
                            select new FilmListeleme33_DTO()
                            {
                                FilmAd=F.FilmAd,
                                GösterimTarihi=G.GösterimTarihi

                            };
                List<FilmListeleme33_DTO> model = sonuc.Select(x => new FilmListeleme33_DTO()
                {

                    FilmAd=x.FilmAd,
                    GösterimTarihi=x.GösterimTarihi
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }
            
          
        }

        public List<FilmListeleme2tariharası_DTO> FilmListeleme2()
        {
            try
            {
                List<FilmListeleme2tariharası_DTO> list = context.FilmTbls.Select(x => new FilmListeleme2tariharası_DTO()
                {
                    FilmAd=x.FilmAd,
                    FilmID=x.FilmId,
                    FilmYapımyıl=x.FilmYapımyıl
                }).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public List<FilmListele21_DTO> FilmSalonListele(int id)
        {
            try
            {
                var sonuc = from F in context.FilmTbls
                            join G in context.GösterimTbls on F.FilmId equals G.FilmId
                            join S in context.SalonTbls on G.SalonId equals S.SalonId
                            where F.FilmId==id
                            select new FilmListele21_DTO()
                            {

                                FilmAd=F.FilmAd,
                                SalonAd=S.SalonAd,
                                GösterimTarihi=G.GösterimTarihi
                            };
                List<FilmListele21_DTO> model = sonuc.Select(x => new FilmListele21_DTO()
                {

                    SalonAd=x.SalonAd,
                    GösterimTarihi=x.GösterimTarihi,
                    FilmAd=x.FilmAd
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool FilmSilme(int id)
        {
            try
            {
                var model = context.FilmTbls.SingleOrDefault(x => x.FilmId==id);
                if (model !=null)
                {
                    context.FilmTbls.Remove(model);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            
             
        }

        public List<FilmListeleme3_DTO> SalonListele()
        {
            try
            {
                List<FilmListeleme3_DTO> list = context.SalonTbls.Select(x => new FilmListeleme3_DTO()
                {
                    SalonId=x.SalonId,
                    SalonAd=x.SalonAd
                }).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }
    }
}
