using System;
using System.Collections.Generic;

namespace AceStream.Infrastructure.DependencyInjection
{
    public class ServiceCollection
    {
        private static Dictionary<Type, object> _values = new Dictionary<Type, object>();

        public void AddScoped<TInterface, TClass>() where TClass : TInterface, new()
        {
            _values.Add(typeof(TInterface), new TClass());
        }

        public static TInterface Get<TInterface>()
        {
            _values.TryGetValue(typeof(TInterface), out object value);

            return (TInterface)value;
        }
    }
}
