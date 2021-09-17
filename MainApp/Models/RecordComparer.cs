using System;
using System.Collections.Generic;

namespace MainApp.Models
{
    class RecordComparer : IEqualityComparer<Record>
    {
        public bool Equals(Record x, Record y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Edrp == y.Edrp && x.Email == y.Email;      
        }

        public int GetHashCode(Record obj)
        {
            return obj.Edrp.GetHashCode() + obj.Email.GetHashCode();
        }
    }
}
