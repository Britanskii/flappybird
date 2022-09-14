using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        private Camera _camera;

        private List<GameObject> _pool = new List<GameObject>();

        public void ResetPool()
        {
            foreach (var item in _pool)
            {
                item.SetActive(false);
            }
        }

        protected void Initialize(GameObject prefab)
        {
            _camera = Camera.main;

            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
                spawned.SetActive(false);
                
                _pool.Add(spawned);
            }
        }

        protected void DisableObjectAboardScreen()
        {
            Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

            foreach (var item in _pool)
            {
                if (item.activeSelf)
                {
                    if (item.transform.position.x < disablePoint.x)
                    {
                        item.SetActive(false);
                    }
                }
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(gameObject => gameObject.activeSelf == false);

            return result != null;
        }
    }
}