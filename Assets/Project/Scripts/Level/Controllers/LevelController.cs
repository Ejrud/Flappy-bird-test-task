using UnityEngine;

[RequireComponent(typeof(LevelConfigList))]
[RequireComponent(typeof(WallTransition))]
[RequireComponent(typeof(WallBuilder))]
[RequireComponent(typeof(WallPool))]
public class LevelController : MonoBehaviour
{
    private LevelConfigList _levelConfigList;
    private WallTransition _wallTransition;
    private WallBuilder _wallBuilder;
    private WallPool _wallPool;
    
    private LevelConfig _currentLevelConfig;
    private bool _isPlaying;

    public void Initialize()
    {
        _wallTransition = GetComponent<WallTransition>();
        _wallBuilder = GetComponent<WallBuilder>();
        _wallPool = GetComponent<WallPool>();
        _levelConfigList = GetComponent<LevelConfigList>();
        _wallTransition.Init(_wallPool);
    }

    public void StartGame(LevelDifficulty difficulty)
    { 
        _currentLevelConfig = _levelConfigList.GetLevelConfig(difficulty);
        _wallBuilder.UpdateValues(_wallPool, _currentLevelConfig);
        _wallPool.UpdateValues();
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
}
