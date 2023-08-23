using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private const int GAME_INDEX = 1;
    
    private void Start()
    {
        Application.targetFrameRate = 120;
        DataService.instance.TryLoadPlayerModel();
        SceneManager.LoadScene(GAME_INDEX);
    }
}
