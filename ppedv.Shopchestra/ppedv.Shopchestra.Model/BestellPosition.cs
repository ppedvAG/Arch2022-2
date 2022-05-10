namespace ppedv.Shopchestra.Model
{
    public class BestellPosition : Entity
    {
        public double Menge { get; set; }
        public decimal Einzelpreis { get; set; }
        public virtual Bestellung? Bestellung { get; set; }
        public virtual Produkt? Produkt { get; set; }
    }
}