using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailspin.Entity;

namespace Tailspin.Data
{
    public interface IToyRepository
    {
        IEnumerable<Toy> Get();
    }


    public class ToyRepository : IToyRepository
    {
        private string _connectionString;
        public ToyRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public IEnumerable<Toy> Get()
        {
            var list = new List<Toy>();
            list.Add(new Toy { Name = "Airplane", Description = "wind up", Price = 94.3 });
            return (list);
        }
    }

}
