﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PortalNFE.Core.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            return modelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }
}
