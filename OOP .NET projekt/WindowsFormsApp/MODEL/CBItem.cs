using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.MODEL
{
    class CBItem
    {

        public string _Name;
        public string _Id;

      public CBItem(string name, string id)
        {
            _Name = name;
            _Id = id;
        }
        public override string ToString()
        {
            return _Name;
        }
        public string getID()
        {
            return _Id;
        }
    }
}
