using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsCloning
{
    public static class ObjectCloner
    {
        public static T Clone<T>(this T source)
        {
            //TODO filter other specific types (List, Array ...)
            #region Value or specific type


            //if source is a ValueType - return source
            if (source.GetType().IsValueType ||
                source.GetType().Equals(typeof(string))
                )
                return source;
            #endregion

            //Try to get default constructor
            ConstructorInfo ctor = source.GetType().GetConstructor(new Type[] { });

            #region Without default constructor
            //If type don`t have default ctor - return reference (or Exception)
            if (ctor == null)
            {
                return source;
                // throw new Exception("No default " + source.GetType().Name + " constructor found!");
            }
            #endregion

            #region With default constructor
            //Create instance of the object
            var result = (T)Activator.CreateInstance(source.GetType());

            //Fill fields with similar values (Only first level cloning)
            foreach (var field in source.GetType().GetRuntimeFields())
            {
                    field.SetValue(result, field.GetValue(source)); // Create and set new instanse of similar object
            }

            return result;
            #endregion
        }

    }
}
