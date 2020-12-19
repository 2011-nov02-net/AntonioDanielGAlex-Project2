using System;
using YourEpic.WebAPI.Models;
namespace YourEpic.WebAPI.Mappers
{
    public static class CategoryModelMapper
    {
        public static CategoryModel Map(Domain.Models.Category category) {
            return new CategoryModel {
                ID = category.ID,
                Name = category.Name
            };
        }
        public static Domain.Models.Category Map(CategoryModel model) {
            return new Domain.Models.Category {
                ID = model.ID,
                Name = model.Name
            };
        }
    }
}
