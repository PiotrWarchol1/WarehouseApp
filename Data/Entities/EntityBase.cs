﻿namespace WarehouseApp.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
