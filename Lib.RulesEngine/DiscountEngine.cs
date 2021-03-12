using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RulesEngineLibrary
{
    public class DiscountEngine
    {
        private IList<IDiscount> _discounts = new List<IDiscount>();

        public DiscountEngine()
        {
            List<Assembly> assemblies = new List<Assembly>();
            var path = Path.GetDirectoryName(AppConfig.PluginPath());

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                assemblies.Add(Assembly.LoadFile(dll));

            foreach (var assembly in assemblies)
            {
                var discounts = assembly.GetTypes().Where(x => typeof(IDiscount).IsAssignableFrom(x) && !x.IsInterface);
                foreach (var discount in discounts)
                {
                    _discounts.Add((IDiscount)Activator.CreateInstance(discount));
                }
            }
        }

        public decimal CalculateDiscount<T>(T customer)
        {
            decimal discount = 0m;
            foreach (var rule in _discounts)
            {
                if (rule.IsMatch(customer))
                {
                    discount += rule.Calculate(customer);
                }
            }
            return discount;
        }
    }
}
