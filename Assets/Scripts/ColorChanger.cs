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
        protected bool _isChanging=false;
        protected int _changingR;
        protected float _timeLeft;
        protected float _activationDelay=0.15f;

        public abstract void SetColorValue(Color _color);

        public abstract Color GetColorValue();

        private void OnEnable() 
        {
            GetComponent<ItemOutliner>().OnSelect.AddListener(SetColorValuesText);
        }

        private void OnDisable() 
        {
            GetComponent<ItemOutliner>().OnSelect.RemoveListener(SetColorValuesText);
        }

        private void Start() 
        {
            _item = GetComponent<ItemOutliner>();
        }

        private void Update() 
        {
            if (_isChanging)
            {
                _timeLeft += Time.deltaTime;
                if (_timeLeft >= _activationDelay)
                {
                    _timeLeft = 0;
                    AddValueToParameterR(_changingR);
                }
            }
        }

        public void PressButtonChangeR(int R)
        {   
            if (R!=0)
            {
                _changingR = R;
                _isChanging = true;
            }
            else 
            {   
                _timeLeft = 0;
                _isChanging = false;
            }
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

        protected void SetColorValuesText()
        {
            _color = GetColorValue();
            SetText();
        }

        public void AddValueToParameterR(int value)
        {
            if (!_item.IsSelected) return;

            _color = GetColorValue();
            var R =(float.Parse(_rValue.text)+value);
            _color.r = (float)R/255;
            SetColorValue(_color);
            CorrectRText(R);
        }

        public void ChangeColorParameterG()
        {
            if (!_item.IsSelected) return;

            _color = GetColorValue();
            var G = _slider.value;
            _color.g = (float)G/255;
            SetColorValue(_color);
            _gValue.text=Mathf.Round(G).ToString();
        }

        public void SetRandomColorParameterB()
        {
            if (!_item.IsSelected) return;
            
            _color = GetColorValue();
            var B = Random.Range(0,255);
            _color.b = (float)B/255;
            SetColorValue(_color);
            _bValue.text=Mathf.Round(B).ToString();
        }
    }
}
