
namespace Adventure
{
    public static class globals
    {
        // Available player and food strings
        public static string[] playerStates = { "('-')", "(^-^)", "(X_X)" };
        public static string[] enemyStates = { "(<_>)" };

        // Current player string displayed in the Console
        public static string player = playerStates[0];
        public static string merchant = playerStates[1];
        public static string enemy = enemyStates[0];
    }
}
