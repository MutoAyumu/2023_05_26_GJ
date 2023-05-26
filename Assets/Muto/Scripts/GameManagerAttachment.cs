using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAttachment : MonoBehaviour
{
    [SerializeField] float _gameTime = 60f;
    [SerializeField] Transform[] _generatePositions;

    public float GameTime => _gameTime;
    public Transform[] GeneratePositions => _generatePositions;

    private void Start()
    {
        GameManager.Instance.OnInit(this);
    }
}
