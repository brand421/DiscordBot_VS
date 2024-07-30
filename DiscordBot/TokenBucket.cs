using System.Threading.RateLimiting;

namespace DiscordBot
{
    public class TokenBucket
    {
        private readonly int _capacity;
        private readonly int _refillRate;
        private int _tokens;
        private DateTime _lastRefill;

        public TokenBucket(int capacity, int refillRate)
        {
            _capacity = capacity;
            _refillRate = refillRate;
            _tokens = capacity;
            _lastRefill = DateTime.UtcNow;
        }
    }
}
