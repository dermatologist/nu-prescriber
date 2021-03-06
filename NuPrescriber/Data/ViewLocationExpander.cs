﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NuPrescriber.Data
{
    public class ViewLocationExpander : IViewLocationExpander
    {

        /// <summary>
        /// Used to specify the locations that the view engine should search to 
        /// locate views. https://stackoverflow.com/questions/36747293/how-to-specify-the-view-location-in-asp-net-core-mvc-when-using-custom-locations
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewLocations"></param>
        /// <returns></returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //{2} is area, {1} is controller,{0} is the action
            var f = "{2}";
            f.Replace("Controller", "");
            string[] locations = new string[] { "/Views/"+f+"/{1}/{0}.cshtml", "/Views/{2}/{1}/{0}.cshtml", "/Views/{1}/{0}.cshtml" };
            return locations.Union(viewLocations);          //Add mvc default locations after ours
        }


        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(ViewLocationExpander);
        }
    }
}
