namespace H3_ORM___Database_first.GUI.Utilities
{
    public class InputAttempsExceeded : Exception
    {
        public InputAttempsExceeded() { }

        public InputAttempsExceeded(string message) : base(message) { }
    }
}