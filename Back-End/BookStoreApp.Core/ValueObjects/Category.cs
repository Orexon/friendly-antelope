using BookStoreApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.ValueObjects
{
    public class Category : ValueObject
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            //Guard or Exception check.
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
