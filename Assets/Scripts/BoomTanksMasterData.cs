using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



#region customMasterDataStructs

[System.Serializable]
public struct TankPrice
{

    public string TankName;
    public string CurrencyType;
    public int ExperienceLevel;
    public int Price;


}
[System.Serializable]
public struct TankPriceMasterData
{
    public bool Status;
    public List<TankPrice> Data;


}



[System.Serializable]
public struct TankStatsUpgrade
{

    public string TankName;
    public int statsUpgradeLevel;

    public int health;
    public int speed;
    public int zoom;
    public int DamagePerBomb;
    public string CurrencyType;
    public int Price;
    public float upgradeTime;


}
[System.Serializable]
public struct TankStatsUpgradeMasterData
{
    public bool Status;
    public List<TankStatsUpgrade> Data;
}




[System.Serializable]
public struct TankSkin

{

    public string TankName;
    public string SkinName;
    public string CurrencyType;

    public int Price;


}
[System.Serializable]
public struct TankSkinMasterData

{
    public bool Status;
    public List<TankSkin> Data;
}


[System.Serializable]
public struct Hanger
{

    public int HangerID;
    public string CurrencyType;
    public int Price;


}
[System.Serializable]
public struct HangerMasterData
{
    public bool Status;
    public List<Hanger> Data;
}





[System.Serializable]
public struct Slot
{
    public int HangerID;
    public int SlotID;
    public string CurrencyType;
    public int Price;

}
[System.Serializable]
public struct SlotMasterData
{
    public bool Status;
    public List<Slot> Data;
}


[System.Serializable]
public struct Weapon
{

    public string WeaponName;
    public string WeaponType;
    public int WeaponLevel;
    public string CurrencyType;

    public int Price;


}


[System.Serializable]
public struct WeaponMasterData
{
    public bool Status;
    public List<Weapon> Data;
}


[System.Serializable]
public struct GameMode
{

    public string GameModeName;   // QuickMatch,  DeathMatch , TeamDeathMatch,CaptureTheFlag, BeaconCapture
    public string LongName;       // Quick Match,  Death Match , Team Death Match,Capture The Flag, Beacon Capture
    public string  GameModeType;  //      Indivisual,Team,Special
    public bool IsTeamMatch;
    public int ExpLevel;
    public bool IsAvailable;
    [TextArea(5,10)]
    public string ModeDescription;
    public string StartDate;
    public string EndDate;

}

[System.Serializable]
public struct GameModeData
{
    public bool Status;
    public List<GameMode> Data;

}

[System.Serializable]
public struct PlayerLevel
{
    public int Level;
    public int RequiredExperience;
}

[System.Serializable]

public struct PlayerLevelMasterData
{
    public bool Status;
    public List<PlayerLevel> Data;
}

[System.Serializable]
public struct MissionDescriptor
{
    public int ID;
    public string missionType;
    public int ExpLevel;
    public string[] supportedGameModes; // QuickMatch,  DeathMatch , TeamDeathMatch,CaptureTheFlag, BeaconCapture  ** all game modes shouls be without space
    public bool IsProgessiveMission;
    public bool MultipleMissionOfSameTypeSupported;
    public string Header;
    public string Description;
    public string Key;
    public int Value;
    public int RewardValue;
    public string RewardType;
    public int SkipMissionCost;
    public int WatchAddValue;


}

[System.Serializable]
public struct GameMissions 
{
    public bool Status;
    public List<MissionDescriptor> Data;

}


[System.Serializable]
public class TankMasterData
{

    public TankPriceMasterData TankPriceMastersData;
    public TankStatsUpgradeMasterData TankStatsUpgradeMasterData;
    public TankSkinMasterData TankSkinMasterData;
    public HangerMasterData HangerMasterData;
    public SlotMasterData SlotMasterData;
    public WeaponMasterData WeaponMasterData;
    public PlayerLevelMasterData PlayerLevelMasterData;


