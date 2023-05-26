using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
// 日本語対応
public class BgmManager : MonoBehaviour
{
    [SerializeField] private int _pitchChangeTime = 1;
    [SerializeField, Range(0f, 3f)] private float _changePitch = 1f;
    private float _sevePitch = 0f;
    private AudioSource _audio = null;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
        _sevePitch = _audio.pitch;
    }

    private void Update()
    {
        if (GameManager.Instance.GameTime < _pitchChangeTime)
        {
            _audio.pitch = _changePitch;
        }
        else
        {
            _audio.pitch = _sevePitch;
        }
    }
}
