
using System;
using System.Collections;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // we lose typesafety with arrayList here
            // in the list.Add() we can pass any object
            // it will use boxing and that is why is not performant
            var list = new ArrayList();
            list.Add(1);
            list.Add("Mosh");
            list.Add(DateTime.Today);

            // to unbox: but it has a penalty performance
            var number = (int)list[1];

            // the best option will be generics (only 1 type defined)
            // generics are part od the System.Collections.Generic dotnet lib
            var anotherList = new List<int>();
            var names = new List<string>();
            // if calling a method, and the methods gets an argument of type object, if pass a value type, then boxing is gonna happen.
            // better to use the generic implementation if exists
        }
    }
}
