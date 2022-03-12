using Autofac;
using PropertyRenting.Membership.BusinessObject;
using PropertyRenting.Membership.Services;

namespace PropertyRenting.Web.Models.Moderator
{
    public class CategoryListModel
    {
        public IList<Category> Categories { get; set; }
        private ILifetimeScope _scope;
        private ICategoryService _categoryService;
        public CategoryListModel() { }

        public CategoryListModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _categoryService = _scope.Resolve<ICategoryService>();
        }

        public void LoadAllCategories()
        {
            Categories = _categoryService.GetAllCategorys();
        }
    }
}
