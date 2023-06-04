// Модель Bonus (Model)

using UnityEngine;

namespace Model
{
    public abstract class BonusModel :  MonoBehaviour
    {
        private int scoreValue;

        public int GetScoreValue()
        {
            return scoreValue;
        }

        public void SetScoreValue(int value)
        {
            scoreValue = value;
        }
    }
}

