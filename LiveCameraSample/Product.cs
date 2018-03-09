using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCameraSample
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
     
        public DateTime Date { get; set; }        
        public string Thumbnail { get; set; }
        public string Type { get; set; }

        public List<Product> getAllTrasctions()
        {
            List<Product> photoList = new List<Product>();
            photoList.Add(new Product { Thumbnail = "https://img-vakko.cubecdn.net/files/p/868139099568-1-r3.jpg", Name = "Ceket Dokulu", Amount = "540", Type = "Online", Date = new DateTime(2017,11,05)});
            photoList.Add(new Product { Thumbnail = "https://img-vakko.cubecdn.net/files/p/868167001657-1-r3.jpg", Name = "Mavi Gömlek", Amount = "110", Type = "Online", Date = new DateTime(2017, 11, 05) });
            photoList.Add(new Product { Thumbnail = "https://img-vakko.cubecdn.net/files/p/868012796560-1-r4.jpg", Name = "Ceket Dokulu", Amount = "480", Type = "Online",  Date = new DateTime(2017,07,12)});
            photoList.Add(new Product { Thumbnail = "https://img-vakko.cubecdn.net/files/p/868167001574-1-r3.jpg", Name = "Çizgili Mavi Gömlek", Amount = "90", Type = "Online", Date = new DateTime(2017, 07, 12) });
            photoList.Add(new Product { Thumbnail = "https://img-vakko.cubecdn.net/files/p/868167006530-1-r3.jpg", Name = "Ceket Dokulu", Amount = "325", Type = "Online",  Date = new DateTime(2017,02,01)});                        
            photoList.Add(new Product { Thumbnail = "https://img-vakko.cubecdn.net/files/p/868139092482-1-r3.jpg", Name = "Kareli Mavi Gömlek", Amount = "120", Type = "Online", Date = new DateTime(2017, 02, 01) });

            return photoList;
        }
    }
}
