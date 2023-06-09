using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] float _interval = 1f;
    float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            var go = GameManager.Instance.GetObject();

            if (go != null)
            {
                if (go.Length > 0)
                {
                    for (int i = 0; i < go.Length; i++)
                    {
                        if (go[i] == null) return;

                        go[i].transform.SetParent(this.transform);
                    }
                }
            }

            _timer = 0f;
        }
    }
}
