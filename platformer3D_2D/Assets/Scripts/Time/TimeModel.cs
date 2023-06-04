using System;
using UnityEngine;

namespace Model
{
    public class TimeModel
    {
        public float currentTime = 0f;

        public void UpdateTime()
        {
            currentTime += Time.deltaTime;
        }

        public void ResetTime()
        {
            currentTime = 0f;
        }

        public float GetTime()
        {
            return currentTime;
        }
    }
}

