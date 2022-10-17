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
        private bool isSelected=false;
        public Color Color {get; private set;}
       // UnityEvent OnSelect сделать отмену селекта других  
       //и добавить какое то выделение выбранного
        public UnityEvent OnSelect;

        public void SelectItem() 
        {
            Color = GetComponent<Image>().color;
            OnSelect.Invoke();
            isSelected=true;
            Debug.Log(this.gameObject.name+" selected");
        }

        private void OnMouseDown() 
        {
            Color = gameObject.GetComponent<MeshRenderer>().material.color;
            OnSelect.Invoke();
            isSelected=true;
            Debug.Log(this.gameObject.name+" selected");
        }
    }
}
