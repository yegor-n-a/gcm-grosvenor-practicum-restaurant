using Application.Interfaces.General;
using Application.Models.General;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Application.Models
{
    public class DishDescriptor : NamedItem<string>, IPositionedItem<decimal?>
    {
        public DishType Type { get; set; }
        public decimal? Position { get; set; }
    }
}
