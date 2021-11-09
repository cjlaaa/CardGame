using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public CardStore CardStore;
    public int PlayerCoins;
    public int[] PlayerCards;
    public int[] PlayerDeck;

    public TextAsset PlayerDataFile;
    
    // Start is called before the first frame update
    void Start()
    {
        // CardStore.LoadCardData();
        // LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerData()
    {
        PlayerCards = new int[CardStore.CardList.Count];
        PlayerDeck = new int[CardStore.CardList.Count];
        string[] dataRow = PlayerDataFile.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0]=="coins")
            {
                PlayerCoins = int.Parse(rowArray[1]);
            }
            else if (rowArray[0]=="card")
            {
                int id = int.Parse(rowArray[1]);
                int num = int.Parse(rowArray[2]);
                PlayerCards[id] = num;
            }
            else if (rowArray[0]=="deck")
            {
                int id = int.Parse(rowArray[1]);
                int num = int.Parse(rowArray[2]);
                PlayerDeck[id] = num;
            }
        }    
    }
    
    public void SavePlayerData()
    {
        string path = Application.dataPath + "/Datas/playerdata.csv";
        
        List<string> datas = new List<string>();
        datas.Add("coins," + PlayerCoins.ToString());
        for (int i = 0; i < PlayerCards.Length; i++)
        {
            if (PlayerCards[i] != 0)
            { 
                datas.Add("card," + i.ToString() + "," + PlayerCards[i].ToString());
            }
        }

        for (int i = 0; i < PlayerDeck.Length; i++)
        {
            if (PlayerDeck[i] != 0)
            { 
                datas.Add("deck," + i.ToString() + "," + PlayerDeck[i].ToString());
            }
        }
        
        File.WriteAllLines(path, datas);
    }
}
