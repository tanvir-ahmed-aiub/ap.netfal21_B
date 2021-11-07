using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class PersonController : ApiController
    {
        public List<string> Get() {
            List<string> names = new List<string>();
            names.Add("tanvir");
            names.Add("rahim");
            return names;
        }
        public string Get(int id) {
            return "Name " + id;
        }
        public string Post() {
            return "Posted ";
        }
        public string Put(string name, int id) {
            return "Put " + name +" " + id;
        }
        public string Delete(string name, int id) {
            return "Deelete " + name + " " + id;
        }
    }
}
