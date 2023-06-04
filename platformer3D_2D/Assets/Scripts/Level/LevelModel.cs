namespace Model
{
    public class LevelModel
    {
        private int _id;
        /*private bool isLevelComplete = false;

        public bool IsLevelComplete
        {
            get { return isLevelComplete; }
            set { isLevelComplete = value; }
        }*/

        public LevelModel(int id)
        {
            _id = id;
        }

        public int GetLevelId()
        {
            return _id;
        }
    }
}

