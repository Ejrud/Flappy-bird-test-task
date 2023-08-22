using UnityEngine;

[RequireComponent(typeof(WallTransition))]
[RequireComponent(typeof(WallBuilder))]
[RequireComponent(typeof(WallPool))]
[RequireComponent(typeof(ConfigList))]
public class LevelController : MonoBehaviour
{
    private LevelConfig _currentLevelConfig;
    private ConfigList _configList;
    
    private WallTransition _wallTransition;
    private WallBuilder _wallBuilder;
    private WallPool _wallPool;
    
    private bool _isPlaying;

    private void Start()
    {
        _wallTransition = GetComponent<WallTransition>();
        _wallBuilder = GetComponent<WallBuilder>();
        _wallPool = GetComponent<WallPool>();
        _configList = GetComponent<ConfigList>();
        
        StartGame(LevelDifficulty.Easy);
    }

    public void StartGame(LevelDifficulty difficulty)
    { 
        _currentLevelConfig = _configList.GetLevelConfig(difficulty);
        InitComponents();
        
        _wallBuilder.SpawnWall();
        _isPlaying = true;
        Debug.Log(_isPlaying);
    }

    private void Update()
    {
        if (!_isPlaying)
            return;

        float delta = Time.deltaTime;
        
        _wallTransition.Tick(delta * _currentLevelConfig.speed);
        _wallBuilder.Tick();
    }

    private void InitComponents()
    {
        _wallTransition.Init(_wallPool);
        _wallBuilder.Init(_wallPool, _currentLevelConfig.wallDistance);
    }
}
