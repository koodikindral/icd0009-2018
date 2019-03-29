namespace DAL.Base.Entity
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; } // Primary Key for every entity type  
    }

}