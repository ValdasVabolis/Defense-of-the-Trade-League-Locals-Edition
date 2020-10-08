﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Support_Your_Locals.Tests {
    public class Comparer {

        public static Comparer<U> Get<U>(Func<U, U, bool> func) => new Comparer<U>(func);

        }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;

        public Comparer(Func<T, T, bool> func) => comparisonFunction = func;

        public bool Equals(T x, T y) => comparisonFunction(x, y);

        public int GetHashCode(T obj) => obj.GetHashCode();
        
    }
}