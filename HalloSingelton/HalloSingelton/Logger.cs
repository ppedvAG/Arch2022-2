namespace HalloSingelton
{
    public class Logger
    {
        static Logger? _instance;
        static object _instanceLock = new object();

        public static Logger Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }

                return _instance;
                //return _instance ??= new Logger();
            }
        }

        private Logger()
        {
            Log("Neue Logger instanz wurde erstellt");
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now:T}] {msg}");
        }
    }
}
