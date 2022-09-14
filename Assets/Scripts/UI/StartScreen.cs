using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.UI
{
    public class StartScreen : Screen
    {
        public event UnityAction PlayButtonClick;
        protected override void OnButtonClick()
        {
            PlayButtonClick?.Invoke();
        }
    }
}