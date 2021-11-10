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

    private Dictionary<int, GameObject> libraryDic = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> deckDic = new Dictionary<int, GameObject>();
    
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
                CreateCard(i, CardState.Library);
            }
        }
    }
    
    public void UpdateDeck()
    {
        for (int i = 0; i < playerData.PlayerDeck.Length; i++)
        {
            if (playerData.PlayerDeck[i]>0)
            {
                CreateCard(i, CardState.Deck);
            }
        }
    }
    
    public void UpdateCard(CardState state, int id)
    {
        if (state == CardState.Deck)
        {
            playerData.PlayerDeck[id]--;
            playerData.PlayerCards[id]++;

            if (deckDic[id].GetComponent<CardCounter>().SetCounter(-1) == false)
            {
                deckDic.Remove(id);
            }

            if (libraryDic.ContainsKey(id))
            {
                libraryDic[id].GetComponent<CardCounter>().SetCounter(1);
            }
            else
            {
                CreateCard(id, CardState.Library);
            }
        }
        else if(state == CardState.Library)
        {
            playerData.PlayerDeck[id]++;
            playerData.PlayerCards[id]--;

            if (libraryDic[id].GetComponent<CardCounter>().SetCounter(-1) == false)
            {
                libraryDic.Remove(id);
            }
            if (deckDic.ContainsKey(id))
            {
                deckDic[id].GetComponent<CardCounter>().SetCounter(1);
            }
            else
            {
                CreateCard(id, CardState.Deck);
            }
        }
    }

    public void CreateCard(int id, CardState cardState)
    {
        Transform targetPanel;
        GameObject targetPrefab;
        var refData = playerData.PlayerCards;
        var targetDic = libraryDic;
        if (cardState == CardState.Library)
        {
            targetPanel = LibraryPanel;
            targetPrefab = LibraryCardPrefab;
        }
        else// if (cardState == CardState.Deck)
        {
            targetPanel = DeckPanel;
            targetPrefab = DeckCardPrefab;
            refData = playerData.PlayerDeck;
            targetDic = deckDic;
        }
        GameObject newCard = Instantiate(targetPrefab, targetPanel);
        newCard.GetComponent<CardCounter>().SetCounter(refData[id]);
        newCard.GetComponent<CardDisplay>().Card = cardStore.CardList[id];
        targetDic.Add(id, newCard);
    }
}
