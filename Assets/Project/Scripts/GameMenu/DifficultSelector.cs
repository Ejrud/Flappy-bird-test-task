using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultSelector : MonoBehaviour
{
    [Header("Collor settings")] 
    [SerializeField] private Color _activeColor = Color.white;
    [SerializeField] private Color _inactiveColor = Color.grey;
    
    
    [SerializeField] private ButtonHolder[] _buttonsArray;
    private Dictionary<LevelDifficulty, Button> _buttons;
    private MenuService _menuService;
    
    public void Initialize(MenuService menuService, LevelDifficulty startDifficulty)
    {
        _buttons = new Dictionary<LevelDifficulty, Button>();
        
        foreach (var unit in _buttonsArray)
            _buttons.Add(unit.levelDifficulty, unit.button);
        
        _menuService = menuService;
        foreach (var unit in _buttonsArray)
            unit.button.onClick.AddListener(() => { SelectDifficulty(unit.levelDifficulty); });
        
        SelectButton(startDifficulty);
    }

    private void SelectDifficulty(LevelDifficulty difficulty)
    {
        _menuService.ChangeDifficulty(difficulty);
        SelectButton(difficulty);
    }

    private void SelectButton(LevelDifficulty difficulty)
    {
        foreach (var unit in _buttons)
            unit.Value.GetComponent<Image>().color = _inactiveColor;

        if (_buttons.TryGetValue(difficulty, out Button button))
            button.GetComponent<Image>().color = _activeColor;
    }
}


