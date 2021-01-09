using System;
using System.Collections.Generic;
using System.Text;

namespace OrderCore.Entities
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
