using System;
using System.IO;
using UnityEngine;

[Serializable]
public class DataService : MonoBehaviour
{
    public static DataService instance { get; private set; }
    public PlayerModel playerModel => _playerModel;

    [SerializeField] private string _loadPath;
    [SerializeField] private PlayerModel _playerModel;

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
        _loadPath = Application.dataPath + "/Project/SavedData/PlayerModel.json";
        print(File.Exists(_loadPath));
        
        if (File.Exists(_loadPath))
        {
            string fileContents = File.ReadAllText(_loadPath);
            PlayerModel data = JsonUtility.FromJson<PlayerModel>(fileContents);
            _playerModel = data;
        }
        else
        {
            ScoresModel scoresModel = new ScoresModel();
            _playerModel = new PlayerModel(LevelDifficulty.Easy, scoresModel, 0);
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