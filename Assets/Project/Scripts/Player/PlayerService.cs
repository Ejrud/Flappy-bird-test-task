using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(JumpController))]
    public class PlayerService : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private InputService _inputService;

        private JumpController _jumpController;

        private void Start()
        {
            _jumpController = GetComponent<JumpController>();
            _jumpController.Init(_inputService);
        }
    }
} 

