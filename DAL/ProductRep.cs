using Common.DAL;
using Common.Respond;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRep : GenericRep<NorthwindContext, Product>
    {
        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }

        public List<Product> SearchProduct(string Keyword)
        {            
            return All.Where(x => x.ProductName.Contains(Keyword)).ToList();
        }
    }
}
