using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTMP;
    public int currentScore { get; private set; }
    
    public void Add()
    {
        currentScore++;
        _scoreTMP.text = currentScore.ToString();
    }

    public void Reset()
    {
        currentScore = 0;
        _scoreTMP.text = currentScore.ToString();
    }
}
