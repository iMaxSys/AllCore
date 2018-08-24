using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCore.Models
{
    public interface IEntity
    {
    }

    /// <summary>
    /// Catalog
    /// </summary>
    public class Catalog : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Goods
        /// </summary>
        public ICollection<Goods> Goods { get; set; }
    }

    /// <summary>
    /// Goods
    /// </summary>
    public class Goods : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// CatalogId
        /// </summary>
        public long CatalogId { get; set; }

        /// <summary>
        /// Catalog
        /// </summary>
        public Catalog Catalog { get; set; }

        /// <summary>
        /// ActivityItemId
        /// </summary>
        public long? ActivityItemId { get; set; }

        /// <summary>
        /// ActivityItem
        /// </summary>
        public virtual ActivityItem ActivityItem { get; set; }
    }

    /// <summary>
    /// Memeber
    /// </summary>
    public class Member : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cart
        /// </summary>
        public virtual ICollection<Cart> Carts { get; set; }
    }

    /// <summary>
    /// Cart
    /// </summary>
    public class Cart : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// GoodsId
        /// </summary>
        public long GoodsId { get; set; }

        /// <summary>
        /// Goods
        /// </summary>
        public virtual Goods Goods { get; set; }

        /// <summary>
        /// MemberId
        /// </summary>
        public long MemberId { get; set; }

        /// <summary>
        /// Member
        /// </summary>
        public virtual Member Member { get; set; }
    }

    /// <summary>
    /// Activity
    /// </summary>
    public class Activity : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Status { get; set; }

        public virtual ICollection<ActivityItem> Items { get; set; }
    }

    /// <summary>
    /// ActivityItem
    /// </summary>
    public class ActivityItem : IEntity
    {
        public long Id { get; set; }

        public long GoodsId { get; set; }

        public decimal Price { get; set; }

        public long ActivityId { get; set; }

        public virtual Goods Goods { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
