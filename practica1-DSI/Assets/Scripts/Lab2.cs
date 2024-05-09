using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab2 : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument document = GetComponent<UIDocument>();
        VisualElement rootve = document.rootVisualElement;

        List<VisualElement> lista_ve = rootve.Query(className: "elegido").ToList();

        foreach (var item in lista_ve)
        {
            item.AddToClassList("yess");
        }

        
    }
}
