using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action OnScoreTrigger;
    [SerializeField] private TMP_Text _scoreTMP;
    public int currentScore { get; private set; }
    private int scoreTriger;
    
    public void Add()
    {
        currentScore++;
        _scoreTMP.text = currentScore.ToString();
        
        if (currentScore % scoreTriger == 0)
            OnScoreTrigger?.Invoke();
    }

    public void Reset()
    {
        currentScore = 0;
        _scoreTMP.text = currentScore.ToString();
    }

    public void SetScoreTrigger(int value)
    {
        scoreTriger = value;
    }
}
