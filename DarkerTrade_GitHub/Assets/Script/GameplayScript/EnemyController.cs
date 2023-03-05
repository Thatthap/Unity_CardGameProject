using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public static EnemyController instance;


    private void Awake()
    {
        instance = this;
    }

    public List<CardScriptableObject> deckToUse = new List<CardScriptableObject>();
    private List<CardScriptableObject> activeCards = new List<CardScriptableObject>();
    public Card cardToSpawn;
    public Transform cardSpawnPoint;

    public enum AIType { placeFromDeck,handRandomPlace,handDefensive,handAttacking}
    public AIType enemyAIType;

    private List<CardScriptableObject> cardsInHand = new List<CardScriptableObject>();
    public int startHandSize;

    // Start is called before the first frame update
    void Start()
    {
        SetUpDeck();

        if(enemyAIType != AIType.placeFromDeck)
        {
            SetUpHand();
        }

    }

    private List<int> GetAdjacentPoints(int index)
    { // For AI
        List<int> adjacentPoints = new List<int>();
        int row = index / 4;
        int col = index % 4;

        if (row > 0) adjacentPoints.Add((row - 1) * 4 + col); // top
        if (row < 3) adjacentPoints.Add((row + 1) * 4 + col); // bottom
        if (col > 0) adjacentPoints.Add(row * 4 + col - 1);   // left
        if (col < 3) adjacentPoints.Add(row * 4 + col + 1);   // right

        return adjacentPoints;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpDeck()
    {
        activeCards.Clear();

        List<CardScriptableObject> tempDeck = new List<CardScriptableObject>();
        tempDeck.AddRange(deckToUse);

        int iterations = 0;
        //Card Amount
        while (tempDeck.Count > 0 && iterations < 30)
        {
            int Selected = Random.Range(0, tempDeck.Count);
            activeCards.Add(tempDeck[Selected]);
            tempDeck.RemoveAt(Selected);

            iterations++;
        }
    }


    public void StartAction()
    {
        StartCoroutine(EnemyActionCo());
    }

    IEnumerator EnemyActionCo()
    {

        if (activeCards.Count == 0)
        {
            SetUpDeck();
        }

        yield return new WaitForSeconds(.5f);

        if (enemyAIType != AIType.placeFromDeck)
        {
            for(int i = 0; i < BattleController.instance.cardsToDrawPerTurn + BattleController.instance.EnemyCardPlace; i++)
            {
                cardsInHand.Add(activeCards[0]);
                activeCards.RemoveAt(0);

                if(activeCards.Count == 0)
                {
                    SetUpDeck();
                }
            }

            BattleController.instance.EnemyCardPlace = 0;
        }

        List<CardPlacePoint> cardPoints = new List<CardPlacePoint>();
        cardPoints.AddRange(CardPointController.instance.enemyCardPoints);

        int randomPoint = Random.Range(0, cardPoints.Count);
        CardPlacePoint selectedPoint = cardPoints[randomPoint];

        if(enemyAIType == AIType.placeFromDeck || enemyAIType == AIType.handRandomPlace)
        {
            cardPoints.Remove(selectedPoint);

            while (selectedPoint.activeCard != null && cardPoints.Count > 0)
            {
                randomPoint = Random.Range(0, cardPoints.Count);
                selectedPoint = cardPoints[randomPoint];
                cardPoints.RemoveAt(randomPoint);
            }
        }

        CardScriptableObject selectedCard = null;
        int iterations = 0;
        List<CardPlacePoint> preferredPoints = new List<CardPlacePoint>();
        List<CardPlacePoint> secondaryPoints = new List<CardPlacePoint>();


        switch (enemyAIType)
        {

            case AIType.placeFromDeck:


        if (selectedPoint.activeCard == null)
        {
                    if (CardPlacePoint.instance.IsPlayerPlace == true)
                    {

                    }
                    else
                    {
                        Card newCard = Instantiate(cardToSpawn, cardSpawnPoint.position, cardSpawnPoint.rotation);
                        newCard.cardSO = activeCards[0];
                        activeCards.RemoveAt(0);
                        newCard.SetupCard();
                        newCard.MovetoPoint(selectedPoint.transform.position, selectedPoint.transform.rotation);

                        selectedPoint.activeCard = newCard;
                        newCard.assignedPlace = selectedPoint;

                        while (selectedPoint.activeCard != null && cardPoints.Count > 0)
                        {
                            randomPoint = Random.Range(0, cardPoints.Count);
                            selectedPoint = cardPoints[randomPoint];
                            cardPoints.RemoveAt(randomPoint);
                        }
                    }

        }

                break;

            case AIType.handRandomPlace:

                selectedCard = SelectedCardtoPlay();

                iterations = 50;

                while (selectedCard != null && iterations > 0 && selectedPoint.activeCard == null)
                {
                    PlayCard(selectedCard, selectedPoint);


                    //check if we should try play another card
                    selectedCard = SelectedCardtoPlay();

                    iterations--;

                    yield return new WaitForSeconds(CardPointController.instance.TimeBetweenAttack);

                    while (selectedPoint.activeCard != null && cardPoints.Count > 0)
                    {
                        randomPoint = Random.Range(0, cardPoints.Count);
                        selectedPoint = cardPoints[randomPoint];
                        cardPoints.RemoveAt(randomPoint);
                    }

                }


                break;

            case AIType.handAttacking:
                selectedCard = SelectedCardtoPlay();

                preferredPoints.Clear();
                secondaryPoints.Clear();

                for (int i = 0; i < cardPoints.Count; i++)
                {
                    if (cardPoints[i].activeCard == null)
                    {
                        List<int> adjacentPoints = GetAdjacentPoints(i);
                        bool hasAdjacentPlayerCard = adjacentPoints.Any(p => CardPointController.instance.playerCardPoints[p].activeCard != null);

                        if (!hasAdjacentPlayerCard)
                        {
                            preferredPoints.Add(cardPoints[i]);
                        }
                        else
                        {
                            secondaryPoints.Add(cardPoints[i]);
                        }
                    }
                }

                iterations = 50;
                while (selectedCard != null && iterations > 0 && preferredPoints.Count + secondaryPoints.Count > 0)
                {
                    // Pick a Point to use
                    if (preferredPoints.Count > 0)
                    {
                        int selectPoint = Random.Range(0, preferredPoints.Count);
                        selectedPoint = preferredPoints[selectPoint];

                        preferredPoints.RemoveAt(selectPoint);
                    }
                    else
                    {
                        int selectPoint = Random.Range(0, secondaryPoints.Count);
                        selectedPoint = secondaryPoints[selectPoint];

                        secondaryPoints.RemoveAt(selectPoint);
                    }

                    PlayCard(selectedCard, selectedPoint);

                    //Check if we should try play another
                    selectedCard = SelectedCardtoPlay();
                    iterations--;

                    yield return new WaitForSeconds(CardPointController.instance.TimeBetweenAttack);
                }

                break;

            case AIType.handDefensive:

                selectedCard = SelectedCardtoPlay();

                preferredPoints.Clear();
                secondaryPoints.Clear();

                for(int i = 0; i < cardPoints.Count; i++)
                {
                    //AI Defensive
                    if(cardPoints[i].activeCard == null)
                    {
                        /* if(CardPointController.instance.playerCardPoints[0].activeCard != null)
                         {
                             preferredPoints.Add(cardPoints[1]);
                             preferredPoints.Add(cardPoints[4]);
                         }
                         else
                         {
                             secondaryPoints.Add(cardPoints[6]);
                             secondaryPoints.Add(cardPoints[8]);
                         }*/
                        List<int> adjacentPoints = GetAdjacentPoints(i);
                        bool hasAdjacentPlayerCard = adjacentPoints.Any(p => CardPointController.instance.playerCardPoints[p].activeCard != null);


                        if (hasAdjacentPlayerCard)
                        {
                            preferredPoints.Add(cardPoints[i]);
                        }
                        else
                        {
                            secondaryPoints.Add(cardPoints[i]);
                        }

                    }
                }

                    iterations = 50;
                    while(selectedCard != null && iterations > 0 && preferredPoints.Count + secondaryPoints.Count > 0)
                {
                    // Pick a Point to use
                    if(preferredPoints.Count > 0)
                    {
                        int selectPoint = Random.Range(0, preferredPoints.Count);
                        selectedPoint = preferredPoints[selectPoint];

                        preferredPoints.RemoveAt(selectPoint);
                    }
                    else
                    {
                        int selectPoint = Random.Range(0, secondaryPoints.Count);
                        selectedPoint = secondaryPoints[selectPoint];

                        secondaryPoints.RemoveAt(selectPoint);
                    }

                    PlayCard(selectedCard, selectedPoint);

                    //Check if we should try play another
                    selectedCard = SelectedCardtoPlay();
                    iterations--;

                    yield return new WaitForSeconds(CardPointController.instance.TimeBetweenAttack);
                }
            

                break;

          }


        yield return new WaitForSeconds(.5f);

        BattleController.instance.AdvanceTurn();
    }

    void SetUpHand()
    {

        for(int i = 0; i < startHandSize; i++)
        {

            if (activeCards.Count == 0)
            {
                SetUpDeck();
            }

            cardsInHand.Add(activeCards[0]);
            activeCards.RemoveAt(0);
        }
    }

    public void PlayCard(CardScriptableObject cardSO,CardPlacePoint placepoint)
    {
        Card newCard = Instantiate(cardToSpawn, cardSpawnPoint.position, cardSpawnPoint.rotation);
        newCard.cardSO = cardSO;

        newCard.SetupCard();
        newCard.MovetoPoint(placepoint.transform.position, placepoint.transform.rotation);

        placepoint.activeCard = newCard;
        newCard.assignedPlace = placepoint;

        cardsInHand.Remove(cardSO);

        BattleController.instance.SpendEnemyMana(cardSO.manaCost);
        BattleController.instance.EnemyCardPlace++;



        CardPlacePoint enemyCardPoint = CardPointController.instance.enemyCardPoints.FirstOrDefault(p => p.transform.position == placepoint.transform.position);
        if (enemyCardPoint != null)
        {
            enemyCardPoint.IsEnemyPlace = true;
            Debug.Log("IsEnemyPlaceTrue");
        }

       /* CardPlacePoint enemyCardPoint = CardPointController.instance.enemyCardPoints[i];
        enemyCardPoint.IsEnemyPlace = true;
        Debug.Log("IsEnemyPlaceTrue");*/
    }

    CardScriptableObject SelectedCardtoPlay()
    {
        CardScriptableObject cardToPlay = null;
        List<CardScriptableObject> cardsToPlay = new List<CardScriptableObject>();
        foreach(CardScriptableObject card in cardsInHand)
        {
            if(card.manaCost <= BattleController.instance.EnemyMana)
            {
                cardsToPlay.Add(card);
            }
        }

        if (cardsToPlay.Count > 0)
        {
            int selected = Random.Range(0, cardsToPlay.Count);

            cardToPlay = cardsToPlay[selected];
        }

        return cardToPlay;
    }
}
