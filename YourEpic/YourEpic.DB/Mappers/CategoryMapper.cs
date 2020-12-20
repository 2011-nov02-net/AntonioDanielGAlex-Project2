using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class CategoryMapper
    {
        public static Category Map(Domain.Models.Category model) {
            return new Category { 
                Id = model.ID,
                Name=model.Name
            };
        }

        public static Domain.Models.Category Map(Category entity)
        {
            return new Domain.Models.Category
            {
                ID = entity.Id,
                Name = entity.Name
            };
        }
    }
}
