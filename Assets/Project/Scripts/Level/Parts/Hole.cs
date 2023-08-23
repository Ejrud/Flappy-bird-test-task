using System;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public event Action OnPlayerEnter;
    private const string PLAYER_TAG = "Player";
    [SerializeField] private AudioSource _audioSource;
    private PlayerModel _playerModel;
    
    private void Start()
    {
        // Минусы синлтонов в том что их можно пропихнуть куда угодно и благодаря этому большинству разработчиков
        // лень делать грамотную архитектуру и к сожалению я попал под это((
        
        // P.S. Но вообще если бы была возможость использовать DI контейнеры по типу Zenject или Vcontainer,
        // то можно было обойтись синглтонами
        _playerModel = DataService.instance.playerModel;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(PLAYER_TAG))
        {
            OnPlayerEnter?.Invoke();
            _audioSource.volume = _playerModel.soundValue;
            _audioSource.Play();
        }

    }
}
