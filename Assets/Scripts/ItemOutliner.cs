using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

namespace ChangeColor
{
    public class ItemOutliner : MonoBehaviour
    {
        [HideInInspector] public bool IsSelected=false;
        public Color Color {get; private set;}
        public ItemOutliner[] items;
       // UnityEvent OnSelect сделать отмену селекта других  
       //и добавить какое то выделение выбранного
        public UnityEvent OnSelect;

        public void SelectItem() 
        {
            Color = GetComponent<Image>().color;
            OnSelect.Invoke();
            IsSelected=true;
            Debug.Log(this.gameObject.name+" selected");
        }

        private void OnMouseDown() 
        {
            Color = gameObject.GetComponent<MeshRenderer>().material.color;
            OnSelect.Invoke();
            IsSelected=true;
            Debug.Log(this.gameObject.name+" selected");
        }

        public void UnselectElements()
        {
            foreach (var item in items)
            {
                item.IsSelected=false;
                Debug.Log(item.gameObject.name+" unselected");
            }
        }
    }
}
