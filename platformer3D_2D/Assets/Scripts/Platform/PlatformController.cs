using UnityEngine;

using Model;
using View;
namespace Controller
{
    public class PlatformController : MonoBehaviour
    {
        private PlatformModel _model;
        private PlatformView _view;

        private float _currentHeight;
        private float _direction = 1.0f; // Направление движения платформы (1 - вверх, -1 - вниз)

        private void Start()
        {
            _model = new PlatformModel();
            _view = GetComponent<PlatformView>();
        }

        private void Update()
        {
            float movement = _model.speed * _direction * Time.deltaTime;
            _currentHeight += movement;

            // Проверка достижения максимальной высоты или минимальной высоты
            if (_currentHeight >= _model.height || _currentHeight <= 0)
            {
                _direction *= -1; // Изменение направления движения
            }

            _view.MovePlatform(_currentHeight);
        }
    }

}