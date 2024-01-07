using System.Security.Cryptography;

namespace webapp
{
    public class Token
    {
        private static Token _instance;

        // Singleton pattern to ensure a single instance of Token class
        public static Token Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Token();
                }
                return _instance;
            }
        }

        // Dictionaries to store mappings between user ID, tokens, and token information
        private Dictionary<int, string> getTokenFromID;
        private Dictionary<string, TokenInfo> securityToken;

        private Token()
        {
            securityToken = new Dictionary<string, TokenInfo>();
            getTokenFromID = new Dictionary<int, string>();
        }
    }
}