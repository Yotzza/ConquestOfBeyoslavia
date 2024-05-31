using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    private static string connectionString = "URI=file:Bejoslavija.db";

    void Start()
    {
        CreateDatabaseAndTable();
        //AddPlayerData(4,5, "dfg", 1, 1, 1, 1, 1, 1, 1, 1,"abc","jobe");
        //FetchPlayerData(2);
        //Debug.Log(PlayerDataClass.PlayerID);
    }

    //ne dira se
    private void CreateDatabaseAndTable()
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            conn.Open();
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS PlayerData (
                    PlayerID INTEGER PRIMARY KEY,
                    PlayerFaceID INTEGER,
                    PlayerColorHex TEXT,
                    PlayerHealth INTEGER,
                    PlayerDamage INTEGER,
                    PlayerArmor INTEGER,
                    PlayerSpeed INTEGER,
                    PlayerStage INTEGER,
                    PlayerExp INTEGER,
                    PlayerSkillPoints INTEGER,
                    PlayerLevel INTEGER,
                    PlayerUsername TEXT,
                    PlayerPassword TEXT,
                    PlayerItemList TEXT
                )";
            SqliteCommand cmd = new SqliteCommand(createTableQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    public static void DeletePlayer(int playerid){
        

using (var conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("DELETE FROM PlayerData WHERE PlayerID =" + playerid, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching player data: " + ex.Message);
            }
        }
    }

    public static string TurnIntoSQLList(){
        string playersqllist="";
        for (int i = 0; i < 30; i++)
        {
            if (PlayerDataClass.PlayerItemList.Contains(i)){
                 playersqllist+= 1;
            }
            else{
                playersqllist+= 0;
            }
            
        }
        return playersqllist;
    } 
    public static void LoadPlayerList(string sqlplayerlist){
        
        Debug.Log(sqlplayerlist.Length);
        for (int i = 0; i < sqlplayerlist.Length; i++)
        {
            char c = sqlplayerlist[i];
    
            if (c == '1'){
                Debug.Log("DAMN NIGGA");
                 PlayerDataClass.PlayerItemList.Add(i);
            }
            else{
                
            }
            
        }
        //Debug.Log(PlayerDataClass.PlayerItemList[0]);
        
    } 
    //uradjeno
    public static void FetchPlayerData(int playerid)
    {
        
        using (var conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM PlayerData WHERE PlayerID =" + playerid, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    PlayerDataClass.PlayerID=reader.GetInt32(reader.GetOrdinal("PlayerID"));
                    PlayerDataClass.PlayerFaceID = reader.GetInt32(reader.GetOrdinal("PlayerFaceID"));
                    PlayerDataClass.PlayerColorHex = reader.GetString(reader.GetOrdinal("PlayerColorHex"));
                    PlayerDataClass.PlayerHealth = reader.GetInt32(reader.GetOrdinal("PlayerHealth"));
                    PlayerDataClass.PlayerDamage = reader.GetInt32(reader.GetOrdinal("PlayerDamage"));
                    PlayerDataClass.PlayerArmor = reader.GetInt32(reader.GetOrdinal("PlayerArmor"));
                    PlayerDataClass.PlayerSpeed = reader.GetInt32(reader.GetOrdinal("PlayerSpeed"));
                    PlayerDataClass.PlayerStage = reader.GetInt32(reader.GetOrdinal("PlayerStage"));
                    PlayerDataClass.PlayerExp = reader.GetInt32(reader.GetOrdinal("PlayerExp"));
                    PlayerDataClass.PlayerSkillPoints = reader.GetInt32(reader.GetOrdinal("PlayerSkillPoints"));
                    PlayerDataClass.PlayerLevel = reader.GetInt32(reader.GetOrdinal("PlayerLevel"));
                    PlayerDataClass.PlayerItemList.Clear();
                    //Debug.Log(reader.GetOrdinal("PlayerItemList"));
                    string d1=reader.GetString(reader.GetOrdinal("PlayerItemList"));
                    Debug.Log(d1);
                    LoadPlayerList(d1);
                    Debug.Log(TurnIntoSQLList());
                    
                    
                    
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching player data: " + ex.Message);
            }
        }
    }

    public static bool SlotsOccupancy(int playerid,Image SlotImage,Text SlotUsername){
        //U DRUGOJ SKRIPTI MORA IMA BOOLEAN DA GLEDA DAL IMA GA IL NEMA
        //TAKODJE CLICK SCRIPTA DA GLEDA PO TOME

        using (var conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM PlayerData WHERE PlayerID =" + playerid.ToString(), conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    
                    SlotImage.color=Color.grey;
                    string PlayerUsername = reader.GetString(reader.GetOrdinal("PlayerUsername"));
                    SlotUsername.text=PlayerUsername;
                    
                    return true;
                }
                else{
                    
                    SlotUsername.text="New Profile";
                    SlotImage.color=Color.green;
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                Debug.LogError("Error fetching player data: " + ex.Message);
                return false;
            }
        }

    }
    
    public static void PlayerLoginScreen(Text usernameText){
        using (SqliteConnection conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM PlayerData WHERE PlayerID =" + PlayerDataClass.PlayerID, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    
                    string PlayerUsername = reader.GetString(reader.GetOrdinal("PlayerUsername"));
                    usernameText.text=PlayerUsername;
                    
                }
                
                
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching player data: " + ex.Message);
                
            }
        }

    }
    public static bool PasswordChecker(string inputpassword,Text continuetext){
        


        using (SqliteConnection conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT PlayerPassword FROM PlayerData WHERE PlayerID =" + PlayerDataClass.PlayerID, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    
                    string PlayerPassword = reader.GetString(reader.GetOrdinal("PlayerPassword"));
                    if (PlayerPassword==inputpassword){
                        FetchPlayerData(PlayerDataClass.PlayerID);
                        Debug.Log("Nice one");

                        Debug.Log(PlayerDataClass.PlayerID);
                    Debug.Log(PlayerDataClass.PlayerFaceID);
                    Debug.Log(PlayerDataClass.PlayerColorHex);
                    Debug.Log(PlayerDataClass.PlayerHealth);
                    Debug.Log(PlayerDataClass.PlayerDamage);
                    Debug.Log(PlayerDataClass.PlayerArmor); 
                    Debug.Log(PlayerDataClass.PlayerSpeed);
                    Debug.Log(PlayerDataClass.PlayerStage);
                    Debug.Log(PlayerDataClass.PlayerExp);
                    Debug.Log(PlayerDataClass.PlayerSkillPoints);
                    Debug.Log(PlayerDataClass.PlayerLevel);
                    SceneSwitchButtons.LoadLevelSelection();


                        //switch scene
                        return true;

                    }
                    else{
                        Debug.LogError("INVALID PASSWORD");
                        continuetext.text="INVALID PASSWORD";
                        return false;
                    }
                }
                else{
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching player data: " + ex.Message);
                return false;
            }
        }

    }

    public static bool PlayerUsernameChecker(string inputusername){
        using (SqliteConnection conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM PlayerData WHERE PlayerUsername = \"" + inputusername + "\"", conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    
                     //Debug.Log(reader.GetString);
 
                        return true;
  
                }
                else{
                    Debug.Log("NEMA");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching player data: " + ex.Message);
                return false;
            }
        }
    }
    public static void SavePlayerData()
    {
        
        using (SqliteConnection conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = @"
                    UPDATE PlayerData
                    SET 
                        PlayerFaceID = @faceID, 
                        PlayerColorHex = @colorHex, 
                        PlayerHealth = @health, 
                        PlayerDamage = @damage, 
                        PlayerArmor = @armor, 
                        PlayerSpeed = @speed, 
                        PlayerStage = @stage, 
                        PlayerExp = @exp, 
                        PlayerSkillPoints = @skillPoints, 
                        PlayerLevel = @level,
                        PlayerItemList=@playeritemlist
                    WHERE PlayerID =" + PlayerDataClass.PlayerID;

                SqliteCommand cmd = new SqliteCommand(query, conn);
                cmd.Parameters.AddWithValue("@faceID", PlayerDataClass.PlayerFaceID);
                cmd.Parameters.AddWithValue("@colorHex", PlayerDataClass.PlayerColorHex);
                cmd.Parameters.AddWithValue("@health", PlayerDataClass.PlayerHealth);
                cmd.Parameters.AddWithValue("@damage", PlayerDataClass.PlayerDamage);
                cmd.Parameters.AddWithValue("@armor", PlayerDataClass.PlayerArmor);
                cmd.Parameters.AddWithValue("@speed", PlayerDataClass.PlayerSpeed);
                cmd.Parameters.AddWithValue("@stage", PlayerDataClass.PlayerStage);
                cmd.Parameters.AddWithValue("@exp", PlayerDataClass.PlayerExp);
                cmd.Parameters.AddWithValue("@skillPoints", PlayerDataClass.PlayerSkillPoints);
                cmd.Parameters.AddWithValue("@level", PlayerDataClass.PlayerLevel);
                
                cmd.Parameters.AddWithValue("@playeritemlist", TurnIntoSQLList());
                Debug.Log(TurnIntoSQLList());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.LogError("Error saving player data: " + ex.Message);
            }
        }
    }

    public static void AddPlayerData(int playerID,int faceID, string colorHex, int health, int damage, int armor, int speed, int stage, int exp, int skillPoints, int level,string password, string username,string playeritemlist)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = @"
                    INSERT INTO PlayerData (
                        PlayerID,
                        PlayerFaceID, 
                        PlayerColorHex, 
                        PlayerHealth, 
                        PlayerDamage, 
                        PlayerArmor, 
                        PlayerSpeed, 
                        PlayerStage, 
                        PlayerExp, 
                        PlayerSkillPoints, 
                        PlayerLevel,
                        PlayerUsername,
                        PlayerPassword,
                        PlayerItemList
                        
                    ) VALUES (
                        @playerID,
                        @faceID, 
                        @colorHex, 
                        @health, 
                        @damage, 
                        @armor, 
                        @speed, 
                        @stage, 
                        @exp, 
                        @skillPoints, 
                        @level,
                        @username,
                        @password,
                        @playeritemlist
                    )";

                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@playerID", playerID);
                    cmd.Parameters.AddWithValue("@faceID", faceID);
                    cmd.Parameters.AddWithValue("@colorHex", colorHex);
                    cmd.Parameters.AddWithValue("@health", health);
                    cmd.Parameters.AddWithValue("@damage", damage);
                    cmd.Parameters.AddWithValue("@armor", armor);
                    cmd.Parameters.AddWithValue("@speed", speed);
                    cmd.Parameters.AddWithValue("@stage", stage);
                    cmd.Parameters.AddWithValue("@exp", exp);
                    cmd.Parameters.AddWithValue("@skillPoints", skillPoints);
                    cmd.Parameters.AddWithValue("@level", level);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@playeritemlist", playeritemlist);

                    cmd.ExecuteNonQuery();
                    Debug.Log("Player data added successfully.");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error adding player data: " + ex.Message);
            }
        }
    }
}
