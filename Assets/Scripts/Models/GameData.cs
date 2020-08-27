using Controllers;
using Models.ScriptableObjects;

namespace Models
{
    public class GameData
    {
        // User work time
        public float GameTime = 0f;

        // Number of user errors
        public int ErrorsCount = 0;

        // Current scenario in work
        public Scenario Scenario = null;
    }
}