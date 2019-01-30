using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_1_OOP.InternetShop
{
    public class BayersBasket : WareHouse
    {
        public BayersData bayer;
        public List<Article> bayersArticles;
    }

    public struct BayersData
    {
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string deliveredAdress { get; set; }
    }
}
