using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ChangeColor
{
    public abstract class ColorChanger : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _rValue;
        [SerializeField] protected TMP_Text _gValue;
        [SerializeField] protected TMP_Text _bValue;
        [SerializeField] protected Slider _slider;
        protected Color _color;
        protected ItemOutliner _item;

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

        protected void SetText()
        {
            _slider.value = Mathf.Round(_color.g*255);
            _rValue.text = Mathf.Round(_color.r*255).ToString();
            _gValue.text = Mathf.Round(_color.g*255).ToString();
            _bValue.text = Mathf.Round(_color.b*255).ToString();
        }

        protected void CorrectRText(float R)
        {
            var rValue = Mathf.Round(_color.r*255);
            if (R<=255 && R>=0)
                _rValue.text = rValue.ToString();
            else if (R<0) _rValue.text = "0";
                else _rValue.text = "255";
        }

        protected abstract void SetColorValuesText();
        
        public abstract void AddValueToParameterR(int value);

        public abstract void ChangeColorParameterG();

        public abstract void SetRandomColorParameterB();
    }
}
