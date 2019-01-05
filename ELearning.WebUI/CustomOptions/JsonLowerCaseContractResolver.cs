using Newtonsoft.Json.Serialization;

namespace ELearning.WebUI.CustomOptions
{
    public class JsonLowerCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
