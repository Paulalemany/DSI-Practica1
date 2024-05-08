using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ChooseClothes : MonoBehaviour
{
    private void OnEnable()
    {
        //Cogemos el UIDocument
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        //Cogemos los padres de los elementos que vamos a modificar
        VisualElement _DressBibble = root.Q("DressBibble");
        VisualElement _Caja1 = root.Q("Caja1");
        VisualElement _Caja2 = root.Q("Caja3");

        //Añadimos los manipuladores
        _Caja1.AddManipulator(new Resizer());
        _Caja2.AddManipulator(new Resizer());

        //Hacemos listas con los elementos que hay dentro de cada padre
        List<VisualElement> lC1 = _Caja1.Children().ToList();
        List<VisualElement> lC2 = _Caja2.Children().ToList();

        lC1.ForEach(c => c.AddManipulator(new Resizer()));
        lC2.ForEach(c => c.AddManipulator(new Resizer()));

        for (int i = 0; i < lC1.Count; i++)
        {
            VisualElement c = lC1[i];
            c.RegisterCallback<MouseEnterEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1.1f, 1.1f);

            }, TrickleDown.TrickleDown);

            c.RegisterCallback<MouseLeaveEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1, 1);

            }, TrickleDown.TrickleDown);

        }

        for (int i = 0; i < lC2.Count; i++)
        {
            VisualElement c = lC2[i];
            c.RegisterCallback<MouseEnterEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1.1f, 1.1f);

            }, TrickleDown.TrickleDown);

            c.RegisterCallback<MouseLeaveEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1, 1);

            }, TrickleDown.TrickleDown);
        }

    }
}
