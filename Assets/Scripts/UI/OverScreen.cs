using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.UI
{
    public class OverScreen : Screen
    {
        public event UnityAction RestartButtonClick;

        protected override void OnButtonClick()
        {
            RestartButtonClick?.Invoke();
        }
    }
}