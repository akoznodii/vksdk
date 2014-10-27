namespace VK.Users
{
    public enum NameCase
    {
        Nominative,
        Genitive,
        Dative,
        Accusative,
        Instrumental,
        Prepositional,
    }

    public static class NameCaseExtensions
    {
        public static string GetNameCase(this NameCase nameCase)
        {
            switch (nameCase)
            {
                case NameCase.Nominative:
                default:
                    return VkConstants.Nominative;
                case NameCase.Genitive:
                    return VkConstants.Genitive;
                case NameCase.Dative:
                    return VkConstants.Dative;
                case NameCase.Accusative:
                    return VkConstants.Accusative;
                case NameCase.Instrumental:
                    return VkConstants.Instrumental;
                case NameCase.Prepositional:
                    return VkConstants.Prepositional;
            }
        }
    }
}
