using PiDev.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PiDev.web.Models;

namespace Web.Helper
{
    public static class ExtensionProjectName
    {
        public static IEnumerable<SelectListItem> dropDownList(this IEnumerable<SkillVM> projectName)
        {
            return projectName.OrderBy(a => a.skillId).Select(a => new SelectListItem
            {
                Text = a.name,
                Value = a.category.ToString()

            });
        }
    }
}