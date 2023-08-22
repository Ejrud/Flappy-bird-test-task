using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPool : MonoBehaviour
{
    public Queue<Wall> activeWalls => _activeWalls;

    [SerializeField] private Wall _wallPrefab;
    [SerializeField] private Transform _parent;

    private Queue<Wall> _wallPool = new ();
    private Queue<Wall> _activeWalls = new ();

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
        wall.transform.SetParent(_parent);
        wall.IsActive = false;
        return wall;
    }
}
