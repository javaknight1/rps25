using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class WeaponData {
    public string weapon;
    public string description;
    public Dictionary<string, string> reasons;

    public static WeaponData[] GetWeaponsFromJson(JSONObject jsonObject)
    {
        List<WeaponData> weapons = new List<WeaponData>();

        // go through each of the weapons
        foreach (JSONObject w in jsonObject.list)
        {
            WeaponData weapon = new WeaponData();
            weapon.weapon = w.GetField("weapon").str;
            weapon.description = w.GetField("description").str;
            weapon.reasons = new Dictionary<string, string>();
            for (int i = 0; i < w.GetField("reasons").list.Count; i++)
            {
                string key = w.GetField("reasons").keys[i];
                string value = w.GetField("reasons").GetField(key).str;
                weapon.reasons.Add(key, value);
            }

            weapons.Add(weapon);
        }

        return weapons.ToArray();
    }

    public bool IsWinner(WeaponData computer)
    {
        return this.reasons.ContainsKey(computer.weapon);
    }

    public string GetReason(WeaponData computer)
    {
        if (this.IsWinner(computer))
        {
            return this.reasons[computer.weapon];
        }
        else if (computer.IsWinner(this))
        {
            return computer.reasons[this.weapon];
        }
        else
        {
            return "Tie Game!";
        }
    }
}
