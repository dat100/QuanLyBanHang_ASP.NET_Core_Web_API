using Common.BLL;
using Common.Respond;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategorySvc:GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc() 
        {
            categoryRep = new CategoryRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
    }
}
