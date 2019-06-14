using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Card Asset/New CardType")]
public class CardType : ScriptableObject
{
    public string typeName;
    public bool isConsumable;
    public bool hasPower;
}
