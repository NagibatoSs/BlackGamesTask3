using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeColor
{
    public class SceneObjectsColorChanger : ColorChanger
    {

        public override void SetColorValue(Color _color)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = _color;
        }

        public override Color GetColorValue()
        {
            return gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }
}
