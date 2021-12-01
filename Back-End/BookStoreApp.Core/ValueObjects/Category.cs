using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.ValueObjects
{
    public class Category
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            //Guard or Exception check.
            Name = name;
        }
    }
}
