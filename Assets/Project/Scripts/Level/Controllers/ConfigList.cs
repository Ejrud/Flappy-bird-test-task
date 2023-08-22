using System;
using System.Collections.Generic;
using UnityEngine;

public class ConfigList : MonoBehaviour
{
    [SerializeField] private LevelConfig[] _levels;
    private Dictionary<LevelDifficulty, LevelConfig> _levelDictionary = new ();

    public LevelConfig GetLevelConfig(LevelDifficulty difficulty)
    {
        if (_levelDictionary.Count == 0)
            CreateConfigDictionary();
        
        if (_levelDictionary.TryGetValue(difficulty, out LevelConfig levelConfig))
            return levelConfig;
        
        throw new NotImplementedException();
    }
    
    private void CreateConfigDictionary()
    {
        _levelDictionary = new();

        foreach (var level in _levels)
        {
            _levelDictionary.Add(level.difficulty, level);
        }
    }
}
