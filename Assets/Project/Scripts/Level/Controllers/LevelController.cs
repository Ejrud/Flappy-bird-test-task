using UnityEngine;

[RequireComponent(typeof(WallTransition))]
[RequireComponent(typeof(WallBuilder))]
[RequireComponent(typeof(WallPool))]
[RequireComponent(typeof(ConfigList))]
public class LevelController : MonoBehaviour
{
    private WallTransition _wallTransition;
    private WallBuilder _wallBuilder;
    private ConfigList _configList;
    private WallPool _wallPool;
    
    private LevelConfig _currentLevelConfig;
    private bool _isPlaying;

    private void Start()
    {
        _wallTransition = GetComponent<WallTransition>();
        _wallBuilder = GetComponent<WallBuilder>();
        _wallPool = GetComponent<WallPool>();
        _configList = GetComponent<ConfigList>();

        InitializeComponents();
        
        // invoke on button pressed
        StartGame(LevelDifficulty.Hard);
    }

    public void StartGame(LevelDifficulty difficulty)
    { 
        _currentLevelConfig = _configList.GetLevelConfig(difficulty);
        UpdateComponents();
        
        _wallBuilder.SpawnWall();
        _isPlaying = true;
    }

    private void Update()
    {
        if (!_isPlaying)
            return;

        float delta = Time.deltaTime;
        
        _wallTransition.Tick(delta * _currentLevelConfig.speed);
        _wallBuilder.Tick();
    }

    private void UpdateComponents()
    {
        _wallBuilder.Init(_wallPool, _currentLevelConfig);
    }

    private void InitializeComponents()
    {
        _wallTransition.Init(_wallPool);
    }
}
