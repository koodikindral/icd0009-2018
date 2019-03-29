using System;

namespace DAL.Base.Entity
{
    public interface IBaseEntity: IBaseEntity<int>
    {
       
    }

    public interface IBaseEntity<TKey> where TKey: IComparable
    {
        TKey Id { get; set;}
    }

}