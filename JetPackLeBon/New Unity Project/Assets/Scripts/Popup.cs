using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class Popup : PopupWindowContent
    {
        bool toggle1 = true;
        bool toggle2 = true;
        bool toggle3 = true;

        public override Vector2 GetWindowSize()
        {
            return new Vector2(400, 300);
        }

        public override void OnGUI(Rect rect)
        {
        rect = new Rect(Screen.width * 2, Screen.height / 2, 100, 100);
        editorWindow.position = rect;
        rect = new Rect(100f, 100f, 200f, 200f);
            //GUILayout.Label("Popup Options Example", EditorStyles.boldLabel);
            EditorGUILayout.LabelField(Donnees.AfficherDistanceParcourueDurantLaPartie());
            toggle2 = EditorGUILayout.Toggle("Toggle 2", toggle2);
            toggle3 = EditorGUILayout.Toggle("Toggle 3", toggle3);
        }

        public override void OnOpen()
        {
            Debug.Log("Popup opened: " + this);
        }

        public override void OnClose()
        {
        SceneManager.LoadScene("MainMenu");
        }
    }
