using System.Collections;
using UnityEngine;


namespace View
{
    public class PlayerView : MonoBehaviour
    {
        private static readonly int _jumping = Animator.StringToHash("Jumping");
        private Animator _animator;
        private SpriteRenderer _renderer;
        private float currentRotationAngle = 0f;

        //fisics based 
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void FlipCharacter(bool isFacingRight)
        {
            _renderer.flipX = isFacingRight;
        }

        public void SetAnimatorState(bool IsGrounded)
        {
            _animator.SetBool("Jumping", !IsGrounded);
        }
        public void SetFloat()
        {
            _animator.SetFloat("moveX", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        public void Rotate(float angle)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, currentRotationAngle + angle, 0f);
            StartCoroutine(SmoothRotate(targetRotation));
            currentRotationAngle += angle;
        }
        IEnumerator SmoothRotate(Quaternion targetRotation)
            {
                float rotationTime = 0.5f; // Время, за которое должно произойти вращение (в секундах)
                Quaternion startRotation = transform.rotation;
                float elapsedTime = 0f;

                while (elapsedTime < rotationTime)
                {
                    transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / rotationTime);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                transform.rotation = targetRotation;
            }
    }

}
