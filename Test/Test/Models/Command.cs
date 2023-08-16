using System.Text.Json.Serialization;

namespace Test.Models
{
    public class CommandsList
    {
        [JsonPropertyName("items")]
        public Command[]? Commands { get; set; }
    }
    public class Command
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("parameter_name1")]
        public string? Param1 { get; set; }
        [JsonPropertyName("parameter_name2")]
        public string? Param2 { get; set; }
        [JsonPropertyName("parameter_name3")]
        public string? Param3 { get; set; }
        [JsonPropertyName("parameter_name4")]
        public string? Param4 { get; set; }
        [JsonPropertyName("parameter_name5")]
        public string? Param5 { get; set; }
        [JsonPropertyName("parameter_name6")]
        public string? Param6 { get; set; }
        [JsonPropertyName("parameter_name7")]
        public string? Param7 { get; set; }
        [JsonPropertyName("parameter_name8")]
        public string? Param8 { get; set; }
        [JsonPropertyName("str_parameter_name1")]
        public string? StrParameterName1 { get; set; }

        [JsonPropertyName("str_parameter_name2")]
        public string? StrParameterName2 { get; set; }
        [JsonPropertyName("parameter_default_value1")]
        public int? ParameterDefaultValue1 { get; set; }

        [JsonPropertyName("parameter_default_value2")]
        public int? ParameterDefaultValue2 { get; set; }
        [JsonPropertyName("parameter_default_value3")]
        public int? ParameterDefaultValue3 { get; set; }
        [JsonPropertyName("parameter_default_value4")]
        public int? ParameterDefaultValue4 { get; set; }
        [JsonPropertyName("parameter_default_value5")]
        public int? ParameterDefaultValue5 { get; set; }
        [JsonPropertyName("parameter_default_value6")]
        public int? ParameterDefaultValue6 { get; set; }
        [JsonPropertyName("parameter_default_value7")]
        public int? ParameterDefaultValue7 { get; set; }
        [JsonPropertyName("parameter_default_value8")]
        public int? ParameterDefaultValue8 { get; set; }
        [JsonPropertyName("str_parameter_default_value1")]
        public string? StringParameterDefaultValue1 { get; set; }

        [JsonPropertyName("str_parameter_default_value2")]
        public string? StringParameterDefaultValue2 { get; set; }
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }
    }
}
