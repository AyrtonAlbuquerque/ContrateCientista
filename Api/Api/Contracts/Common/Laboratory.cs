using System.Text.Json.Serialization;

namespace Api.Contracts.Common
{
    public class Laboratory
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("score")]
        public decimal? Score { get; set; }

        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("certificates")]
        public string Certificates { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("foundationDate")]
        public string FoundationDate { get; set; }

        [JsonRequired]
        [JsonPropertyName("responsible")]
        public Responsible Responsible { get; set; }

        [JsonRequired]
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("softwares")]
        public ICollection<Software> Softwares { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("equipments")]
        public ICollection<Equipment> Equipments { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("socialMedias")]
        public ICollection<SocialMedia> SocialMedias { get; set; }
    }
}