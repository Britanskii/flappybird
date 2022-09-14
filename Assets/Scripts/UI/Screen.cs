using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] protected Button Button;
        
        protected abstract void OnButtonClick();
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnButtonClick);
        }
        
        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnButtonClick);
        }

        

    }
}