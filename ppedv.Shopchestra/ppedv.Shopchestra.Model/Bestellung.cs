namespace ppedv.Shopchestra.Model
{
    public class Bestellung : Entity
    {
        public DateTime Bestelldatum { get; set; }
        public virtual Kunde? Kunde { get; set; }

        public virtual HashSet<BestellPosition> Positionen { get; set; } = new HashSet<BestellPosition>();
    }
}