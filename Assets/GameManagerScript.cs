using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    // �z��̐錾
    int[] map;

    //=============================================================
    // �z��̒��g���o�͂���֐�
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
    // �v�f��������Ȃ������Ƃ���-1��������֐�
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
    // 2(��)�������֐�
    //=============================================================
    bool PushBox(int number, int moveFrom, int moveTo)
    {

        // �ړ��悪�͈͊O�Ȃ�ړ��ł��Ȃ�
        if (moveTo < 0 || moveTo >= map.Length)
        {

            return false;
        }

        // �ړ����2(��)����������
        if (map[moveTo] == 2)
        {

            // �ǂ̕����Ɉړ����邩���Z�o
            int velocity = moveTo - moveFrom;

            // �v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������
            // ���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h��
            // �ĂсA�������ċA���Ă���B�ړ��s��bool�ŋL�^
            bool success = PushBox(2, moveTo, moveTo + velocity);

            // ���������ړ����s������A�v���C���[�̈ړ������s
            if (!success)
            {

                return false;
            }
        }

        // �v���C���[�A���ւ�炸�̈ړ�����
        map[moveTo] = number;
        map[moveFrom] = 0;

        return true;
    }

    // Start is called before the first frame update
    // Start = Initilize
    void Start()
    {

        // �z��̎��Ԃ̍쐬�Ə�����
        map = new int[] { 0, 0, 2, 1, 0, 2, 0, 0, 0 };

        // �z��̒��g���o��
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {

        // �E���L�[���������Ƃ�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            // ������Ȃ��������̂��߂�-1�ŏ�����
            int playerIndex = GetPlayerIndex();

            // �������E�Ɉړ�������
            PushBox(1, playerIndex, playerIndex + 1);

            // �z��̒��g���o��
            PrintArray();
        }

        // �����L�[���������Ƃ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ������Ȃ��������̂��߂�-1�ŏ�����
            int playerIndex = GetPlayerIndex();

            // ���������Ɉړ�������
            PushBox(1, playerIndex, playerIndex - 1);

            // �z��̒��g���o��
            PrintArray();
        }
    }
}
