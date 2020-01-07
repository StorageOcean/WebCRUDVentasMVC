using appVentas.BusinessEntities;
using appVentas.DataAccess;
using System.Collections.Generic;

namespace appVentas.BusinessLogic
{
    public class GrupoBL
    {
        private GrupoDA grupoDA;
	// COMENTARIO
        public GrupoBL()
        {
            this.grupoDA = new GrupoDA();
        }

        public List<GrupoBO> GetAllGrupos()
        {
            return grupoDA.GetAllGrupos();
        }
    }
}
