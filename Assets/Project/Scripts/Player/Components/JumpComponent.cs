using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class JumpComponent : MonoBehaviour
    {
        public event Action OnJump;
        
        public bool isFreeze
        {
            get { return _isFreeze; }
            set
            {
                _isFreeze = value;
                _rigidbody2D.simulated = !_isFreeze;
            }
        }

        [Header("Settings")] 
        [SerializeField] private float _jumpForce = 4f;
        
        private Rigidbody2D _rigidbody2D;
        private InputService _inputService;
        private bool _isFreeze;

        public void Init(InputService inputService)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputService = inputService;
            _inputService.OnJump += Jump;
        }

        public void Jump()
        {
            if (_isFreeze)
                return;
            
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            OnJump?.Invoke();
        }

        private void OnDestroy()
        {
            _inputService.OnJump -= Jump;
        }
    }
}