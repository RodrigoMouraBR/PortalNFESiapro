using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PortalNFE.Core.Extensions
{
    public static class RegexMaskText
    {
        public static string RemoveMask(string pProperty)
        {
            if (pProperty == string.Empty) return string.Empty;
          
            string remveMask = pProperty;
            if (!Regex.IsMatch(pProperty, @"^[a-zA-Z]+$"))
            {
                remveMask = Regex.Replace(pProperty, "[^0-9]", "");
            }

            return remveMask;
        }
    }
}
