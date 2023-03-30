namespace Nop.Plugin.Misc.AppyTwoAppointment
{
    public static class SessionHelper
    {
        public static class Config
        {
            public static Dictionary<string, string> Application = new Dictionary<string, string>();
        }
        private static IDictionary<string, string> Session { get; set; } = new Dictionary<string, string>();

        public static void setString(string key, string value)
        {
            Session[key] = value;
        }

        public static string getString(string key)
        {
            return Session.ContainsKey(key) ? Session[key] : string.Empty;
        }
    }
}
