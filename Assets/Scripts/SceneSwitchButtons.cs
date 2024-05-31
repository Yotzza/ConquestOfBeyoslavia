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
    public static void LoadCustomization()
    {
        SceneManager.LoadScene("Customization");
    }
    public static void LoadStageClear()
    {
        SceneManager.LoadScene("StageClearScene");
        if(PlayerDataClass.PlayerStage<=CharacterDataClass.CharacterStage){
            PlayerDataClass.PlayerStage+=1;
        }
    }

    public static void LoadLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public static void LoadRegister()
    {
        SceneManager.LoadScene("RegisterPlayer");
    }


    
    public static void LoadYouDiedScene()
    {
        SceneManager.LoadScene("YouDiedScene");
    }
    public static void LoadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
        
    }

    //LEVELS
    public static void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
        CharacterDataClass.CharacterStage=0;
        
    }

    
    public static void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
        CharacterDataClass.CharacterStage=1;
        
    }

    public static void LoadStage3()
    {
        SceneManager.LoadScene("Stage3");
        CharacterDataClass.CharacterStage=2;
        
    }

    public static void LoadStage4()
    {
        SceneManager.LoadScene("Stage4");
        CharacterDataClass.CharacterStage=3;
        
    }

    public static void LoadStage5()
    {
        SceneManager.LoadScene("Stage5");
        CharacterDataClass.CharacterStage=4;
        
    }
    public static void LoadStage6()
    {
        SceneManager.LoadScene("Stage6");
        CharacterDataClass.CharacterStage=5;
        
    }
    public static void LoadStage7()
    {
        SceneManager.LoadScene("Stage7");
        CharacterDataClass.CharacterStage=6;
        
    }
    public static void LoadStage8()
    {
        SceneManager.LoadScene("Stage8");
        CharacterDataClass.CharacterStage=7;
        
    }
    public static void LoadStage9()
    {
        SceneManager.LoadScene("Stage9");
        CharacterDataClass.CharacterStage=8;
        
    }


    public static void LoadPlayerMenuSlots()
    {
        SceneManager.LoadScene("PlayerSlot Menu");
    }




    

    public void ExitGame()
    {
        // If we are running in a standalone build of the game
        //#if UNITY_STANDALONE
            Application.Quit();
            DatabaseManager.SavePlayerData();
        //#endif

        // If we are running in the editor
        //#if UNITY_EDITOR
        //    UnityEditor.EditorApplication.isPlaying = false;
        //    DatabaseManager.SavePlayerData();
       // #endif
    }
    
}
