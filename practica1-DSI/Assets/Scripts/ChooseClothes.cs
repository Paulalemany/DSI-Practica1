using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
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

        //Sitios donde poner la ropa
        VisualElement vestido = root.Q("top");
        VisualElement cabeza = root.Q("cabeza");
        VisualElement zapatos = root.Q("zapatos");
        VisualElement top = root.Q("arriba");
        VisualElement bottom = root.Q("abajo");

        //Personajes
        VisualElement _Pareja1 = root.Q("cyn_pau");
        VisualElement _Pareja2 = root.Q("nieves_andreh");


        //Hacemos listas con los elementos que hay dentro de cada padre
        List<VisualElement> lC1 = _Caja1.Children().ToList();
        List<VisualElement> lC2 = _Caja2.Children().ToList();

        List<VisualElement> par1 = _Pareja1.Children().ToList();
        List<VisualElement> par2 = _Pareja2.Children().ToList();

        List<VisualElement> pers = root.Query(className: "personaje").ToList();


        //Callbacks caja 1
        for (int i = 0; i < lC1.Count; i++)
        {
            VisualElement uno = lC1[i];
            uno.RegisterCallback<MouseEnterEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1.1f, 1.1f);

            }, TrickleDown.TrickleDown);

            uno.RegisterCallback<MouseLeaveEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1, 1);

            }, TrickleDown.TrickleDown);

            uno.RegisterCallback<MouseDownEvent>(
                ev =>
                {
                    string nombre = uno.name;

                    if (uno.ClassListContains("vestido"))
                    vestido.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (uno.ClassListContains("cabeza"))
                        cabeza.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (uno.ClassListContains("zapatos"))
                        zapatos.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (uno.ClassListContains("top"))
                        top.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (uno.ClassListContains("falda"))
                        bottom.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                }
                );

        }

        //Callbacks caja 2
        for (int i = 0; i < lC2.Count; i++)
        {
            VisualElement dos = lC2[i];
            dos.RegisterCallback<MouseEnterEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1.1f, 1.1f);

            }, TrickleDown.TrickleDown);

            dos.RegisterCallback<MouseLeaveEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1, 1);

            }, TrickleDown.TrickleDown);

            dos.RegisterCallback<MouseDownEvent>(
                ev =>
                {
                    string nombre = dos.name;

                    if (dos.ClassListContains("vestido"))
                        vestido.style.backgroundImage =
                            new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (dos.ClassListContains("cabeza"))
                        cabeza.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (dos.ClassListContains("zapatos"))
                        zapatos.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (dos.ClassListContains("top"))
                        top.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                    else if (dos.ClassListContains("falda"))
                        bottom.style.backgroundImage =
                        new StyleBackground(Resources.Load<Sprite>("images/ropa/" + nombre));

                }
                );
        }

        //Calbacks pareja
        for (int i = 0; i < par1.Count; i++)
        {
            VisualElement par = par1[i];
            par.RegisterCallback<MouseDownEvent>(
                ev =>
                {
                    string nombre = par.name;

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
