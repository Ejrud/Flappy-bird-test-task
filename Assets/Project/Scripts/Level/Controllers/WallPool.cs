using System.Collections.Generic;
using UnityEngine;

public class WallPool : MonoBehaviour
{
    public Queue<Wall> activeWalls => _activeWalls;

    [SerializeField] private Wall _wallPrefab;
    [SerializeField] private Transform _parent;

    private ScoreCounter _scoreCounter;

    private Queue<Wall> _wallPool = new ();
    private Queue<Wall> _activeWalls = new ();
    private HashSet<Wall> _walls = new ();
    
    public void Init(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }

    public void UpdateValues()
    {
        foreach (var wall in _walls)
        {
            wall.hole.OnPlayerEnter -= _scoreCounter.Add;
            Destroy(wall.gameObject);
        }

        _walls = new HashSet<Wall>();
        _wallPool = new Queue<Wall>();
        _activeWalls = new Queue<Wall>();
    }

    public void Enqueue(Wall wall)
    {
        wall.IsActive = false;
        _wallPool.Enqueue(wall);
        _activeWalls.Dequeue();
    }
    
    public Wall GetWall()
    {
        if (!_wallPool.TryDequeue(out Wall wall))
        {
            wall = CreateWall();
        }
        
        _activeWalls.Enqueue(wall);
        return wall;
    }
    
    private Wall CreateWall()
    {
        Wall wall = Instantiate(_wallPrefab);
        wall.hole.OnPlayerEnter += _scoreCounter.Add;
        wall.transform.SetParent(_parent);
        wall.IsActive = false;
        _walls.Add(wall);
        return wall;
    }
}
