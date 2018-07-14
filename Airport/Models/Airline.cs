using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Airline
    {
        #region attributes

        private string _id;
        private string _name;

        #endregion

        #region properties

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region constructors

        public Airline()
        {
            _id = "";
            _name = "";
        }

        public Airline(string id, string name)
        {
            _id = id;
            _name = name;
        }

        #endregion

        #region methods

        public override string ToString()
        {
            return _name;
        }
        #endregion
    }
}
