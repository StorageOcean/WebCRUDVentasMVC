using System.Collections.Generic;

namespace appVentas.WebUI.ViewsModels
{
    public class LineaViewModel
    {
        public LineaViewModel()
        {
            productoViewModel = new HashSet<ProductoViewModel>();
        }

        public string CodLin { get; set; }
        public string NomLin { get; set; }

        public ICollection<ProductoViewModel> productoViewModel { get; set; }
    }
}