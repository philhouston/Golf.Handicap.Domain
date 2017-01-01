using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.Domain
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        private readonly TId id;

        protected Entity(TId id) {
            if (object.Equals(id, default(TId))) {
                throw new ArgumentException("The ID cannot be the default value.", "id");
            }

            this.id = id;
        }

        public TId Id
        {
            get { return this.id;  }
        }

        public override bool Equals(object obj) {
            var entity = obj as Entity<TId>;
            if (entity != null)
                return this.Equals(entity);
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other) {
            if (other == null)
                return false;

            return this.Id.Equals(other.Id);
        }
    }
}
