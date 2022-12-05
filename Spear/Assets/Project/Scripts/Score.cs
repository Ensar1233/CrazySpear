using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public Transform player;

    private TextMeshProUGUI tmPro;
    public TextMeshProUGUI tmGemScore;

    void Start()
    {
        tmPro = player.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();

    }

    public string ExtensionScore
    {
        get
        {
            return tmPro.text;
        }
        set
        {
            tmPro.text = value;
        }
    }
     public string GemScore
    {
        get
        {
            return tmGemScore.text;
        }
        set
        {
            tmGemScore.text = value;
        }
    }

}
