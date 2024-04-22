using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    // 配列の宣言
    int[] map;

    //=============================================================
    // 配列の中身を出力する関数
    //=============================================================
    void PrintArray()
    {

        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {

            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    //=============================================================
    // 要素が見つからなかったときに-1を代入する関数
    //=============================================================
    int GetPlayerIndex()
    {

        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {

                return i;
            }
        }

        return -1;
    }

    //=============================================================
    // 2(箱)を押す関数
    //=============================================================
    bool PushBox(int number, int moveFrom, int moveTo)
    {

        // 移動先が範囲外なら移動できない
        if (moveTo < 0 || moveTo >= map.Length)
        {

            return false;
        }

        // 移動先に2(箱)があったら
        if (map[moveTo] == 2)
        {

            // どの方向に移動するかを算出
            int velocity = moveTo - moveFrom;

            // プレイヤーの移動先から、さらに先へ2(箱)を移動させる
            // 箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを
            // 呼び、処理が再帰している。移動可不可をboolで記録
            bool success = PushBox(2, moveTo, moveTo + velocity);

            // もし箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success)
            {

                return false;
            }
        }

        // プレイヤー、箱関わらずの移動処理
        map[moveTo] = number;
        map[moveFrom] = 0;

        return true;
    }

    // Start is called before the first frame update
    // Start = Initilize
    void Start()
    {

        // 配列の実態の作成と初期化
        map = new int[] { 0, 0, 2, 1, 0, 2, 0, 0, 0 };

        // 配列の中身を出力
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {

        // 右矢印キーを押したとき
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            // 見つからなかった時のために-1で初期化
            int playerIndex = GetPlayerIndex();

            // 数字を右に移動させる
            PushBox(1, playerIndex, playerIndex + 1);

            // 配列の中身を出力
            PrintArray();
        }

        // 左矢印キーを押したとき
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 見つからなかった時のために-1で初期化
            int playerIndex = GetPlayerIndex();

            // 数字を左に移動させる
            PushBox(1, playerIndex, playerIndex - 1);

            // 配列の中身を出力
            PrintArray();
        }
    }
}
