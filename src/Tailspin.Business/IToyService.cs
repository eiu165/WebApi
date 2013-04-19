using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailspin.Data;
using Tailspin.Entity;

namespace Tailspin.Business
{

    public interface IToyService
    {
        IEnumerable<Toy> Get();
    }
    public class ToyService : IToyService
    {
        public IToyRepository _toyRepository;
        public ToyService(IToyRepository toyRepository)
        {
            this._toyRepository = toyRepository;
        }
        public IEnumerable<Toy> Get()
        {
            return _toyRepository.Get();
        }
    }
}
