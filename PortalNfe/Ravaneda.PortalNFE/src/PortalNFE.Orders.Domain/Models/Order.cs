﻿using PortalNFE.Core.DomainObjects;

namespace PortalNFE.Orders.Domain.Models
{
    public class Order : Entity
    {
        public string IDDEST { get; set; } = string.Empty;
        public string INDFINAL { get; set; } = string.Empty;
        public string INDPRES { get; set; } = string.Empty;
        public string XPED { get; set; } = string.Empty;
        public string NITEMPED { get; set; } = string.Empty;
        public string CSOSN { get; set; } = string.Empty;
        public string PCREDSN { get; set; } = string.Empty;
        public string VCREDICMSSN { get; set; } = string.Empty;
    }
}
