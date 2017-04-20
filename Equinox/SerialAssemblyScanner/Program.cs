using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SerialAssemblyScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom(args[0]);
            Type[] types = asm.GetTypes();
            List<Type> matched = new List<Type>();
            for (int i = 0; i < types.Length; i++)
                if (Attribute.GetCustomAttribute(types[i], typeof(System.SerializableAttribute)) != null)
                    matched.Add(types[i]);
            for (int i = 0; i < matched.Count; i++)
            {
                Console.WriteLine(matched[i].FullName);
                //Console.Write(";");
            }
        }
    }
}
