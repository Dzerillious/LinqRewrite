﻿using System;
using System.Collections.Generic;

namespace LinqRewrite.Core
{
    public static class ExtendedLinq
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
                action(item);
        }
    }
}