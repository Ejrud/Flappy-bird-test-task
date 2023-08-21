using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollisionDetectionComponent : MonoBehaviour
{
    public event Action OnCollisionDetected;
    public const string OBSTACLE_TAG = "Obstacle";

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag(OBSTACLE_TAG))
            return;
        
        Debug.Log("Collision detected");
        OnCollisionDetected?.Invoke();
    }
}
