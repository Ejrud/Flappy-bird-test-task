using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _endPosition;
    
    private WallPool _wallPool;
    private Wall _previousWall;
    private float _maxWallDistance;
    
    public void Init(WallPool wallPool, float maxWallDistance)
    {
        _wallPool = wallPool;
        _maxWallDistance = maxWallDistance;
    }

    public void Tick()
    {
        float distance = _spawnPosition.x - _previousWall.transform.position.x;
        if (distance >= _maxWallDistance)
            SpawnWall();

        Wall lastWall = _wallPool.activeWalls.Peek();
        if (lastWall.transform.position.x <= _endPosition.x)
            _wallPool.Enqueue(lastWall);
    }

    public void SpawnWall()
    {
        Wall wall = _wallPool.GetWall();
        wall.transform.position = _spawnPosition;
        wall.IsActive = true;
        _previousWall = wall;
    }
}
