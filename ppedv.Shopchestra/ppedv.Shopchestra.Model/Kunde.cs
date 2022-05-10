namespace ppedv.Shopchestra.Model
{
    public class Kunde : Entity
    {
        public string? Name { get; set; }
        public string? AdrZeile2 { get; set; }
        public string? Strasse { get; set; }
        public string? PLZ { get; set; }
        public string? Ort { get; set; }
        public string? Land { get; set; }
        public DateTime Gebdatum { get; set; }

        public virtual HashSet<Bestellung> Bestellungen { get; set; } = new HashSet<Bestellung>();
    }
}