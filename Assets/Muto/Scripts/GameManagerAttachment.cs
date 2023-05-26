using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAttachment : MonoBehaviour
{
    [SerializeField] GameData[] _gameData;
    [SerializeField] Transform[] _generatePositions;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _gameTimeText;

    public Transform[] GeneratePositions => _generatePositions;
    public Text ScoreText => _scoreText;
    public Text GameTimeText => _gameTimeText;

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
