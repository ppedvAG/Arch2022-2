namespace HalloDeco
{

    interface IComponent
    {
        public string Beschreibung { get; }
        public decimal Preise { get; }
    }

    abstract class Deko : IComponent
    {
        public abstract string Beschreibung { get; }

        public abstract decimal Preise { get; }

        protected IComponent parent;

        public Deko(IComponent parent)
        {
            this.parent = parent;
        }
    }

    class Käse : Deko
    {
        public Käse(IComponent comp) : base(comp) { }

        public override string Beschreibung => parent.Beschreibung + " Käse";

        public override decimal Preise => parent.Preise + 2m;
    }

    class Salami : Deko
    {
        public Salami(IComponent comp) : base(comp) { }

        public override string Beschreibung => parent.Beschreibung + " Salami";

        public override decimal Preise => parent.Preise + 4m;
    }

    public class Brot : IComponent
    {
        public string Beschreibung { get => "Brot"; }
        public decimal Preise { get => 2m; }
    }

    public class Pizza : IComponent
    {
        public string Beschreibung { get => "Pizza"; }
        public decimal Preise { get => 6m; }
    }
}
