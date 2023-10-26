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
        TalkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        TalkData.Add(2000, new string[] { "여어:1,", "이 버그들을 고치면 나하고 대화할 수 있을텐데:3", "어떻게 한거냐.:2" });
        TalkData.Add(100, new string[] { "평범한 나무상자다." });
        TalkData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });

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
