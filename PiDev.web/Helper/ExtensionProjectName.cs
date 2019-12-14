using PiDev.Domain;
using Data;
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
        public static IEnumerable<SelectListItem> dropDownList(this IEnumerable<positionOfferVM> projectName)
        {
            return projectName.OrderBy(a => a.IdPositionOffer).Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.IdPositionOffer.ToString()

            });
        }
    }
}