using System;

namespace Framework.IoC
{
    internal class SingletonObject : Object, ISingleton
    {
        private object _object;

        object ISingleton.Object => _object = _object ?? New(this);

        internal SingletonObject(Type type) : base(type)
        {
        }

        internal SingletonObject(object @object) : base(default)
        {
            _object = @object;
        }
    }
}
