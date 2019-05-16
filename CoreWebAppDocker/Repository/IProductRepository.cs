using CoreWebAppDocker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppDocker.Repository
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProductByID(int ProductId);
		void DeleteProduct(int ProductId);
		void InsertProduct(Product product);
		void UpdateProduct(Product product);
		void Save();
	}
}
