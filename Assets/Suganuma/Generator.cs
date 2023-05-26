using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] _go;
    [SerializeField] float _interval = 1f;
    float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            int n = Random.Range(0, _go.Length);
            Instantiate(_go[n],GameManager.Instance.GetPosition()) ;

            _timer = 0f;
        }
    }
}
