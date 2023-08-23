using UnityEngine;
using UnityEngine.UI;

public class VolumeSelector : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private PlayerModel _playerModel;
    
    public void Initialize()
    {
        _playerModel = DataService.instance.playerModel;
        _slider.onValueChanged.AddListener(ChangeVolume);
        _slider.value = _playerModel.soundValue;
    }

    private void ChangeVolume(float value)
    {
        _playerModel.soundValue = value;
    }
}
