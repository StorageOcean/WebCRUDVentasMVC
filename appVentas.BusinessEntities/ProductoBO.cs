namespace appVentas.BusinessEntities
{
    public class ProductoBO
    {
        public string CodProd { get; set; }
        public string NomProd { get; set; }
        public string CodGrup { get; set; }
        public string CodLin { get; set; }
        public string Marca { get; set; }        
        public decimal? CosPromC { get; set; }        
        public decimal? PrecioVta { get; set; }

        public GrupoBO CodGrupNavigation { get; set; }
        public LineaBO CodLinNavigation { get; set; }
    }
}
