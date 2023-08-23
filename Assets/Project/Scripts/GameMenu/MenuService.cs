using UnityEngine;
using UnityEngine.UI;

public class MenuService : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private LevelController _levelController;
    
    [Header("UI")]
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _menuWindow;
    
    private PlayerModel _playerModel;
    
    public void Start()
    {
        OpenMenuWindow(true);
        _playerModel = DataService.instance.playerModel;
        _startButton.onClick.AddListener(PrepareGame);
        
        _levelController.Initialize();
        _levelController.OnStopGame += StopGame;
    }

    public void PrepareGame()
    {
        OpenMenuWindow(false);
        _levelController.StartGame(_playerModel.levelDifficulty);
    }
    
    public void StopGame(int score, LevelDifficulty levelDifficulty)
    {
        _playerModel.TryUpdateScore(score, levelDifficulty);
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
