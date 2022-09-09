using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField]private Animator _windowAnimator;
        [SerializeField] private UnityEvent _onWindowOpen;
        [SerializeField] private UnityEvent _onWindowClose;

        public virtual void Open()
        {
            _windowAnimator.SetTrigger("Open");
            _onWindowOpen.Invoke();
        }

        public virtual void Close()
        {
            _windowAnimator.SetTrigger("Close");
            _onWindowClose.Invoke();
        }
    }
}