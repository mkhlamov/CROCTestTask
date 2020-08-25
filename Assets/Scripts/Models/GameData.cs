using Controllers;

namespace Models
{
    public class GameData
    {
        // User work time
        public float GameTime = 0f;

        // Number of user errors
        public int ErrorsCount = 0;

        // Current model in work
        public ModelType ModelType = ModelType.None;
    }
}