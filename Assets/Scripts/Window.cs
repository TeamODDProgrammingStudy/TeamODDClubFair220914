using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]private Animator _windowAnimator;

    public virtual void Open()
    {
        _windowAnimator.SetTrigger("Open");
    }

    public virtual void Close()
    {
        _windowAnimator.SetTrigger("Close");
    }
}