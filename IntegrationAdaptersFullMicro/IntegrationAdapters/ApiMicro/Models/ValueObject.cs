using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Models
{
    public abstract class ValueObject
    {
        protected abstract void Validate();

        protected abstract bool EqualsValue(Object o);

        protected abstract String PrintObject();



    }
}
