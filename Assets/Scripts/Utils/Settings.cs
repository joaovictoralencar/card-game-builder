using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public static class Settings
{
    public static Main main;
    private static ResourcesManager _resourcesManager;
    public static ResourcesManager GetResourcesManager()
    {
        if (_resourcesManager == null)
        {
            _resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
            _resourcesManager.OnStart();
        }
        return _resourcesManager;
    }

    public static List<RaycastResult> GetUIObjs()
    {
        PointerEventData dadosDoPonto = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> resultados = new List<RaycastResult>();
        EventSystem.current.RaycastAll(dadosDoPonto, resultados);
        return resultados;
    }

    public static void DefinirPaiCarta(Transform card, Transform parent)//essa função é foda... queria ter ela :'(
    {
        card.SetParent(parent);//define o pai da carta
        //depois faz os ajustes de posição, rotação e de escala
        card.localPosition = Vector3.zero;
        card.eulerAngles = parent.eulerAngles;//pra ficar na mesma perspectiva
        // card.localScale = new Vector3(0.28F, 0.28F, 0.28F);
    }
}
