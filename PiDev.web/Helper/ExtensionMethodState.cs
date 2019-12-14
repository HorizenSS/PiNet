using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Helper
{
    public static class ExtensionMethodState
    {
        public static IEnumerable<SelectListItem> ToSelectItem(this IEnumerable<String> TS)
        {
            return TS.OrderBy(state => TS)
                  .Select(state =>
                  new SelectListItem
                  {
                      Text = state,
                      Value = state
                  });
        }
    }
}