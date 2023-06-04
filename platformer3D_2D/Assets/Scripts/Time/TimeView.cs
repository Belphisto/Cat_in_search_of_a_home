using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace View
{
    public class TimeView : MonoBehaviour
    {
        private TMP_Text timeText;

        public void Start()
        {
            timeText = GetComponent<TMP_Text>();
        }
        public void UpdateTime(float currentTime)
        {
            timeText.text = string.Format("Time {0:0}:{1:00}", Mathf.Floor(currentTime / 60), Mathf.FloorToInt(currentTime % 60));
        }
    }
}