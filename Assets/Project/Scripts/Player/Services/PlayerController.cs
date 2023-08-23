using UnityEngine;

namespace Player
{
    
    [RequireComponent(typeof(JumpComponent))]
    [RequireComponent(typeof(SoundComponent))]
    [RequireComponent(typeof(CollisionComponent))]
    public class PlayerController : MonoBehaviour
    {
        public CollisionComponent collisionComponent => _collisionComponent;
        
        private InputService _inputService;
        private JumpComponent _jumpComponent;
        private SoundComponent _soundComponent;
        private CollisionComponent _collisionComponent;

        public void Init(InputService inputService)
        {
            _inputService = inputService;
            _jumpComponent = GetComponent<JumpComponent>();
            _soundComponent = GetComponent<SoundComponent>();
            _collisionComponent = GetComponent<CollisionComponent>();
            
            InitializeComponents();
        }

        public void Prepare()
        {
            _jumpComponent.Jump();
        }

        public void Freeze(bool value)
        {
            _jumpComponent.isFreeze = value;
        }

        private void InitializeComponents()
        {
            _jumpComponent.Init(_inputService);
            _soundComponent.Init(_jumpComponent);
        }
    }
} 

