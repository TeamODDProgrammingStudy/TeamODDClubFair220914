using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(QuizGenerator))]
    public class QuizGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var generator = target as QuizGenerator;
            if (GUILayout.Button("Generate"))
            {
                generator.Generate();
            }
        }
    }
}