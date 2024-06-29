using System;

namespace Framework.Bindable
{
    public class Bindable<T>
        where T : IEquatable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                _value = value;
                ValueChanged?.Invoke(value);
            }
        }

        public event Action<T> ValueChanged;

        public static Bindable<T> New(T value)
        {
            return new Bindable<T>
            {
                _value = value
            };
        }
    }
}
