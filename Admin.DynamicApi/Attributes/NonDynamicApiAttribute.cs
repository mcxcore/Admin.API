using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.DynamicApi.Attributes
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Interface|AttributeTargets.Class|AttributeTargets.Method)]
    public class NonDynamicApiAttribute:Attribute
    {
    }
}
