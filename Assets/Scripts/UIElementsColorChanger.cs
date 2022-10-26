using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ChangeColor
{
    public class UIElementsColorChanger : ColorChanger
    {
        public override void SetColorValue(Color _color)
        {
            GetComponent<Image>().color = _color;
        }

        public override Color GetColorValue()
        {
            return GetComponent<Image>().color;
        }
    }
}
