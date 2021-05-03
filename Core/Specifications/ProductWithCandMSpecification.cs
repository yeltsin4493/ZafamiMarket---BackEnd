using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithCandMSpecification : BaseSpecification<Producto>
    {
        public ProductWithCandMSpecification()
        {
            AddInclude(c => c.Categoria);
            AddInclude(m => m.Marca);
        }

        public ProductWithCandMSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(c => c.Categoria);
            AddInclude(m => m.Marca);
        }
    }
}
