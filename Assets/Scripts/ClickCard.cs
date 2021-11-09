using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CardState
{
    Library,
    Deck,
}

public class ClickCard : MonoBehaviour,IPointerDownHandler
{
    private DeckManager DeckManager;
    private PlayerData PlayerData;

    public CardState State;
    // Start is called before the first frame update
    void Start()
    {
        DeckManager = GameObject.Find("DataManager").GetComponent<DeckManager>();
        PlayerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        
    }
}
