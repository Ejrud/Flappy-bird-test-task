using UnityEngine;
using System;

namespace Player
{
    public class InputService : MonoBehaviour
    {
        public event Action OnJump;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnJump?.Invoke();
        
            if (Input.GetKeyDown(KeyCode.Space))
                OnJump?.Invoke();
        }
    }
}
