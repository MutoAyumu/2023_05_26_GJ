using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAttachment : MonoBehaviour
{
    [SerializeField] GameData[] _gameData;
    [SerializeField] Transform[] _generatePositions;

    public Transform[] GeneratePositions => _generatePositions;

    public GameData GameData 
    { 
        get
        {
            var r = Random.Range(0, _gameData.Length);
            return _gameData[r];
        }
    }

    private void Start()
    {
        GameManager.Instance.OnInit(this);
    }
}
