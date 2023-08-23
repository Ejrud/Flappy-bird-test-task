using Player;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundComponent : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    
    private JumpComponent _jumpComponent;
    private PlayerModel _playerModel;
    
    public void Init(JumpComponent jumpComponent)
    {
        _jumpComponent = jumpComponent;
        _jumpComponent.OnJump += PlaySound;
        _playerModel = DataService.instance.playerModel;
    }

    private void PlaySound()
    {
        _audioSource.volume = _playerModel.soundValue;
        _audioSource.PlayOneShot(_audioClip);
    }
}
