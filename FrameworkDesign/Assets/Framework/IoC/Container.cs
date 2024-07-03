using System;
using System.Collections.Generic;

namespace Framework.IoC
{
    public class Container
    {
        private readonly Dictionary<Type, Dictionary<string, Object>> _dicTypeDicNameObject =
            new Dictionary<Type, Dictionary<string, Object>>();

        public void Register<TClass, TClassImpl>(string name = default)
            where TClass : class
            where TClassImpl : TClass, new()
        {
            Register(typeof(TClass), name, new Object(typeof(TClassImpl)));
        }

        public void RegisterSingleton<TClass, TClassImpl>(TClassImpl instance = default, string name = default)
            where TClass : class
            where TClassImpl : TClass, new()
        {
            var singleton = instance == null ? new SingletonObject(typeof(TClassImpl)) : new SingletonObject(instance);

            Register(typeof(TClass), name, singleton);
        }

        public TClass Resolve<TClass>(string name = default)
            where TClass : class
        {
            return Resolve(typeof(TClass), name) as TClass;
        }

        private object Resolve(Type type, string name)
        {
            if (type == null ||
                !_dicTypeDicNameObject.TryGetValue(type, out Dictionary<string, Object> dicNameObject) ||
                !dicNameObject.TryGetValue(name ?? string.Empty, out var @object))
            {
                return default;
            }

            object obj;

            if (@object is ISingleton singleton)
            {
                obj = singleton.Object;
            }
            else
            {
                obj = @object?.New(@object);
            }

            return obj;
        }

        private void Register(Type type, string name, Object @object)
        {
            if (type == null)
            {
                return;
            }

            if (!_dicTypeDicNameObject.TryGetValue(type, out Dictionary<string, Object> dicNameObject))
            {
                dicNameObject = new Dictionary<string, Object>();
                _dicTypeDicNameObject[type] = dicNameObject;
            }

            dicNameObject[name ?? string.Empty] = @object;
        }
    }
}
