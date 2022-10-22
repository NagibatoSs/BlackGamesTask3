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
        public ItemOutliner[] items;
       // UnityEvent OnSelect сделать отмену селекта других  
       //и добавить какое то выделение выбранного
        public UnityEvent OnSelect;
        [SerializeField] private GameObject _selectedVFXPrefab;
        private GameObject _vfx;

        public void SelectItem() 
        {
            OnSelect.Invoke();
            IsSelected=true;
            _vfx = Instantiate(_selectedVFXPrefab,transform.position,Quaternion.identity);
            _vfx.transform.parent = transform;
            _vfx.transform.position+= new Vector3(0,0,-1);
            _vfx.transform.localScale = new Vector3(5,5,5);
            Debug.Log(this.gameObject.name+" selected");
        }

        private void OnMouseDown() 
        {
            OnSelect.Invoke();
            IsSelected=true;
            _vfx = Instantiate(_selectedVFXPrefab,transform.position,Quaternion.identity);
            _vfx.transform.parent = transform;
            _vfx.transform.position+= new Vector3(0,0,-1);
            _vfx.transform.localScale = new Vector3(5,5,5);
            Debug.Log(this.gameObject.name+" selected");
        }

        public void UnselectElements()
        {
            foreach (var item in items)
            {
                item.IsSelected=false;
                Destroy(item._vfx);
                Debug.Log(item.gameObject.name+" unselected");
            }
        }
    }
}
