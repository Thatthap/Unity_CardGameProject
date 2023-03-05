using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public static HandController instance;
    public List<Card> HeldCards = new List<Card>();
    public Transform minPos, maxPos;
    public List<Vector3> cardPosition = new List<Vector3>();


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCardPositionInHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardPositionInHand()
    {
        cardPosition.Clear();

        Vector3 distanceBetweenPoints = Vector3.zero;
        if(HeldCards.Count > 1)
        {
            distanceBetweenPoints = (maxPos.position - minPos.position) / (HeldCards.Count - 1);
        }

        for(int i = 0; i < HeldCards.Count; i++)
        {
            cardPosition.Add(minPos.position + (distanceBetweenPoints * i));

            //HeldCards[i].transform.position = cardPosition[i];
            //HeldCards[i].transform.rotation = minPos.rotation;

            //This will tell you where the card should move to
            HeldCards[i].MovetoPoint(cardPosition[i],minPos.rotation);

            HeldCards[i].inHand = true;
            HeldCards[i].handPosition = i; 
        }
    }

    public void RemoveCardFromHand(Card cardToRemove)
    {
        if(HeldCards[cardToRemove.handPosition] == cardToRemove)
        {
            HeldCards.RemoveAt(cardToRemove.handPosition);

        }
        else
        {
            Debug.LogError("Card at position" + cardToRemove.handPosition + "is not the card being remove from hand");
        }

        SetCardPositionInHand();  
    }

    public void AddCardToHand(Card cardtoAdd)
    {
        HeldCards.Add(cardtoAdd);
        SetCardPositionInHand();
    }

}
