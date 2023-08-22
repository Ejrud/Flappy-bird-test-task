using Player;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private Vector3 _screenSpawnPosition;
    private PlayerController _currentPlayer;
    
    public PlayerController Spawn()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(_screenSpawnPosition);
        spawnPosition.z = 0;

        if (!_currentPlayer)
        {
            _currentPlayer = Instantiate(_playerPrefab);
            _currentPlayer.Init(_inputService);
        }

        _currentPlayer.transform.position = spawnPosition;
        return _currentPlayer;
    }
}
