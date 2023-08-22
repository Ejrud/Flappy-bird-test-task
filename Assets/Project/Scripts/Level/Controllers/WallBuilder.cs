using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _endPosition;

    private const float MAX_WALL_HEIGHT = 5f;
    
    private LevelConfig _levelConfig;
    private WallPool _wallPool;
    private Wall _previousWall;
    private float _previousHolePositonY;
    
    public void UpdateValues(WallPool wallPool, LevelConfig levelConfig)
    {
        _wallPool = wallPool;
        
        // TODO create a separate method for this
        _levelConfig = levelConfig;
        _previousHolePositonY = 0;
    }

    public void Tick()
    {
        // Create walls
        float distance = _spawnPosition.x - _previousWall.transform.position.x;
        if (distance >= _levelConfig.wallDistance)
            SpawnWall();
        
        // Hide walls
        if (_wallPool.activeWalls.TryPeek(out Wall lastWall))
            if (lastWall.transform.position.x <= _endPosition.x)
                _wallPool.Enqueue(lastWall);
    }

    public void SpawnWall()
    {
        Wall wall = _wallPool.GetWall();
        wall.transform.position = _spawnPosition;
        wall.IsActive = true;
        _previousWall = wall;
        SetHole(wall);
    }

    private void SetHole(Wall wall)
    {
        float randomPositionY = Random.Range(-_levelConfig.holeOffset, _levelConfig.holeOffset);
        float middleHole = _previousHolePositonY + randomPositionY;
        middleHole = Mathf.Clamp(middleHole, -_levelConfig.middleHoleHeght, _levelConfig.middleHoleHeght);

        float topHeight = MAX_WALL_HEIGHT - (middleHole + _levelConfig.holeSize / 2);
        float bottomHeight = -MAX_WALL_HEIGHT - (middleHole - _levelConfig.holeSize / 2);
        
        wall.InitWall(topHeight, Mathf.Abs(bottomHeight));
        _previousHolePositonY = middleHole;
    }
}
