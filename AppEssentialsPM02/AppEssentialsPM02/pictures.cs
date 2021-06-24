using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEssentialsPM02
{

    public class pictures
    {
        [AutoIncrement, PrimaryKey]
        public int id { set; get; }

        public string ImageRoute { get; set; }
    }
}
