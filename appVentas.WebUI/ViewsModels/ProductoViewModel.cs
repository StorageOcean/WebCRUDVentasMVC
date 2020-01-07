using System.Collections.Generic;

namespace appVentas.WebUI.ViewsModels
{
    public class ProductoViewModel
    {
        public string CodProd { get; set; }
        public string NomProd { get; set; }
        public string CodGrup { get; set; }
        public string CodLin { get; set; }
        public string Marca { get; set; }
        public decimal? CosPromC { get; set; }
        public decimal? PrecioVta { get; set; }

        public GrupoViewModel grupoViewModel { get; set; }
        public LineaViewModel lineaViewModel { get; set; }
        public ProductoViewModel productoViewModel { get; set; }

        public List<ProductoViewModel> lstproductoViewModel { get; set; }
        public List<GrupoViewModel> lstgrupoViewModel { get; set; }
        public List<LineaViewModel> lstlineaViewModel { get; set; }
    }
}