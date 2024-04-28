using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain.Product.ValueObjects
{
    public class ProductId : ValueObject
    {
        public Guid Value { get; private set; }

        private ProductId() { }

        private ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique() => new ProductId(Guid.NewGuid());
        public static ProductId Create(Guid value) => new ProductId(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
