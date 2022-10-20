using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeColor
{
    public class SceneObjectsColorChanger : ColorChanger
    {
        protected override void SetColorValuesText()
        {
            _color = gameObject.GetComponent<MeshRenderer>().material.color;
            SetText();
        }

        public override void AddValueToParameterR(int value)
        {
            if (!_item.IsSelected) return;

            _color = gameObject.GetComponent<MeshRenderer>().material.color;
            var R =(float.Parse(_rValue.text)+value);
            _color.r = (float)R/255;
            gameObject.GetComponent<MeshRenderer>().material.color = _color;
            CorrectRText(R);
        }

        public override void ChangeColorParameterG()
        {
            if (!_item.IsSelected) return;

            _color = gameObject.GetComponent<MeshRenderer>().material.color;
            var G = _slider.value;
            _color.g = (float)G/255;
            gameObject.GetComponent<MeshRenderer>().material.color = _color;
            _gValue.text=Mathf.Round(G).ToString();
        }

        public override void SetRandomColorParameterB()
        {
            if (!_item.IsSelected) return;
            
            _color = gameObject.GetComponent<MeshRenderer>().material.color;
            var B = Random.Range(0,255);
            _color.b = (float)B/255;
            gameObject.GetComponent<MeshRenderer>().material.color = _color;
            _bValue.text=Mathf.Round(B).ToString();
        }
    }
}
