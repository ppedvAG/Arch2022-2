namespace ppedv.Shopchestra.Model
{
    public class Musikinstrument : Produkt
    {
        public string? Seriennummer { get; set; } 
        public Material Material { get; set; }
        public Klassifikation Klassifikation { get; set; }
        public virtual HashSet<Orchester> Orchester { get; set; } = new HashSet<Orchester>();

    }
}