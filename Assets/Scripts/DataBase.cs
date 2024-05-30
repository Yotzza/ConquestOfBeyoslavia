using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string connectionString = "URI=file:Bejoslavija.db";

    void Start()
    {
        CreateDatabaseAndTable();
        AddPlayerData(5, "dfg", 1, 1, 1, 1, 1, 1, 1, 1);
        FetchPlayerData();
        Debug.Log(PlayerDataClass.PlayerFaceID);
    }

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
                    PlayerLevel INTEGER
                )";
            SqliteCommand cmd = new SqliteCommand(createTableQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    public void FetchPlayerData()
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * FROM PlayerData WHERE PlayerID = 2", conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
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
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error fetching player data: " + ex.Message);
            }
        }
    }

    public void SavePlayerData()
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
                        PlayerLevel = @level
                    WHERE PlayerID = 1";

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

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.LogError("Error saving player data: " + ex.Message);
            }
        }
    }

    public void AddPlayerData(int faceID, string colorHex, int health, int damage, int armor, int speed, int stage, int exp, int skillPoints, int level)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = @"
                    INSERT INTO PlayerData (
                        PlayerFaceID, 
                        PlayerColorHex, 
                        PlayerHealth, 
                        PlayerDamage, 
                        PlayerArmor, 
                        PlayerSpeed, 
                        PlayerStage, 
                        PlayerExp, 
                        PlayerSkillPoints, 
                        PlayerLevel
                    ) VALUES (
                        @faceID, 
                        @colorHex, 
                        @health, 
                        @damage, 
                        @armor, 
                        @speed, 
                        @stage, 
                        @exp, 
                        @skillPoints, 
                        @level
                    )";

                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
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