using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButtons : MonoBehaviour
{
    public static void LoadInventory()
    {
        SceneManager.LoadScene("Inventory");
    }
    public static void LoadWeapons()
    {
        SceneManager.LoadScene("Weapon");
    }
    public static void LoadArmor()
    {
        SceneManager.LoadScene("Armor");
    }
    public static void LoadEquipment()
    {
        SceneManager.LoadScene("Equipment");
    }
    
}
