﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNFE.Register.Company.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DateRegister = DateTime.Now;
            DateChanged = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; protected set; }
        public DateTime DateRegister { get; protected set; }
        public DateTime? DateChanged { get; protected set; }       

        public void ChangeDateChanged()
        {
            this.DateChanged = DateTime.Now;
        }
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
