using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class JumpComponent : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _jumpForce = 5f;
        
        private Rigidbody2D _rigidbody2D;
        private InputService _inputService;

        public void Init(InputService inputService)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputService = inputService;
            _inputService.OnJump += Jump;
        }

        public void Jump()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void OnDestroy()
        {
            _inputService.OnJump -= Jump;
        }
    }
}