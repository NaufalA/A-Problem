using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class BoxFactory : MonoBehaviour, IFactory
    {
        private List<BoxController> _boxPool = new List<BoxController>();
        public GameObject Produce(GameObject prefab, Vector2 spawn, Transform parent, bool interactable)
        {
            GameObject newBox = GetObjectFromPool(prefab);

            newBox.transform.position = spawn;
            newBox.transform.SetParent(parent, false);
            
            if (!interactable)
            {
                newBox.GetComponent<BoxController>().enabled = false;
                newBox.GetComponent<BoxCollider2D>().enabled = false;
                newBox.GetComponent<SpriteRenderer>().color = Color.black;
            }
            
            newBox.SetActive(true);

            return newBox;
        }

        private GameObject GetObjectFromPool(GameObject prefab)
        {
            BoxController box = _boxPool.Find(b => !b.gameObject.activeSelf);

            if (box == null)
            {
                box = Instantiate(prefab).GetComponent<BoxController>();
                _boxPool.Add(box);
            }

            return box.gameObject;
        }
    }
}