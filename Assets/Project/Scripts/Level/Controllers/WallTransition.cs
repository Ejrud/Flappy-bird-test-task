using UnityEngine;

public class WallTransition : MonoBehaviour
{
    private WallPool _wallPool;
    private float _multiplySpeedByScore;
    private float _currentSpeedMultiply = 1f;
    
    public void Init(WallPool wallPool)
    {
        _wallPool = wallPool;
    }

    public void Tick(float deltaSpeed)
    {
        foreach (var wall in _wallPool.activeWalls)
        {
            wall.transform.Translate(Vector3.left * (deltaSpeed * _currentSpeedMultiply));
        }
    }
}
