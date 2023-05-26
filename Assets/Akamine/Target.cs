using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] ParticleSystem _particleSystem;
    TargetData _data;
    int _index;

    float _timer;
    float _interval = 1;

    private void Awake()
    {
        if (_sprite == null)
        {
            _sprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            Destroy(gameObject);
            GameManager.Instance.ClearPosition(_index);
        }
    }

    public void OnInit(TargetData data, int index, Sprite sprite)
    {
        _data = data;
        _index = index;
        _interval = data.Interval;

        _sprite.sprite = sprite;
    }
    public void OnHit()
    {
        GameManager.Instance.Score = Test(_data);
        GameManager.Instance.ClearPosition(_index);

        var particle = Instantiate(_particleSystem, this.transform.position, Quaternion.identity);
        Destroy(particle, 1);
        Destroy(this.gameObject);
    }
    float Test(TargetData data)
    {
        var ret = GameManager.Instance.Score;

        if (data.TargetType == TargetType.Add)
        {
            ret += data.Value;
        }
        else if (data.TargetType == TargetType.Subtract)
        {
            ret -= data.Value;
        }
        else if (data.TargetType == TargetType.Multiply)
        {
            ret *= data.Value;
        }
        else if (data.TargetType == TargetType.Divide)
        {
            ret /= data.Value;
        }

        return ret;
    }
}

