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

        // Authorize a user and generate a new token if necessary
        public string AuthorizeUser(int userID)
        {
            // Check if the user already has a token
            if (getTokenFromID.TryGetValue(userID, out string existingToken))
            {
                return existingToken;
            }

            // Generate a new token for the user
            string newToken = GenerateNewToken();

            // Create token information
            TokenInfo tokenInfo = new TokenInfo
            {
                UserID = userID,
            };

            // Add the new token and token information to the dictionaries
            securityToken.Add(newToken, tokenInfo);
            getTokenFromID.Add(userID, newToken);

            // Return the newly generated token
            return newToken;
        }

        // Generating a new secure token using RNGCryptoServiceProvider
        private string GenerateNewToken()
        {
            using (var rngCrypto = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[32];
                rngCrypto.GetBytes(randomBytes);

                return BitConverter.ToString(randomBytes).Replace("-", "");
            }
        }
    }
}