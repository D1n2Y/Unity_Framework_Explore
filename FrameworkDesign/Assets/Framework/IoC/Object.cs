using System;

namespace Framework.IoC
{
    internal class Object : IObject
    {
        private readonly Type _type;

        Type IObject.Type => _type;

        internal Object(Type type)
        {
            _type = type;
        }

        internal object New(IObject @object)
        {
            return @object?.Type == null ? default : Activator.CreateInstance(@object.Type);
        }
    }
}
