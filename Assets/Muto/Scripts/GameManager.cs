using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance => instance;

    float _gameTime;
    int _score;
    LifeState _lifeState;
    Transform[] _generatePositions;
    bool[] _generateFrag;
    GameData _gameData;

    public int Score => _score;

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
    /// –„‚Ü‚Á‚Ä‚¢‚È‚¢ƒ}ƒX‚ð•Ô‚·
    /// </summary>
    /// <returns></returns>
    public Transform GetPosition()
    {
        var random = Random.Range(0, _generateFrag.Length);
        Transform ret = null;

        if(_generateFrag[random])
        {
            ret = GetPosition();
        }

        ret = _generatePositions[random];

        return ret;
    }
    public void ClearPosition(int index)
    {
        _generateFrag[index] = false;
    }
    public void AddScore(int score)
    {
        _score += score;
    }
}
