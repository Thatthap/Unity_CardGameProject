using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{

    public static DeckController instance;

    private void Awake()
    {
        instance = this;
    }


    public List<CardScriptableObject> DeckToUse = new List<CardScriptableObject>();

    private List<CardScriptableObject> activeCards = new List<CardScriptableObject>();

    public int drawCardCost = 1;

    public Card cardToSpawn;

    public float waitCardsToDraw = .25f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpDeck();
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (Input.GetKeyDown(KeyCode.T))
        {
            DrawCardToHand();
        }*/
    }

    public void SetUpDeck()
    {
        activeCards.Clear();

        List<CardScriptableObject> tempDeck = new List<CardScriptableObject>();
        tempDeck.AddRange(DeckToUse);

        int iterations = 0;
        //Card Amount
        while(tempDeck.Count > 0 && iterations < 30)
        {
            int Selected = Random.Range(0, tempDeck.Count);
            activeCards.Add(tempDeck[Selected]);
            tempDeck.RemoveAt(Selected);

            iterations++;
        }
    }

    public void DrawCardToHand()
    {
        if(activeCards.Count == 0)
        {
            SetUpDeck();
        }

       Card newCard = Instantiate(cardToSpawn, transform.position, transform.rotation);
        newCard.cardSO = activeCards[0];
        newCard.SetupCard();

        activeCards.RemoveAt(0);
        HandController.instance.AddCardToHand(newCard);
    }

    public void DrawCardForEndTurn()
    {
        //If End a Turn Then it will draw a card from deck = your card that you place on a board
        if(BattleController.instance.PlayerMana >= drawCardCost)
        {
            DrawCardToHand();
            BattleController.instance.SpendPlayerMana(drawCardCost);
        }
        else
        {
            UIController.instance.ShowManaWarning();
            UIController.instance.drawCardButton.SetActive(false);
        }

    }

    public void DrawMultipleCards(int AmounttoDraw)
    {
        StartCoroutine(DrawMultipleCo(AmounttoDraw));
    }

    IEnumerator DrawMultipleCo(int AmounttoDraw)
    {
        for (int i = 0; i < AmounttoDraw; i++)
        {
            DrawCardToHand();
            yield return new WaitForSeconds(waitCardsToDraw);
        }
    }
}
