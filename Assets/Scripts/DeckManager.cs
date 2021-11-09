using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Transform DeckPanel;
    public Transform LibraryPanel;

    public GameObject DeckCardPrefab;
    public GameObject LibraryCardPrefab;

    public GameObject DataManager;
    
    private PlayerData playerData;
    private CardStore cardStore;
    
    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.GetComponent<PlayerData>();
        cardStore = DataManager.GetComponent<CardStore>();
        playerData.CardStore.LoadCardData();
        playerData.LoadPlayerData();
        
        UpdateLibrary();
        UpdateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateLibrary()
    {
        for (int i = 0; i < playerData.PlayerCards.Length; i++)
        {
            if (playerData.PlayerCards[i]>0)
            {
                GameObject newCard = Instantiate(LibraryCardPrefab, LibraryPanel);
                newCard.GetComponent<CardCounter>().Counter.text = playerData.PlayerCards[i].ToString();
                newCard.GetComponent<CardDisplay>().card = cardStore.CardList[i];
            }
        }
    }
    
    public void UpdateDeck()
    {
        for (int i = 0; i < playerData.PlayerDeck.Length; i++)
        {
            if (playerData.PlayerDeck[i]>0)
            {
                GameObject newCard = Instantiate(DeckCardPrefab, DeckPanel);
                newCard.GetComponent<CardCounter>().Counter.text = playerData.PlayerDeck[i].ToString();
                newCard.GetComponent<CardDisplay>().card = cardStore.CardList[i];
            }
        }
    }
}
