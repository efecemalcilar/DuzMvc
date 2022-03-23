using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DuzMvc.Models;

namespace DuzMvc.Dal.DumduzInitializer
{  //DuzDbContext den türemiş db yoksa burayı calıştır demek
    public class DuzInitializer:CreateDatabaseIfNotExists<DuzDbContext>
    {
        protected override void Seed(DuzDbContext context) //Seed ile En son devreeye gir diyoruz
        {
            Sahip admin = new Sahip();
            admin.Idno = "12345678901";
            admin.Name = "Efe Agici";
            admin.DTarih = DateTime.Now;
            admin.CreatedBy = "system";
            admin.CreatedDate = DateTime.Now;


            context.Sahips.Add(admin);

            for (int i = 0; i < 20; i++) //Burası verileri tabloya atmak için yazılmış.
            {
                Tasinmaz tas = new Tasinmaz()
                {
                    Aciklama = FakeData.TextData.GetSentences(5),
                    AlinisFiyat =FakeData.NumberData.GetNumber(99999999),
                    Adres = FakeData.PlaceData.GetAddress(),
                    Name = FakeData.TextData.GetAlphabetical(50),
                    SahipId = admin.Id,
                    AlinisTarih = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-3),DateTime.Now),
                    Sehir = FakeData.PlaceData.GetCity(),
                    CreatedDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-3), DateTime.Now),
                    CreatedBy = "system"

                };
                context.Tasinmazes.Add(tas);

            }

            context.SaveChanges();
        }
    }
}