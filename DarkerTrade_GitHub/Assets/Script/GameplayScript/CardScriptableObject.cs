using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Card",menuName ="Card",order = 1)]

public class CardScriptableObject : ScriptableObject
{
    public string CardName;
    [TextArea]
    public string ActionDescription, CardLore;

    public int currentHeathLeft, currentHeathRight, currentHeathTop, currentHeathDown , attackPowerLeft, attackPowerRight, attackPowerTop, attackPowerDown , manaCost;

    public Sprite CardSprite;


}
