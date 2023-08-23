using System;
using Player;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerSpawner))]
[RequireComponent(typeof(LevelConfigList))]
[RequireComponent(typeof(WallTransition))]
[RequireComponent(typeof(WallBuilder))]
[RequireComponent(typeof(WallPool))]
public class LevelController : MonoBehaviour
{
    public event Action<int, LevelDifficulty> OnStopGame;

    private ScoreCounter _scoreCounter;
    private PlayerSpawner _playerSpawner;
    private LevelConfigList _levelConfigList;
    private WallTransition _wallTransition;
    private WallBuilder _wallBuilder;
    private WallPool _wallPool;
    
    private LevelConfig _currentLevelConfig;
    private PlayerController _player;
    
    private bool _isPlaying;

    public void Initialize()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _playerSpawner = GetComponent<PlayerSpawner>();
        _wallTransition = GetComponent<WallTransition>();
        _levelConfigList = GetComponent<LevelConfigList>();
        _wallBuilder = GetComponent<WallBuilder>();
        _wallPool = GetComponent<WallPool>();
        
        _wallTransition.Init(_wallPool, _scoreCounter);
        _wallPool.Init(_scoreCounter);
    }

    public void StartGame(LevelDifficulty difficulty)
    { 
        _currentLevelConfig = _levelConfigList.GetLevelConfig(difficulty);
        
        _wallPool.UpdateValues();
        _wallBuilder.UpdateValues(_wallPool, _currentLevelConfig);
        _wallBuilder.SpawnWall();
        
        _wallTransition.UpdateValues(_currentLevelConfig);
        
        _player = _playerSpawner.Spawn();
        _player.collisionComponent.OnCollisionDetected += EndGame;
        _player.Freeze(false);
        _player.Prepare();
        
        _scoreCounter.Reset();
        _isPlaying = true;
    }
    
    private void EndGame()
    {
        _player.collisionComponent.OnCollisionDetected -= EndGame;
        _player.Freeze(true);
        _isPlaying = false;

        OnStopGame?.Invoke(_scoreCounter.currentScore, _currentLevelConfig.difficulty);
    }

    private void Update()
    {
        if (!_isPlaying)
            return;

        float delta = Time.deltaTime;
        
        _wallTransition.Tick(delta);
        _wallBuilder.Tick();
    }

    private void OnDestroy()
    {
        if (_player)
            _player.collisionComponent.OnCollisionDetected -= EndGame;
    }
}
