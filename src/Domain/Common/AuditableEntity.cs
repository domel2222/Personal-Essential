namespace Domain.Common
{
    public abstract class AuditableEntity : IEquatable<AuditableEntity>
    {
        public Guid Id { get; set; }

        //public Guid Id { get; private init; }
        public Guid CreatedBy { get; set; } //guid 
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? InactivatedBy { get; set; }
        public DateTime? InactivatedDate { get; set; }

        public static bool operator ==(AuditableEntity? first, AuditableEntity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(AuditableEntity? first, AuditableEntity? second)
        {
            return !(first == second);
        }

        public bool Equals(AuditableEntity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false; 
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not AuditableEntity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41; 
        }
    }
}
