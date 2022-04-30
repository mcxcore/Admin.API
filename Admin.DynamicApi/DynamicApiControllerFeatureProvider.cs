using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Admin.DynamicApi
{
    public class DynamicApiControllerFeatureProvider: ControllerFeatureProvider
    {
        private ISelectController _selectController;

        public DynamicApiControllerFeatureProvider(ISelectController selectController)
        {
            _selectController = selectController;
        }

        protected override bool IsController(TypeInfo typeInfo)
        {
            return _selectController.IsController(typeInfo);
        }
    }
}
