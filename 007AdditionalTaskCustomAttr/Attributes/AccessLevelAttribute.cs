using System;

namespace _007AdditionalTaskCustomAttr.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true)]
    class AccessLevelAttribute : Attribute
    {
        public AccessLevel AccessLevel { get; private set;}

        public AccessLevelAttribute(AccessLevel level)
        {
            AccessLevel = level;
        }
    }
}
