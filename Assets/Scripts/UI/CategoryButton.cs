using System;
using Managers;
using UnityEngine;

namespace UI
{
    public class CategoryButton : MonoBehaviour
    {
        public QuizCategory Category;
        public void OnClick()
        {
            GameManager.Current.SelectCategory(Category);
        }
    }
}
