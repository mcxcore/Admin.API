using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Admin.DynamicApi.Enums;
using Microsoft.AspNetCore.Http;

namespace Admin.DynamicApi
{
    public class DynamicApiOptions
    {

        public DynamicApiOptions()
        {
            RemoveControllerPostfixes = new List<string>() { "AppService", "ApplicationService", "ApiController", "Controller", "Services", "Service" };
            RemoveActionPostfixes = new List<string>() { "Async" };
            FormBodyBindingIgnoredTypes = new List<Type>() { typeof(IFormFile) };
            DefaultHttpVerb = "POST";
            DefaultApiPrefix = "api";
            AssemblyDynamicApiOptions = new Dictionary<Assembly, AssemblyDynamicApiOptions>();
        }

        /// <summary>
        /// 默认http请求方式
        /// </summary>
        public string DefaultHttpVerb { get; set; }

        public string DefaultAreaName { get; set; }

        public string DefaultApiPrefix{ get; set; }

        /// <summary>
        /// 移除后缀
        /// </summary>
        public List<string> RemoveControllerPostfixes { get; set; }

        public List<string> RemoveActionPostfixes { get; set; }

        public List<Type> FormBodyBindingIgnoredTypes { get; set; }

        public NamingConventionEnum NamingConvention { get; set; } = NamingConventionEnum.KebabCase;

        public Func<string, string> GetRestFulActionName { get; set; }

        public Func<string, string> GetRestFulControllerName { get; set; }

        public Dictionary<Assembly, AssemblyDynamicApiOptions> AssemblyDynamicApiOptions { get; }

        public ISelectController SelectController { get; set; } = new DefaultSelectController();

        public IActionRouteFactory ActionRouteFactory { get; set; } = new DefaultActionRouteFactory();

        public void Valid() {
            if (string.IsNullOrEmpty(DefaultHttpVerb)) {
                throw new ArgumentException($"{nameof(DefaultHttpVerb)} can not be empty.");
            }
            if (string.IsNullOrEmpty(DefaultAreaName))
            {
                DefaultAreaName = string.Empty;
            }

            if (string.IsNullOrEmpty(DefaultApiPrefix))
            {
                DefaultApiPrefix = string.Empty;
            }

            if (FormBodyBindingIgnoredTypes == null)
            {
                throw new ArgumentException($"{nameof(FormBodyBindingIgnoredTypes)} can not be null.");
            }

            if (RemoveControllerPostfixes == null)
            {
                throw new ArgumentException($"{nameof(RemoveControllerPostfixes)} can not be null.");
            }
        }

        public void AddAssemblyOptions(Assembly assembly, string apiPreFix = null, string httpVerb = null)
        {
            if (assembly == null)
            {
                throw new ArgumentException($"{nameof(assembly)} can not be null.");
            }

            this.AssemblyDynamicApiOptions[assembly] = new AssemblyDynamicApiOptions(apiPreFix, httpVerb);
        }

        public void AddAssemblyOptions(Assembly[] assemblies, string apiPreFix = null, string httpVerb = null)
        {
            if (assemblies == null)
            {
                throw new ArgumentException($"{nameof(assemblies)} can not be null.");
            }

            foreach (var assembly in assemblies)
            {
                AddAssemblyOptions(assembly, apiPreFix, httpVerb);
            }
        }
    }
}