    public TankMasterData()
    {

        TankPriceMastersData.Data = new List<TankPrice>();
        TankStatsUpgradeMasterData.Data = new List<TankStatsUpgrade>();
        TankSkinMasterData.Data = new List<TankSkin>();
        HangerMasterData.Data = new List<Hanger>();
        SlotMasterData.Data = new List<Slot>();
        WeaponMasterData.Data = new List<Weapon>();
        PlayerLevelMasterData.Data = new List<PlayerLevel>();

    }
}

#endregion
public class BoomTanksMasterData : MonoBehaviour
{
    #region variables

    // string baseUrl = "http://192.168.43.204/boomtanks/api/MasterData/tankmasterdetails";


    const string masterLink = "http://192.168.43.204/boomtanks/api/MasterData/tankmasterdetails";


     TankMasterData TankMasterData;


    public TankPriceMasterDataSC TankPriceMasterDataSC;
    public TankSkinMasterDataSC TankSkinMasterDataSC;
    public TankStatsUpgradeMasterDataSC TankStatsUpgradeMasterDataSC;
    public HangerMasterDataSC HangerMasterDataSC;
    public SlotMasterDataSC SlotMasterDataSC;
    public WeaponMasterDatasc WeaponMasterDatasc;
    public PlayerLevelMasterDataSC PlayerLevelMasterDataSC;

    #endregion


    [ContextMenu("Create Json")]
    public void CreateJSonFile()
    {
        TankMasterData TankMasterData = new TankMasterData();

        TankMasterData.TankPriceMastersData = TankPriceMasterDataSC.TankPriceMasterData;
        TankMasterData.TankSkinMasterData = TankSkinMasterDataSC.TankSkinMasterData;
        TankMasterData.TankStatsUpgradeMasterData = TankStatsUpgradeMasterDataSC.TankStatsUpgradeMasterData;
        TankMasterData.HangerMasterData = HangerMasterDataSC.HangerMasterData;
        TankMasterData.SlotMasterData = SlotMasterDataSC.SlotMasterData;
        TankMasterData.WeaponMasterData = WeaponMasterDatasc.WeaponMasterData;
        TankMasterData.PlayerLevelMasterData = PlayerLevelMasterDataSC.PlayerLevelMasterData;

        SaveJsonDataInStreamingAssetFolder(TankMasterData, "BoomTanksMasterData.json");
    }

    public void SaveJsonDataInStreamingAssetFolder<T>(T t, string fileName)
    {

        string jsonString = JsonUtility.ToJson(t);
        string filepath = Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log("saving to  " + filepath);

        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }

        File.WriteAllText(filepath, jsonString);


    }

    public void LoadJsonDataFromStramingAssetFolder<T>(ref T t, string fileName)
    {

        string filepath = Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log("loading datat from " + filepath);
        if (File.Exists(filepath))
        {
            
            string jsonString = File.ReadAllText(filepath);
            t = JsonUtility.FromJson<T>(jsonString);
        }
        else
        {
            Debug.Log("*****  file not found *****");
        }

    }



    #region serverData
    /* private void Start()
     {
         StartCoroutine(LoadMasterData());
     }
     string Authenticate(string username, string password)
     {
         string auth = username + ":" + password;
         auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
         auth = "Basic " + auth;
         return auth;
     }
     public IEnumerator LoadMasterData()
     {

         string authorization = Authenticate("boomtanks", "indian@1361");

         UnityWebRequest www = UnityWebRequest.Get(masterLink);
         www.SetRequestHeader("AUTHORIZATION", authorization);
         yield return www.SendWebRequest();

         if (www.isNetworkError || www.isHttpError)
         {
             Debug.Log(www.error);

         }
         else if (www.isDone)
         {
             string jsonString = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
             Debug.Log(jsonString);
             TankMasterData = JsonUtility.FromJson<TankMasterData>(jsonString);
         }

     }*/

    #endregion

}

