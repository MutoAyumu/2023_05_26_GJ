using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewData", menuName = "CreateGameData")]
public class GameData : ScriptableObject
{
    public Target TargetPrefab;
    public float GameTime = 60f;
    public TargetDataArray[] TargetDataArray;
    public Sprite[] Sprites;
}
public enum TargetType
{
    Add = 0,
    Subtract = 1,
    Multiply = 2,
    Divide = 3,
}
[Serializable]
public class TargetDataArray
{
    public TargetData[] Array;
}
[Serializable]
public class TargetData
{
    public TargetType TargetType = TargetType.Add;
    public int Value = 1;
    public float Interval = 1f;
}