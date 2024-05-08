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
        VisualElement _Caja1 = root.Q("Caja1");
        VisualElement _Caja2 = root.Q("Caja3");
        VisualElement _Caja3 = root.Q("Foto");

        VisualElement _Pareja1 = root.Q("cyn_pau");
        VisualElement _Pareja2 = root.Q("nieves_andreh");

        //Añadimos los manipuladores
        _Caja1.AddManipulator(new Resizer());
        _Caja2.AddManipulator(new Resizer());

        //Hacemos listas con los elementos que hay dentro de cada padre
        List<VisualElement> lC1 = _Caja1.Children().ToList();
        List<VisualElement> lC2 = _Caja2.Children().ToList();

        List<VisualElement> par1 = _Pareja1.Children().ToList();
        List<VisualElement> par2 = _Pareja2.Children().ToList();

        List<VisualElement> pers = root.Query(className: "personaje").ToList();

        lC1.ForEach(c => c.AddManipulator(new Resizer()));
        lC2.ForEach(c => c.AddManipulator(new Resizer()));

        //Callbacks caja 1
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

        //Callbacks caja 2
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

        //Calbacks pareja 1
        for (int i = 0; i < par1.Count; i++)
        {
            VisualElement c = par1[i];
            c.RegisterCallback<MouseDownEvent>(
                ev =>
                {
                    string nombre = c.name;

                    foreach(VisualElement e in pers)
                    {
                        e.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/" + nombre));
                    }
                    
                }
                );

            VisualElement v = par2[i];
            v.RegisterCallback<MouseDownEvent>(
                ev =>
                {
                    string nombre = v.name;
                    foreach (VisualElement e in pers)
                    {
                        e.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/" + nombre));

                    }
                }
                );
        }

    }
}
