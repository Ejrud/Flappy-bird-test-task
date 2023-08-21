using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpController : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _jumpForce;
        
        private Rigidbody2D _rigidbody2D;

        public void Init(InputService inputService)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            inputService.OnJump += Jump;
        }

        public void Jump()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}