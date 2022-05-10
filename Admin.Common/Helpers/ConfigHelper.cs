using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Common.Helpers
{
    public class ConfigHelper
    {
        public IConfiguration Load(string fileName,string environmentName="",bool reloadOnChange=false) {
            var filePath = Path.Combine(AppContext.BaseDirectory, "configs");
            if (!Directory.Exists(filePath)) return default;

            var builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile(fileName+".json",true,reloadOnChange);

            return builder.Build();
        }

        public T Get<T>(string fileName,string environmentName="",bool reloadOnChange=true)
        {
            var configuration = Load(fileName,environmentName,reloadOnChange);
            if (configuration == null) return default;
            return configuration.Get<T>();
        }
    }
}
