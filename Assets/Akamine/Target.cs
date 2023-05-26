using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    Text _text;
    TargetData _data;
    int _index;

    public void OnInit(TargetData data, int index)
    {
        _data = data;
        _index = index;

        _text.text = SetText(_data);
    }
    public void OnHit()
    {
        GameManager.Instance.Score = Test(_data);
        GameManager.Instance.ClearPosition(_index);

        Destroy(this.gameObject);
    }
    int Test(TargetData data)
    {
        var ret = GameManager.Instance.Score;

        if(data.TargetType == TargetType.Add)
        {
            ret += data.Value;
        }
        else if(data.TargetType == TargetType.Subtract)
        {
            ret -= data.Value;
        }
        else if(data.TargetType == TargetType.Multiply)
        {
            ret *= data.Value;
        }
        else if (data.TargetType == TargetType.Divide)
        {
            ret /= data.Value;
        }

        return ret;
    }
    string SetText(TargetData data)
    {
        var ret = "";

        if (data.TargetType == TargetType.Add)
        {
            ret = $"Å{{data.Value}";
        }
        else if (data.TargetType == TargetType.Subtract)
        {
            ret = $"Å|{data.Value}";
        }
        else if (data.TargetType == TargetType.Multiply)
        {
            ret = $"Å~{data.Value}";
        }
        else if (data.TargetType == TargetType.Divide)
        {
            ret = $"ÅÄ{data.Value}";
        }

        return ret;
    }
}

