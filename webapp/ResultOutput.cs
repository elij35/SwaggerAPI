using System.Text.Json;

namespace webapp
{
    public class ResultOutput<T>
    {
        public T Output { get; set; }

        public ResultOutput(T _Message)
        {
            Output = _Message;
        }

        public async Task<string> Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
