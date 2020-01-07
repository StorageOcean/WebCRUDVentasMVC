using System.Collections.Generic;

namespace appVentas.BusinessEntities
{
    public class GrupoBO
    {
        public GrupoBO()
        {
            ProductoBE = new HashSet<ProductoBO>();
        }
       
        public string CodGrup { get; set; }
       
        public string NomGrup { get; set; }

        public ICollection<ProductoBO> ProductoBE { get; set; }
    }
}
