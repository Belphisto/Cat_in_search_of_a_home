using UnityEngine;

namespace View
{
    public class PlatformView : MonoBehaviour
    {
        private Vector3 _initialPosition;

        private void Start()
        {
            _initialPosition = transform.position;
        }

        public void MovePlatform(float distance)
        {
            transform.position = _initialPosition + Vector3.up * distance;
        }
    }
}
