using System.Collections.Generic;

namespace appVentas.BusinessEntities
{
    public class LineaBO
    {
        public LineaBO()
        {
            ProductoBE = new HashSet<ProductoBO>();
        }

        public string CodLin { get; set; }
        public string NomLin { get; set; }

        public ICollection<ProductoBO> ProductoBE { get; set; }
    }
}
