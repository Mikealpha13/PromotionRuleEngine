using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Infrastructure.Repositories
{
    public class RedisRepository <T>: IRepository<T> where T :class
    {
        
        
        public List<T> Movies()
        {
            throw new NotImplementedException();
        }
    }
}
