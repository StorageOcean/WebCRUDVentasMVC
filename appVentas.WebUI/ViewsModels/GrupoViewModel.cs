using System.Collections.Generic;

namespace appVentas.WebUI.ViewsModels
{
    public class GrupoViewModel
    {
        public GrupoViewModel()
        {
            productoViewModel = new HashSet<ProductoViewModel>();
        }

        public string CodGrup { get; set; }
        public string NomGrup { get; set; }

        public ICollection<ProductoViewModel> productoViewModel { get; set; }
    }
}