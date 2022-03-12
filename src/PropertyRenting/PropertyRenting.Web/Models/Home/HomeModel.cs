using Autofac;
using PropertyRenting.Membership.BusinessObject;
using PropertyRenting.Membership.Services;

namespace PropertyRenting.Web.Models.Home
{
    public class HomeModel
    {
        public IList<Category> Categories { get; set; }
        private ILifetimeScope _scope;
        private ICategoryService _categoryService;
        public HomeModel() { }

        public HomeModel(ICategoryService categoryService)
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
            Categories = _categoryService.GetAll();
        }
    }
}
