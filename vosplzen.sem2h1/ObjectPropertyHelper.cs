namespace vosplzen.sem2h1
{
    public static class ObjectPropertyHelper
    {
        public static bool isAnyPropertyNull(params object[] values)
        {
            foreach (var value in values)
            {
                if (value == null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
