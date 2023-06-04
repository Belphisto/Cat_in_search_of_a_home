namespace Model
{
    public class ScoreModel
    {
        private int score = 0;

        public void UpdateScore(int amount)
        {
            score += amount;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
