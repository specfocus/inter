﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XState.State
{
    public interface SingleOrArray<T> : ICollection<T> where T : class
    {
    }
}
