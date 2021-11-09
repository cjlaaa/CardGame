using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
{
    public TextAsset CardDataFile;
    public List<Card> CardList = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        // LoadCardData();
        // TestLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCardData()
    {
        string[] dataRow = CardDataFile.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0]=="monster")
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int attack = int.Parse(rowArray[3]);
                int health = int.Parse(rowArray[4]);
                MonsterCard monsterCard = new MonsterCard(id, name, attack, health);
                CardList.Add(monsterCard);
            }
            else if (rowArray[0]=="spell")
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                string effect = rowArray[3];
                SpellCard spellCard = new SpellCard(id, name, effect);
                CardList.Add(spellCard);
            }
        }
    }

    public void TestLoad()
    {
        foreach (var item in CardList)
        {
            Debug.Log("卡牌:" + item.Id.ToString() + item.CardName.ToString());
        }
    }
    
    public Card RandomCard()
    {
        Card card = CardList[Random.Range(0, CardList.Count)];
        return card;
    }
}
