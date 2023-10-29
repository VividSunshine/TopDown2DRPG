using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> TalkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        TalkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //Takj Data
        //NPC A:1000, NPC B:2000
        //Box:100, Desk:200
        TalkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });
        TalkData.Add(2000, new string[] { "����:1,", "�� ���׵��� ��ġ�� ���ϰ� ��ȭ�� �� �����ٵ�:3", "��� �Ѱų�.:2" });
        TalkData.Add(100, new string[] { "����� �������ڴ�." });
        TalkData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });

        //Quest Talk
        TalkData.Add(10 + 1000, new string[] { "� ��,:0", "�� ������ ���� ������ �ִٴµ�:1", "������ ȣ�� �ʿ� �絵�� �˷��ٲ���.:0" });

        TalkData.Add(11 + 2000, new string[] { "����.:1", "�� ȣ���� ������ ������ �°ž�?:0",
                                                "�׷� �� �� �ϳ� ���ָ� �����ٵ�...:1",
                                                "�� �� ��ó�� ������ ���� �� �ֿ������� �ϴµ�:0" });

        TalkData.Add(20 + 1000, new string[] { "�絵�� ����?:1", "���� �긮�� �ٴϸ� ������!:3", "���߿� �絵���� �Ѹ��� �ؾ߰ھ�.:3" });
        TalkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:1" });
        TalkData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�." });

        TalkData.Add(21 + 2000, new string[] { "��, ã���༭ ����.:2" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);

    }

    public string GetTalk(int id,int talkIndex)
    {
        if (!TalkData.ContainsKey(id))
        {
            if (!TalkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id = id % 100, talkIndex);  //Get First Talk
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);   //Get First Quest Talk
            }
        }

        if(talkIndex == TalkData[id].Length)
        {
            return null;
        }
        else
            return TalkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
