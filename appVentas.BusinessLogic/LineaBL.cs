using appVentas.BusinessEntities;
using appVentas.DataAccess;
using System.Collections.Generic;

namespace appVentas.BusinessLogic
{
    public class LineaBL
    {
        private LineaDA lineaDA;

        public LineaBL()
        {
            this.lineaDA = new LineaDA();
        }

        public List<LineaBO> GetAllLineas()
        {
            return lineaDA.GetAllLineas();
        }
    }
}
