using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class BusinessResponse<T> where T : new()
    {
        public string Msg { get; set; }
        public bool Error { get; set; }
        public T UnitResp { get; set; }
        List<T> _lst;
        public List<T> Lst
        {
            get { return _lst == null ? new List<T>() : _lst; }
            set { _lst = value; }
        }
    }
}
