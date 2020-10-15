using System;
using System.Collections.Generic;

namespace AceStream.Infrastructure.DependencyInjection
{
    public class ServiceCollection
    {
        private static Dictionary<Type, object> _values = new Dictionary<Type, object>();

        public void AddScoped<TInterface, TClass>() where TClass : TInterface, new()
        {
            var key = typeof(TInterface);
            var value = new TClass();

            if (_values.ContainsKey(key))
            {
                _values[key] = value;
            }
            else
            {
                _values.Add(key, value);
            }
        }

        public static TInterface Get<TInterface>()
        {
            _values.TryGetValue(typeof(TInterface), out object value);

            return (TInterface)value;
        }
    }
}
