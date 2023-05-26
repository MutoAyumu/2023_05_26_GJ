using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAttachment : MonoBehaviour
{
    [SerializeField] GameData _gameData;
    [SerializeField] Transform[] _generatePositions;

    public GameData GameData => _gameData;
    public Transform[] GeneratePositions => _generatePositions;

    private void Start()
    {
        GameManager.Instance.OnInit(this);
    }
}
