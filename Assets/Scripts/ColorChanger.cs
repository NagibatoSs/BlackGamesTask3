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
        private Color _color;
        void Start()
        {
            GetComponent<ItemOutliner>().OnSelect.AddListener(SetColors);
        }

         private void SetColors()
        {
            _color = GetComponent<Image>().color;
            _rValue.text = Mathf.Round(_color.r*255).ToString();
            _gValue.text = Mathf.Round(_color.g*255).ToString();
            _bValue.text = Mathf.Round(_color.b*255).ToString();
        }

        private void AddValueToParameterR(int value)
        {
            _color = GetComponent<Image>().color;
            var R =(double.Parse(_rValue.text)+value);
            _color.r = (float)R/255;
            GetComponent<Image>().color = _color;
        }

        public void IncreaseColorParameterR(int value)
        {
            AddValueToParameterR(value);
            var rValue = Mathf.Round(_color.r*255);
            if (rValue<=255)
                _rValue.text = rValue.ToString();
            else 
                _rValue.text = "255";
        }

        public void DecreaseColorParameterR(int value)
        {
            AddValueToParameterR(-value);
            var rValue = Mathf.Round(_color.r*255);
            if (rValue>=0)
                _rValue.text = rValue.ToString();
            else 
                _rValue.text = "0";
        }
    }
}
