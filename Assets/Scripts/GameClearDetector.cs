using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;
    public GameObject clearMsg;

    // 古い表現なのでコメントアウト
    // void OnGUI()
    // {
    //     // 全てのボールが入ったらラベルを表示
    //     // if (holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
    //     if (holeRed.IsHolding && holeBlue.IsHolding && holeGreen.IsHolding)
    //     {
    //         GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!");
    //     }
    // }

    void Start()
    {

    }

    void Update()
    {
        if (holeRed.IsHolding && holeBlue.IsHolding && holeGreen.IsHolding)
        {
            clearMsg.SetActive(true);
        }
        else
        {
            clearMsg.SetActive(false);
        }
    }
}
