using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.transform.position, vec);
            Debug.DrawRay(Camera.main.transform.position, vec);
            if (hit2D)
            {
                Debug.Log($"{hit2D.collider.gameObject.name}");
            }
            _audio.Play();
        }

    }
}
