using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tailspin.Business;
using Tailspin.Entity;

namespace Tailspin.Web.Controllers
{
    public class CheckinsController : ApiController
    {
        
        private IToyService _toyService;

        public CheckinsController()
        {
            IToyService toyService = MvcApplication.container.Resolve<IToyService>(); 
            _toyService = toyService;
        }

         

        public IEnumerable<Toy> Get()
        {
            return this._toyService.Get() ;
        }





    }
}
