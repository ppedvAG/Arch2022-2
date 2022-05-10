namespace ppedv.Shopchestra.Model
{
    public class Produkt : Entity
    {
        public string? Bezeichnung { get; set; }
        public string? Beschreibung { get; set; }
        public decimal Preis { get; set; }
        public string? Hersteller { get; set; }
        public virtual HashSet<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();

    }
}