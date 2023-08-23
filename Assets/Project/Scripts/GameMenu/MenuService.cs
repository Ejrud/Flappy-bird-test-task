using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuService : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private DifficultSelector _difficultSelector;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private ScoresContent _scoresContent;
    
    [Header("UI")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menuWindow;
    
    private PlayerModel _playerModel;
    
    private void Start()
    {
        OpenMenuWindow(true);
        _playerModel = DataService.instance.playerModel;
        
        _difficultSelector.Initialize(this, _playerModel.levelDifficulty);
        
        _startButton.onClick.AddListener(PrepareGame);
        _exitButton.onClick.AddListener(() => Application.Quit());
        
        _levelController.Initialize();
        _levelController.OnStopGame += StopGame;
    }

    public void ChangeDifficulty(LevelDifficulty difficulty)
    {
        _playerModel.levelDifficulty = difficulty;
    }

    public void PrepareGame()
    {
        OpenMenuWindow(false);
        _levelController.StartGame(_playerModel.levelDifficulty);
    }
    
    public void StopGame(int score, LevelDifficulty levelDifficulty)
    {
        _playerModel.TryUpdateScore(score, levelDifficulty);
        _scoresContent.UpdateValues();
        OpenMenuWindow(true);
    }

    public void OpenMenuWindow(bool isOpen)
    {
        _menuWindow.SetActive(isOpen);
    }

    private void OnDestroy()
    {
        _levelController.OnStopGame -= StopGame;
    }
}
