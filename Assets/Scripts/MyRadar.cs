using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNameSpace
{
    public class MyRadar : MonoBehaviour
    {
        private Transform playerPos;
        private static List<RadarObject> radarObjects = new List<RadarObject>();
        private float mapScale = 2f;
        private float detectionDist = 65f;

        private void Start()
        {
            playerPos = MyMain.Instance.GetPlayerObject.transform;
        }

        private void Update()
        {
            if (Time.frameCount % 3 == 0)
                DrawRadar();
        }

        public static void AddRadarObj(GameObject obj, Image i)
        {
            Image image = Instantiate(i);
            radarObjects.Add(new RadarObject { radObj = obj, radImage = image });
        }

        public static void RemoveRadarObj(GameObject obj)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (var o in radarObjects)
            {
                if (o.radObj == obj)
                {
                    Destroy(o.radImage);
                    continue;
                }

                newList.Add(o);
            }

            radarObjects.RemoveRange(0, radarObjects.Count);
            radarObjects.AddRange(newList);
        }

        private void DrawRadar()
        {
            foreach(var obj in radarObjects)
            {
                Vector3 objPos = obj.radObj.transform.position - playerPos.position;
                float distToObj = objPos.magnitude * mapScale;

                if (distToObj > detectionDist)
                {
                    obj.radImage.enabled = false;
                    return;
                }
                else obj.radImage.enabled = true;

                float angle = Mathf.Atan2(objPos.x, objPos.z) - playerPos.eulerAngles.y * Mathf.Deg2Rad;
                float posX = distToObj * Mathf.Sin(angle);
                float posZ = distToObj * Mathf.Cos(angle);

                obj.radImage.transform.rotation = Quaternion.Euler(0, 0, -obj.radObj.transform.eulerAngles.y + playerPos.eulerAngles.y);

                obj.radImage.transform.SetParent(transform);
                obj.radImage.transform.position = new Vector3(posX, posZ, 0) + transform.position;
            }
        }

        private struct RadarObject
        {
            public GameObject radObj;
            public Image radImage;
        }
    }
}
