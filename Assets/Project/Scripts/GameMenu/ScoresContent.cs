using TMPro;
using UnityEngine;

public class ScoresContent : MonoBehaviour
{
    [SerializeField] private TMP_Text _easyScore;
    [SerializeField] private TMP_Text _mediumScore;
    [SerializeField] private TMP_Text _hardScore;

    private PlayerModel _playerModel;
    
    private void Start()
    {
        _playerModel = DataService.instance.playerModel;
        _playerModel.OnScoreChanged += UpdateValues;
    }

    private void UpdateValues()
    {
        _easyScore.text = _playerModel.scoresModel.easyScore.ToString();
        _mediumScore.text = _playerModel.scoresModel.mediumScore.ToString();
        _hardScore.text = _playerModel.scoresModel.hardScore.ToString();
    }

    private void OnDestroy()
    {
        _playerModel.OnScoreChanged -= UpdateValues;
    }
}
