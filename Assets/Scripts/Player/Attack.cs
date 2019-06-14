using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Card attackingCard;
    CardStats targetCard;
    public Card AttackingCard { get => attackingCard; set => attackingCard = value; }
    public CardStats TargetCard { get => targetCard; set => targetCard = value; }

    public void doAttack(){
        // AttackingCard.player.state = attacing;
    }
    IEnumerator ChoseTarget()
    {
        yield return new WaitUntil(() => targetCard != null);
    }
}
