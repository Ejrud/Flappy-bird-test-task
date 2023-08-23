using System;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    public event Action OnPlayerEnter;
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(PLAYER_TAG))
            OnPlayerEnter?.Invoke();
    }
}
