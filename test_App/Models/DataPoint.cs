
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace test_App.Models
{
    public class DataPoint
    {
        public DataPoint(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        //setting the name wile serializing to JSON
        public Nullable<int> X = null;
        //setting the name wile serializing to JSON
        public Nullable<int> Y = null;
        //setting the name wile serializing to JSON
        public Nullable<int> Z = null;
    }
}