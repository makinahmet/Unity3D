//sometimes playerprefs is complicated because it can be difficult to remember what was the key for it or where did you used it.
//so it makes sense to create a player prefs class to make things easier and managable.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ambPlayerPrefs
{
    public static string[] drivingModes = {"buttonControl", "wheelControl"};

    public static string drivingMode{
        get { return PlayerPrefs.GetString("drivingMode"); }
        set { PlayerPrefs.SetString("drivingMode", value); }
    }

    public static int selectedOffroadVehicleIndex{
        get{return PlayerPrefs.GetInt("offRoadWehicleIndex");}
        set{PlayerPrefs.SetInt("offroadWehicleIndex", value);}
    }

    public static int selectedWrcVehicleIndex{
        get{return PlayerPrefs.GetInt("wrcWehicleIndex");}
        set{PlayerPrefs.SetInt("wrcWehicleIndex", value);}
    }
}
