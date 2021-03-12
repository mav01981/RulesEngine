using System;

namespace RulesEngineLibrary
{
    public interface IDiscount
    {
        bool IsMatch<T>(T customer);
        decimal Calculate<T>(T customer);
    }
}