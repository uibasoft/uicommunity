using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Dominio.Entities
{
    public interface IEntity : IEntity<long>
    {
    }
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
    public abstract class Entity : Entity<long>
    {
    }
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        private const int HashMultiplier = 31;
        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TPrimaryKey>))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            var other = (Entity<TPrimaryKey>)obj;
            if (IsTransient() && other.IsTransient())
            {
                return false;
            }
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        private int? cachedHashcode;
        public virtual TPrimaryKey Id { get; set; }
        public virtual bool IsTransient()
        {
            return this.Id == null || this.Id.Equals(default(TPrimaryKey));
        }

        public override int GetHashCode()
        {
            if (this.cachedHashcode.HasValue)
            {
                return this.cachedHashcode.Value;
            }

            if (this.IsTransient())
            {
                this.cachedHashcode = base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    var hashCode = this.GetType().GetHashCode();
                    this.cachedHashcode = (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
                }
            }

            return this.cachedHashcode.Value;
        }
        public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"[ Name:{GetType().Name}, Id:{Id}]";
        }

    }
}
