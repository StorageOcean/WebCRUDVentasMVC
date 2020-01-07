using appVentas.BusinessEntities;
using appVentas.DataAccess;
using System.Collections.Generic;

namespace appVentas.BusinessLogic
{
    public class ProductoBL
    {
        private ProductoDA productoDA;

        public ProductoBL()
        {
            this.productoDA = new ProductoDA();
        }

        public List<ProductoBO> GetAllProductos()
        {
            return productoDA.GetAllProductos();
        }

        public ProductoBO GetProductoById(ProductoBO producto)
        {
            return productoDA.GetProductoById(producto);
        }

        public bool InsertProducto(ProductoBO producto)
        {
            return productoDA.InsertProducto(producto);
        }

        public bool UpdateProducto(ProductoBO producto)
        {
            return productoDA.UpdateProducto(producto);
        }

        public bool DeleteProducto(ProductoBO producto)
        {
            return productoDA.DeleteProducto(producto);
        }
    }


}
