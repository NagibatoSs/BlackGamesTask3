using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ChangeColor
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rValue;
        [SerializeField] private TMP_Text _gValue;
        [SerializeField] private TMP_Text _bValue;
        [SerializeField] private Slider _slider;
        private Color _color;
        private ItemOutliner _item;

        private void Start() 
        {
            _item = GetComponent<ItemOutliner>();
        }

        private void OnEnable() 
        {
            GetComponent<ItemOutliner>().OnSelect.AddListener(SetColorValuesText);
        }

        private void OnDisable() 
        {
            GetComponent<ItemOutliner>().OnSelect.RemoveListener(SetColorValuesText);
        }

         private void SetColorValuesText()
        {
            if (GetComponent<Image>()!=null)
                _color = GetComponent<Image>().color;
            else
                _color = gameObject.GetComponent<MeshRenderer>().material.color;
            _slider.value = Mathf.Round(_color.g*255);
            _rValue.text = Mathf.Round(_color.r*255).ToString();
            _gValue.text = Mathf.Round(_color.g*255).ToString();
            _bValue.text = Mathf.Round(_color.b*255).ToString();
        }
        //оставить только этот метод, сделать значение валуе + и -, правда хз что делать с проверками на 255 и 0
        private void AddValueToParameterR(int value)
        {
            if (!_item.IsSelected) return;
            if (GetComponent<Image>()!=null)
                _color = GetComponent<Image>().color;
            else
                _color = gameObject.GetComponent<MeshRenderer>().material.color;
            var R =(double.Parse(_rValue.text)+value);
            _color.r = (float)R/255;
            if (GetComponent<Image>()!=null)
                GetComponent<Image>().color = _color;
            else
                gameObject.GetComponent<MeshRenderer>().material.color = _color;
        }

        public void IncreaseColorParameterR(int value)
        {
            if (!_item.IsSelected) return;
            AddValueToParameterR(value);
            var rValue = Mathf.Round(_color.r*255);
            if (rValue<=255)
                _rValue.text = rValue.ToString();
            else 
                _rValue.text = "255";
        }

        public void DecreaseColorParameterR(int value)
        {
            if (!_item.IsSelected) return;
            AddValueToParameterR(-value);
            var rValue = Mathf.Round(_color.r*255);
            if (rValue>=0)
                _rValue.text = rValue.ToString();
            else 
                _rValue.text = "0";
        }

        public void ChangeColorParameterG()
        {
            if (!_item.IsSelected) return;
            if (GetComponent<Image>()!=null)
                _color = GetComponent<Image>().color;
            else 
                _color = gameObject.GetComponent<MeshRenderer>().material.color;
            var G = _slider.value;
            _color.g = (float)G/255;
            if (GetComponent<Image>()!=null)
                GetComponent<Image>().color = _color;
            else 
                gameObject.GetComponent<MeshRenderer>().material.color = _color;
            _gValue.text=Mathf.Round(G).ToString();
        }

        public void SetRandomColorParameterB()
        {
            if (!_item.IsSelected) return;
            if (GetComponent<Image>()!=null)
                _color = GetComponent<Image>().color;
            else
                _color = gameObject.GetComponent<MeshRenderer>().material.color;
            var B = Random.Range(0,255);
            _color.b = (float)B/255;
             if (GetComponent<Image>()!=null)
                GetComponent<Image>().color = _color;
            else
                gameObject.GetComponent<MeshRenderer>().material.color = _color;
            _bValue.text=Mathf.Round(B).ToString();
        }
    }
}
