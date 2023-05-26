using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
// 日本語対応
public class BgmManager : MonoBehaviour
{
    [SerializeField] private int _pitchChangeTime = 1;
    [SerializeField, Range(0f, 3f)] private float _changePitch = 1f;
    [SerializeField, Range(0f, 60f)] private float _testTimer = 0;
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
        if (_testTimer < _pitchChangeTime)
        {
            _audio.pitch = _changePitch;
        }
        else
        {
            _audio.pitch = _sevePitch;
        }
    }
}
