using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4 : MonoBehaviour
{

    private void OnEnable()
    {
        //Cogemos el UIDocument
        VisualElement rootve = GetComponent<UIDocument>().rootVisualElement;

        //Cogemos el texto
        Label texto1 = rootve.Q<Label>("Ready");
        //Sin el @ no se activan los comandos
        texto1.text = @"Get <b><color=""black""><gradient=""rosa-azul horizontal"">Ready</gradient></b> With ";

        //Cogemos el segundo texto
        Label texto2 = rootve.Q<Label>("Bibble");
        texto2.text = @"Elige una <b><color=""black""><gradient=""rosa-azul horizontal"">Bibble</gradient></b>";
    }
}
