using System;
using System.Collections.Generic;
using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public interface IProductsRepository
    {
        List<Products> Get();
        List<Products> Get(string id);
    }
}
