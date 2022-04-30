using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.DynamicApi
{
    public class AssemblyDynamicApiOptions
    {
        public string ApiPrefix { get; }

        public string HttpVerb { get; }

        public AssemblyDynamicApiOptions(string apiPrefix, string httpVerb)
        {
            ApiPrefix = apiPrefix;
            HttpVerb = httpVerb;
        }
    }
}
