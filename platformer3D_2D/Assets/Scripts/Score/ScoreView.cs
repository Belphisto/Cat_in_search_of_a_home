// Представление (View)

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace View
{
    public class ScoreView : MonoBehaviour
    {
        private TMP_Text scoreText;

        public void Start()
        {
            scoreText = GetComponent<TMP_Text>();
        }

        public void UpdateScore(int currentScore)
        {
            scoreText.text = string.Format("Score: {0}", currentScore);
        }

        
    }
}
