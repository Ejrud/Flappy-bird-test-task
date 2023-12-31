using System;
using System.IO;
using UnityEngine;

[Serializable]
public class DataService : MonoBehaviour
{
    public static DataService instance { get; private set; }
    public AppsFlyerService appsFlyerService => _appsFlyerService;
    public PlayerModel playerModel => _playerModel;

    [SerializeField] private string _loadPath;
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private AppsFlyerService _appsFlyerService;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public void TryLoadPlayerModel()
    {
        _loadPath = Path.Combine(Application.persistentDataPath, "PlayerModel.json");
        Debug.Log(File.Exists(_loadPath));
        
        if (File.Exists(_loadPath))
        {
            string fileContents = File.ReadAllText(_loadPath);
            PlayerModel data = JsonUtility.FromJson<PlayerModel>(fileContents);
            _playerModel = data;
        }
        else
        {
            ScoresModel scoresModel = new ScoresModel();
            _playerModel = new PlayerModel(LevelDifficulty.Easy, scoresModel, 0.5f);
        }
    }
    
    private void SavePlayerData()
    {
        var json = JsonUtility.ToJson(_playerModel);

        using (FileStream fs = new FileStream(_loadPath, FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(json);
            }
        }

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif

    }

    private void OnDestroy()
    {
        SavePlayerData();
    }
}