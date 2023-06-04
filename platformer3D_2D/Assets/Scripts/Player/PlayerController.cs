using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model;
using View;
namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel _model;
        private PlayerView _view;
        private Rigidbody _rigidbody;

        private bool _isFacingRight = true;
        private bool IsGrounded => _groundContacts.Count > 0;
        public Transform groundCheck;
        private readonly List<Collider> _contacts = new List<Collider>();
        private readonly List<Collider> _groundContacts = new List<Collider>();
        

        private void Start()
        {
            _model = new PlayerModel();
            _view = GetComponent<PlayerView>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            bool up = Input.GetKeyDown(KeyCode.UpArrow);
            bool down = Input.GetKeyDown(KeyCode.DownArrow);
            bool jump = Input.GetKeyDown(KeyCode.Space);

            if (horizontalInput != 0f)
            {
                _view.SetFloat();
                var movement = transform.right *_model.speed * Time.deltaTime;
                Debug.Log("");
                _view.FlipCharacter(false);
                if (horizontalInput < 0f)
                {
                    movement *= -1.0f;
                    _view.FlipCharacter(true);
                }
                
                _rigidbody.AddForce(movement, ForceMode.Impulse);
            }
            if (up)
            {
                // Обработка поворота персонажа по кнопке "вверх"
                _view.Rotate(90f);
            }
            if (down)
            {
                // Обработка поворота персонажа по кнопке "вниз"
                _view.Rotate(-90f);
            }
            if (jump && IsGrounded)
            { 
                _rigidbody.AddForce(new Vector3(0f, _model.jumpForce * _model.jumpRiseSpeed, 0f), ForceMode.Impulse);
                if (horizontalInput != 0f)
                {
                    _view.SetFloat();
                    var movement = transform.right * (_model.speed/_model.speedDeletel)* Time.deltaTime;
                    _view.FlipCharacter(false);

                    if (horizontalInput < 0f)
                    {
                        movement *= -1.0f;
                        _view.FlipCharacter(true);       
                    }
                    _rigidbody.AddForce(movement, ForceMode.Impulse);
                }
                _view.SetAnimatorState(IsGrounded);
            }
            if (!IsGrounded)
            {
            // При падении применяем силу с учетом параметра jumpFallSpeed
                _rigidbody.AddForce(new Vector3(0f, -_model.jumpForce * _model.jumpFallSpeed, 0f), ForceMode.Acceleration);
            }
            
            _view.SetAnimatorState(IsGrounded);
        }

        private void OnCollisionExit(Collision collision)
        {
            var hitbox = collision.collider;
            
            _contacts.Remove(hitbox);
            _groundContacts.Remove(hitbox);

            
            _view.SetAnimatorState(IsGrounded);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var hitbox = collision.collider;
            
            _contacts.Add(hitbox);
            
            var contactNormal = collision.impulse.normalized;
            var angle = Vector3.Angle(contactNormal, Vector3.up);
            var isGroundContact = angle < 5f;
        
            if (isGroundContact)
            {
                _groundContacts.Add(hitbox);

            }
            _view.SetAnimatorState(IsGrounded);
        }
    }
}
