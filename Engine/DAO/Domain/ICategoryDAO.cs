using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Domain.Object;

namespace Engine.DAO.Domain
{
    public interface ICategoryDAO
    {
        List<Category> GetAllActiveCategories();
    }
}
