using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameReferances : MonoBehaviour
{

    public enum TankNames : int
    {
        LittleGolem = 1, Petriot = 2, Erebus = 3, Wrecker = 4, Imugi = 5, NightMare = 6, Cyclopse = 7,
        Typhoon = 8, Inferno = 9, BlackDeath = 10,
        Beast = 11, OverLord = 12, Shinigami = 13, Bhishma = 14, Titanizer = 15, None = 0
    };


    public enum TextureNames : int { Basic = 1, Lion = 2, Fox = 3, Eagle = 4, Jaguar = 5, Cheetah = 6,
        Panther = 7, Tiger = 8, Shark = 9, Fire = 10, Neon = 11, Skull = 12, Camouflage = 13, Custom1 = 14,
        Custom2 = 15, Custom3 = 16, Custom4 = 17, Custom5 = 18, None = 0 };

    public enum WeaponID : int { Invisible = 1, Emp = 2, AirStrike = 3, NavalStrike = 4, FlashBang = 5, None = 0 }


    public enum MissionType { KillWithTank, Kill, DealDamageWithTank, DealDamage, FlagCapture, Beaconcapture, HostileBeaconCapture, LoginWithFacebook, WatchAddd, Rank }


}
