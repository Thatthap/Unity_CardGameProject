using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacePoint : MonoBehaviour
{
    public static CardPlacePoint instance;

    public void Awake()
    {
        instance = this; 
    }

    public bool IsPlayerPlace { get; set; }
    public bool IsEnemyPlace { get; set; }

    public Card activeCard;
    public bool isPlayerPoint;
    public bool isEnemyPoint;
 //   public bool isEnemyPlace;
 //   public bool isPlayerPlace;

}
