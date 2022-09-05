using System;
using UnityEngine;

namespace UI
{
    public class CategoryButton : MonoBehaviour
    {
    
        public QuizCategory Category;
        [SerializeField]private Window Parent;
        public void OnClick()
        {
            Parent.Close();
            GameManager.Current.StartGame(Category);
        }

        public void OnValidate()
        {
            try
            {
                Parent = transform.parent.transform.parent.transform.parent.GetComponentInChildren<Window>();
            }
            catch (Exception e)
            {
                // ignored
                //
            }
        }
    }
}
