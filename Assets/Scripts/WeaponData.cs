using UnityEngine;

[System.Serializable]
public class WeaponData {
    public string weapon;
    public string description;
    //public string artwork;  // name of artwork file
    //public Object reasons;  // reasons of winning/losing

    public static WeaponData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<WeaponData>(jsonString);
    }
}

[System.Serializable]
public class WeaponsData {
    public WeaponData[] weapons;

    public static WeaponsData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<WeaponsData>(jsonString);
    }
}
