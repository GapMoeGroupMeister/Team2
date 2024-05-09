using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasySave.Json;

public class PlayDataManager : MonoSingleton<PlayDataManager>
{
    [SerializeField] public PlayData playData;

    public void SavePlayData()
    {
        EasyToJson.ToJson(playData, "PlayData", true);
    }

    public PlayData LoadPlayData()
    {
        playData = EasyToJson.FromJson<PlayData>("PlayData");
        return playData;
    }

    private void OnDestroy()
    {
        SavePlayData();
    }
}
