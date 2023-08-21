namespace Test_Skill_UI.Extension
{
    public static class ExtensionString
    {
        public static string ClearDoubleSpace(this string value)
        {
            while (value.Contains("  "))
            {
                value = value.Replace("  ", " ");
            }

            return value;
        }
    }
}
