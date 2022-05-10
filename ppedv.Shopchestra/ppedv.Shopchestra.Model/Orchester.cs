namespace ppedv.Shopchestra.Model
{
    public class Orchester: Entity
    {
        public string? Name { get; set; }
        public virtual HashSet<Musikinstrument> Instrumente { get; set; } = new HashSet<Musikinstrument>();

    }
}