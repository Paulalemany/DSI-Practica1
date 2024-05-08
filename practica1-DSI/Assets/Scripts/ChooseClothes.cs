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

        #region MouseEnter
        _Caja1.RegisterCallback<MouseEnterEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1.1f, 1.1f);

            }, TrickleDown.TrickleDown);

        _Caja2.RegisterCallback<MouseEnterEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1.1f, 1.1f);
            }, TrickleDown.TrickleDown);
        #endregion


        #region MouseLeave
        _Caja1.RegisterCallback<MouseLeaveEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1, 1);

            }, TrickleDown.TrickleDown);

        _Caja2.RegisterCallback<MouseLeaveEvent>(
            ev =>
            {
                (ev.target as VisualElement).transform.scale = new Vector3(1, 1);
            }, TrickleDown.TrickleDown);
        #endregion

    }
}
