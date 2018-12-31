using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardManager : MonoBehaviour {

    private static CardManager Instance = null;

    private WeaponData[] weapons;
    private const string weaponsListFileName = "weapons.json";

    // Use this for initialization
    private CardManager() {
        string filePath = Path.Combine(Application.streamingAssetsPath, weaponsListFileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            WeaponsData weaponData = WeaponsData.CreateFromJSON(dataAsJson);
            this.weapons = weaponData.weapons;
        }
        else
        {
            // TODO: Handle an error case here
            this.weapons = new WeaponData[0];
        }
    }

    public static CardManager GetInstance()
    {
        if(Instance == null)
        {
            Instance = new CardManager();
        }

        return Instance;
    }

    public int numOfWeapons()
    {
        return weapons.Length;
    }

    public WeaponData getWeaponObject(int index)
    {
        return weapons[index];
    }

    public string getWeaponName(int index)
    {
        return weapons[index].weapon;
    }

    public string getWeaponDescription(int index)
    {
        return weapons[index].description;
    }

    public Sprite getWeaponArtworkSprite(int index)
    {
        return Resources.Load<Sprite>("Sprites/Weapons/" + weapons[index].weapon);
    }
	
}
