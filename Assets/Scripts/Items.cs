using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item
{
    public int ItemID;
    public string ItemName;
    public string ItemDescription;
    public int ItemHealth;
    public int ItemDamage;
    public int ItemArmor;
    public int ItemSpeed;
    
    public Item(int id, string name, string description, int health, int damage, int armor, int speed)
    {
        ItemID = id;
        ItemName = name;
        ItemDescription = description;
        ItemHealth = health;
        ItemDamage = damage;
        ItemArmor = armor;
        ItemSpeed = speed;
    }

   

    public static List<Item> AllItemsList;


    void Awake()
    {
        InitializeItems();
    }


    


//1-health
//2-damage
//3-armor
//4-speed


public static int ItemStatGetter(int i, Item item)
{
    switch (i)
    {
        case 1:
            return item.ItemHealth;
        case 2:
            return item.ItemDamage;
        case 3:
            return item.ItemArmor;
        case 4:
            return item.ItemSpeed;
        default:
            Debug.Log("Default case");
            return 0; // or whatever default value you want to return
    }
}



public static void InitializeItems(){

    AllItemsList = new List<Item>
        {
            new Item(0, "Knife", "A worn torch emitting a flickering light. (white/gray)", 0, 10, 0, 2),
            new Item(1, "Primitive Axe", "A worn axe with a rugged appearance. (white/gray)", 0, 15, 0, 0),
            new Item(2, "Mace", "A common mace used for close combat. (Common/green)", 20, 20, 0, 0),
            new Item(3, "Spear", "A common polearm for piercing enemies. (Common/green)", 0, 25, 0, 0),
            new Item(4, "Warhammer", "A common warhammer for heavy blows. (Common/green)", 40, 20, 0, 0),
            new Item(5, "Great Axe", "A common waraxe imbued with fiery magic. (Common/green)", 0, 30, 5, 0),
            new Item(6, "Sword", "An uncommon polearm with shadowy properties. (Uncommon/Blue)", 0, 35, 0, 5),
            new Item(7, "Greatsword", "An uncommon greatsword infused with enchantments. (Uncommon/Blue)", 0, 45, 5, 0),
            new Item(8, "Orc Warhammer", "An uncommon warhammer blessed with orc power. (Uncommon/Blue)", 100, 50, 10, 0),
            new Item(9, "Radic's Yatagan", "A legendary Yatagan empowered by hajduk forces. (Legendary/purple)", 50, 75, 10, 0),
            new Item(10, "Scrap Iron Cuirass", "A worn cuirass made from scrap iron. (white/gray)", 0, 0, 5, 10),
            new Item(11, "Corroded Steel Breastplate", "A breastplate showing signs of corrosion. (white/gray)", 0, 0, 12, 4),
            new Item(12, "Tin-plated Chainmail", "Chainmail plated with tin. (Common/green)", 0, 0, 13, 3),
            new Item(13, "Reinforced Bronze Armor", "Bronze armor reinforced for extra protection. (Common/green)", 0, 0, 20, 3),
            new Item(14, "Ironclad Battle Harness", "A sturdy harness providing good protection. (Common/green)", 10, 0, 20, 2),
            new Item(15, "Steel-Forged Platemail", "Platemail forged from high-quality steel. (Common/green)", 20, 0, 23, 2),
            new Item(16, "Mithril Scale Hauberk", "A hauberk made from lightweight mithril scales. (Uncommon/Blue)", 20, 0, 30, 2),
            new Item(17, "Adamantine Warplate", "Warplate made from the resilient adamantine metal. (Uncommon/Blue)", 25, 0, 35, 2),
            new Item(18, "Dragonforged Mail", "Mail forged by dragons, known for its strength. (Uncommon/Blue)", 35, 0, 45, 1),
            new Item(19, "Celestial Guardian's Plate", "Legendary plate armor blessed by celestial powers. (Legendary/purple)", 50, 50, 50, 0),
            new Item(20, "Aurora Belt", "A worn belt emitting a soft glow. (white/gray)", 10, 5, 1, 1),
            new Item(21, "Shadow Stride Boots", "Boots that allow silent and swift movement. (white/gray)", 0, 0, 1, 5),
            new Item(22, "NovaGlow Braces", "Braces glowing with the energy of a nova. (Common/green)", 10, 1, 8, 0),
            new Item(23, "Dragonheart Greaves", "Greaves made from the heart of a dragon. (Common/green)", 20, 0, 15, 0),
            new Item(24, "Ember Embrace Gloves", "Gloves emanating with the warmth of embers. (Common/green)", 50, 0, 1, 0),
            new Item(25, "Helmet of Discord", "A helmet causing chaos to those around. (Common/green)", 0, 0, 20, 0),
            new Item(26, "Celestial Charm", "A charm with celestial blessings. (Uncommon/Blue)", 0, 0, 0, 20),
            new Item(27, "Frostweave Pants", "Pants woven with frost magic. (Uncommon/Blue)", 100, 0, 10, 0),
            new Item(28, "Titan's Guard Pauldrons", "Pauldrons worn by the titans. (Uncommon/Blue)", 0, 0, 30, 0),
            new Item(29, "The One Ring", "The legendary ring with immense power. (Legendary/purple)", 100, 100, 10, 5)
        };
        Debug.Log("done");
  
//1-health
//2-damage
//3-armor
//4-speed




}
}