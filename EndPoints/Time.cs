using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.EndPoints
{
    public class Time : ProjectTemplate.HTTPBackend.HTTPEndPoint
    {
        public Time(string _path) : base(_path)
        {
        }
    }
}
