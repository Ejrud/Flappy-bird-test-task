using UnityEngine;

public class WallTransition : MonoBehaviour
{
    private WallPool _wallPool;
    private ScoreCounter _scoreCounter;
    private int _scoreCountForMultiplySpeed;
    private float _multiplySpeed;
    private float _defaultSpeed = 1f;
    
    public void Init(WallPool wallPool, ScoreCounter scoreCounter)
    {
        _wallPool = wallPool;
        _scoreCounter = scoreCounter;
        _scoreCounter.OnScoreTrigger += IncreaseSpeed;
    }

    public void UpdateValues(LevelConfig levelConfig)
    {
        _scoreCountForMultiplySpeed = levelConfig.scoreCountForMultiplySpeed;
        _multiplySpeed = levelConfig.speedMultiply;
        _defaultSpeed = levelConfig.startSpeed;
        
        _scoreCounter.SetScoreTrigger(_scoreCountForMultiplySpeed);
    }

    public void Tick(float delta)
    {
        foreach (var wall in _wallPool.activeWalls)
            wall.transform.Translate(Vector3.left * (delta * _defaultSpeed));
    }

    private void IncreaseSpeed()
    {
        _defaultSpeed += _multiplySpeed;
    }
}
