using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Infrastructure.Repositories
{
    public interface  IRepository<T> where T:class
    {
        List<T> Movies();
    }
}
