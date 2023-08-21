using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(JumpComponent))]
    [RequireComponent(typeof(CollisionDetectionComponent))]
    public class PlayerService : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private InputService _inputService;

        private JumpComponent _jumpComponent;
        private CollisionDetectionComponent _collisionDetection;

        private void Start()
        {
            GetComponents();
            InitializeComponents();
        }

        private void GetComponents()
        {
            _jumpComponent = GetComponent<JumpComponent>();
            _collisionDetection = GetComponent<CollisionDetectionComponent>();
        }

        private void InitializeComponents()
        {
            _jumpComponent.Init(_inputService);

        }
    }
} 

