using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(JumpComponent))]
    [RequireComponent(typeof(CollisionComponent))]
    public class PlayerController : MonoBehaviour
    {
        public CollisionComponent collisionComponent => _collisionComponent;
        
        private InputService _inputService;
        private JumpComponent _jumpComponent;
        private CollisionComponent _collisionComponent;

        public void Init(InputService inputService)
        {
            _inputService = inputService;
            _jumpComponent = GetComponent<JumpComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _jumpComponent.Init(_inputService);
        }
    }
} 

