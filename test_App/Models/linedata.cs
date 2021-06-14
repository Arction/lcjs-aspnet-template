
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace test_App.Models
{
    public class linedata
    {
        public linedata(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        //setting the name wile serializing to JSON
        public Nullable<int> X = null;
        //setting the name wile serializing to JSON
        public Nullable<int> Y = null;
    }
}