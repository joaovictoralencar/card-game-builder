using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Asset/New Logic/New FieldCardLogic")]
public class FieldCardLogic : Logic
{
    public PlayerState attacking;
    Card attackingCard, targetCard;
    public override void OnClick(Card card)
    {
        if (card.OwnerPlayer == Settings.main.currentPlayer)
        {
            if (card.OwnerPlayer.State == card.OwnerPlayer.stats.normalState && card.OwnerPlayer.CanAttack)
            {
                card.OwnerPlayer.State = attacking;
                Settings.main.UpdateUI();
                attackingCard = card;
                card.OwnerPlayer.StartCoroutine(SelectTarget());
            }
            else
            {
                card.OwnerPlayer.State = card.OwnerPlayer.stats.normalState;
                card.OwnerPlayer.StopCoroutine(SelectTarget());
                Settings.main.UpdateUI();
            }
        }
        else
        {
            if (card.OwnerPlayer.State == card.OwnerPlayer.stats.normalState)
            {
                targetCard = card;
            }
        }
    }

    public override void OnHover(Card card)
    {
    }

    IEnumerator SelectTarget()
    {
        yield return new WaitUntil(() => targetCard != null);
        if (!attackingCard.OwnerPlayer.FieldCards.Contains(targetCard))
        {
            attackingCard.OwnerPlayer.Attack(attackingCard, targetCard);
            targetCard = null;
        }
    }
}
