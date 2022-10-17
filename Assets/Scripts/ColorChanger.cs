using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ChangeColor
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rValue;
        [SerializeField] private TMP_Text _gValue;
        [SerializeField] private TMP_Text _bValue;
        private ItemOutliner _itemOutliner;
        private Color _color;
        void Start()
        {
            _itemOutliner = GetComponent<ItemOutliner>();
            _itemOutliner.OnSelect.AddListener(SetColors);
        }

         private void SetColors()
        {
            Debug.Log("set");
            _color = _itemOutliner.Color;
            _rValue.text = Mathf.Round(_color.r*255).ToString();
            _gValue.text = Mathf.Round(_color.g*255).ToString();
            _bValue.text = Mathf.Round(_color.b*255).ToString();
        }
    }
}
