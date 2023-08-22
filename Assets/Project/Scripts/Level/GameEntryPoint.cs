using System;
using Player;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private LevelDifficulty _levelDifficulty;

    private PlayerController _player;
    
    public void Start()
    {
        PrepareGame();
        _player.collisionComponent.OnCollisionDetected += PrepareGame;
    }

    private void PrepareGame()
    {
        _levelController.Initialize();
        _levelController.StartGame(_levelDifficulty);
        _player = _playerSpawner.Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _playerSpawner.Spawn();
            _levelController.StartGame(_levelDifficulty);
        }
    }

    private void OnDestroy()
    {
        _player.collisionComponent.OnCollisionDetected -= PrepareGame;
    }
}
