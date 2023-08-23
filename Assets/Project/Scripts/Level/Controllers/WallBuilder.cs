using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    // Высота пространста равна 10 единицам при любых соотношениях сторон экрана
    private const float MAX_WALL_HEIGHT = 5f;
    
    [SerializeField] private Vector3 _spawnViewportPosition;
    [SerializeField] private Vector3 _endViewportPosition;

    private Vector3 _spawnPosition;
    private Vector3 _endPosition;
    
    private LevelConfig _levelConfig;
    private WallPool _wallPool;
    private Wall _previousWall;
    private float _previousHolePositonY;
    
    public void UpdateValues(WallPool wallPool, LevelConfig levelConfig)
    {
        _spawnPosition = Camera.main.ViewportToWorldPoint(_spawnViewportPosition);
        _endPosition = Camera.main.ViewportToWorldPoint(_endViewportPosition);

        _spawnPosition.z = 0f;
        _endPosition.z = 0f;
        
        _wallPool = wallPool;
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
