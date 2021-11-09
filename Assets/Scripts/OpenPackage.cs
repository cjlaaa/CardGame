using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject CardPool;
    
    private CardStore CardStore;
    private List<GameObject> cards = new List<GameObject>();

    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        CardStore = GetComponent<CardStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickOpen()
    {
        if (playerData.PlayerCoins < 2)
        {
            return;
        }
        else
        {
            playerData.PlayerCoins -= 2;
        }
        
        ClearPool();
        for (int i = 0; i < 5; i++)
        {
            GameObject newCard = GameObject.Instantiate(CardPrefab, CardPool.transform);
            newCard.GetComponent<CardDisplay>().card = CardStore.RandomCard();
            cards.Add(newCard);
        }
        SaveCardData();
        playerData.SavePlayerData();
    }

    public void ClearPool()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }

    public void SaveCardData()
    {
        foreach (var card in cards)
        {
            int id = card.GetComponent<CardDisplay>().card.Id;
            playerData.PlayerCards[id] += 1;
        }
    }
}
