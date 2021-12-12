using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.ValueObjects
{
    public class PublicationDate
    {
        public DateTime Date { get; set; }

        public PublicationDate(DateTime date)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    throw new EmptyPackingListItemNameException();
            //} Guard or Exception.

            Date = date;
        }
        public static PublicationDate Create(DateTime value)
        {
            return new PublicationDate(value);
        }

        public override string ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}";
        }
    }
}
