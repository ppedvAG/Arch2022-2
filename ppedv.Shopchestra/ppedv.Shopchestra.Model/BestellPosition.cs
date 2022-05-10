namespace ppedv.Shopchestra.Model
{
    public class BestellPosition : Entity
    {
        public double Menge { get; set; }
        public decimal Einzelpreis { get; set; }
        public Bestellung? Bestellung { get; set; }
        public Produkt? Produkt { get; set; }
    }
}