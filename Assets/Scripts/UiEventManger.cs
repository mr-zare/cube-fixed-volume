using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MatchMasters.Managers.UI
{
    public class UIEventManager: MonoBehaviour
    {


        
        private bool _isButtonCallbackDeActive;
        private bool _isLoadingActive;
        private Action _backActions;
        public void Initialize()
        {
        }
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape) || _isLoadingActive) return;
            _backActions?.Invoke();
        }

        public void SetButtonListener(Button button, Action callback,
            bool hasDeActiveDelay = true, float delay = 0.5f)
        {
            if (button == null) return;

            button.onClick.AddListener(() =>
            {
                if (_isButtonCallbackDeActive) return;
                StartCoroutine(ButtonCallback(button, callback, hasDeActiveDelay, delay));
            });
        }

        private IEnumerator ButtonCallback(Button button, Action callback, bool hasDeActiveDelay, float delay)
        {
            callback?.Invoke();
            if (!hasDeActiveDelay) yield break;
            _isButtonCallbackDeActive = true;
            button.interactable = false;
            yield return new WaitForSeconds(delay);
            _isButtonCallbackDeActive = false;
            if (button != null)
            {
                button.interactable = true;
            }
        }
        
        public void SetBackAction(Action action)
        {
            _backActions = action;
        }

        public void ResetBackAction()
        {
            _backActions = null;
        }
    }
}