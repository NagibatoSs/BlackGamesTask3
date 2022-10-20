using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ChangeColor
{
    public class UIElementsColorChanger : ColorChanger
    {
        protected override void SetColorValuesText()
        {
            _color = GetComponent<Image>().color;
            SetText();
        }

        public override void AddValueToParameterR(int value)
        {
            if (!_item.IsSelected) return;

            _color = GetComponent<Image>().color;
            var R =(float.Parse(_rValue.text)+value);
            _color.r = (float)R/255;
            GetComponent<Image>().color = _color;
            CorrectRText(R);
        }


        public override void ChangeColorParameterG()
        {
            if (!_item.IsSelected) return;
            _color = GetComponent<Image>().color;
            var G = _slider.value;
            _color.g = (float)G/255;
            GetComponent<Image>().color = _color;
            _gValue.text=Mathf.Round(G).ToString();
        }

        public override void SetRandomColorParameterB()
        {
            if (!_item.IsSelected) return;
            _color = GetComponent<Image>().color;
            var B = Random.Range(0,255);
            _color.b = (float)B/255;
            GetComponent<Image>().color = _color;
            _bValue.text=Mathf.Round(B).ToString();
        }
    }
}
