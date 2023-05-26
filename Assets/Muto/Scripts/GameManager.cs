using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance => instance;

    public int Score { get => _score; set => _score = value; }

    float _gameTime;
    int _score;
    LifeState _lifeState;
    Transform[] _generatePositions;
    bool[] _generateFrag;
    GameData _gameData;
    int _currentIndex;

    enum LifeState
    {
        Stop,
        Run
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void OnInit(GameManagerAttachment attachment)
    {
        _gameData = attachment.GameData;
        _gameTime = _gameData.GameTime;
        _score = 0;
        _generatePositions = attachment.GeneratePositions;
        _generateFrag = new bool[_generatePositions.Length];
        _lifeState = LifeState.Stop;
    }
    public void OnGameStart()
    {
        _lifeState = LifeState.Run;
    }
    private void Update()
    {
        if (_lifeState == LifeState.Stop) return;

        _gameTime -= Time.deltaTime;

        if(_gameTime <= 0)
        {
            _lifeState = LifeState.Stop;
            _gameTime = 0;
        }
    }
    /// <summary>
    /// 埋まっていないマスを返す
    /// </summary>
    /// <returns></returns>
    Transform GetPosition(int random)
    {
        Transform ret = null;

        if(_generateFrag[random])
        {
            ret = GetPosition(random);
        }

        ret = _generatePositions[random];
        _generateFrag[random] = true;

        return ret;
    }
    public Target GetObject()
    {
        var random = Random.Range(0, _generateFrag.Length);
        var t = GetPosition(random);
        var ret = Instantiate(_gameData.TargetPrefab, t.position, Quaternion.identity);

        ret.OnInit(_gameData.TargetDataArray[_currentIndex], random);

        return ret;
    }
    public void ClearPosition(int index)
    {
        _generateFrag[index] = false;
    }
}
