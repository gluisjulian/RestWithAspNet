using System.Text.Json.Serialization;

namespace RestWithAspNet.Data.Vo
{
    public class PersonVO
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string FirstName { get; set; }

        [JsonPropertyName("sobrenome")]
        public string LastName { get; set; }

        [JsonPropertyName("endereco")]
        public string Address { get; set; }

        [JsonIgnore]
        public string Gender { get; set; }
    }
}
