using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNameSpace
{
    public class RadarTargetScript : MonoBehaviour
    {
        public Image image;

        private void Start()
        {
            MyRadar.AddRadarObj(gameObject, image);
        }

        private void OnDestroy()
        {
            MyRadar.RemoveRadarObj(gameObject);
        }
    }
}
