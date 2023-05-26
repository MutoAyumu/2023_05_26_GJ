using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance => instance;

    public int Score { get => _score; set => _score = value; }
    public float GameTime => _gameTime;

    float _gameTime;
    int _score;
    LifeState _lifeState;
    Transform[] _generatePositions;
    bool[] _generateFlag;
    GameData _gameData;
    int _currentIndex;
    Text _scoreText;
    Text _gameTimeText;

    enum LifeState
    {
        Stop,
        Run
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        OnGameStart();
    }
    public void OnInit(GameManagerAttachment attachment)
    {
        _gameData = attachment.GameData;
        _gameTime = _gameData.GameTime;
        _gameTimeText = attachment.GameTimeText;
        _scoreText = attachment.ScoreText;
        _score = 0;
        _generatePositions = attachment.GeneratePositions;
        _generateFlag = new bool[_generatePositions.Length];
        _lifeState = LifeState.Stop;
    }
    public void OnGameStart()
    {
        _lifeState = LifeState.Run;
    }
    private void Update()
    {
        //if (_lifeState == LifeState.Stop) return;

        _gameTime -= Time.deltaTime;

        if (_gameTime <= 0)
        {
            _lifeState = LifeState.Stop;
            _gameTime = 0;
        }

        _gameTimeText.text = _gameTime.ToString("00");
    }
    /// <summary>
    /// –„‚Ü‚Á‚Ä‚¢‚È‚¢ƒ}ƒX‚ð•Ô‚·
    /// </summary>
    /// <returns></returns>
    Transform? GetPosition(int random)
    {
        Transform ret = null;

        if (_generateFlag[random])
        {
            var count = 0;

            for (int i = 0; i < _generateFlag.Length; i++)
            {
                if (_generateFlag[i])
                {
                    count++;
                }
            }

            if (count >= _generateFlag.Length)
            {
                return null;
            }

            var r = Random.Range(0, _generateFlag.Length);
            ret = GetPosition(r);
        }

        ret = _generatePositions[random];
        _generateFlag[random] = true;

        return ret;
    }
    public Target[] GetObject()
    {
        if (_currentIndex >= _gameData.TargetDataArray.Length)
        {
            return null;
        }

        var array = _gameData.TargetDataArray[_currentIndex];
        Target[] ret = new Target[array.Array.Length];

        for (int i = 0; i < array.Array.Length; i++)
        {
            var random = Random.Range(0, _generateFlag.Length);
            var t = GetPosition(random);

            if (t == null)
            {
                return null;
            }

            ret[i] = Instantiate(_gameData.TargetPrefab, t.position, Quaternion.identity);

            var data = array.Array[i];
            ret[i].OnInit(data, random, _gameData.Sprites[(int)data.TargetType]);
        }

        _currentIndex++;

        return ret;
    }
    public void ClearPosition(int index)
    {
        _generateFlag[index] = false;
    }
}
