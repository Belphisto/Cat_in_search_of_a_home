// Контроллер (Controller)

using UnityEngine;
using System;

using Model;

namespace Controller
{
    public class BonusController : MonoBehaviour
{
    public event Action<int> OnScoreAdded; // Событие для добавления очков
    public event Action<int> OnLevelCompleted; // Событие для завершение уровня 

    public AnimationScript bonusview;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BonusModel bonus = GetComponent<BonusModel>();
            bonusview = GetComponent<AnimationScript>();
            Debug.Log("bonus = GetComponent<BonusModel>();");

            if (bonus != null)
            {
                int scoreValue = bonus.GetScoreValue();
                int levelcomplite = 1;
               
                OnScoreAdded?.Invoke(scoreValue); // Вызов события для добавления очков
                //scoreController.AddScore(bonus.scoreValue);
                Debug.Log("Collision OnTriggerEnter(Collider other)");
                if (bonus is TreasureChest)
                { 
                    Debug.Log("bonus is TreasureChest");
                    OnLevelCompleted?.Invoke(levelcomplite);
                }
                Destroy(gameObject);
            }
        }
    }
}
}
