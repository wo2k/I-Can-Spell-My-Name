using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SoundManagement))]
[CanEditMultipleObjects]
public class SoundManagementEditor : Editor {

  //  SoundManagement soundManager;
    SerializedObject m_Target;

    private SerializedProperty musicClipCapture;
   // private SerializedProperty sfxClipCapture;

    Color defBackgroundColor;

    private void OnEnable()
    {
      //  soundManager = (SoundManagement)target;
        m_Target = new SerializedObject(target);

        musicClipCapture = m_Target.FindProperty("musicName");
      //  sfxClipCapture = m_Target.FindProperty("sfxName");
    }

    public override void OnInspectorGUI()
    {
        m_Target.Update();
        defBackgroundColor = GUI.color;
     //   if (musicClipCapture.stringValue == null && sfxClipCapture.stringValue == null)
            Heading(MessageType.Error, "Capturing of Music and Auido playback in Scene will occur duing gameplay.", Color.yellow, true);
       // else
         //   Heading(MessageType.Info, "Capturing Audio playback", Color.cyan, true);

        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.BeginHorizontal("Box");
        EditorGUILayout.LabelField("Music Clip: " + musicClipCapture.stringValue);
        EditorGUILayout.EndHorizontal();

       // EditorGUILayout.BeginHorizontal("Box");
       // EditorGUILayout.LabelField("Audio Clip: " + sfxClipCapture.stringValue);
        //EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();

        GUI.color = defBackgroundColor;
        EditorGUILayout.Space();
        DrawDefaultInspector();
        m_Target.ApplyModifiedProperties();
    }

    void Heading(MessageType type, string _heading, Color _color, bool _AddSpaces = false)
    {

        if (_AddSpaces) EditorGUILayout.Space();
        GUI.color = _color;
        EditorGUILayout.HelpBox(_heading, type);
        GUI.color = defBackgroundColor;
        if (_AddSpaces) EditorGUILayout.Space();
    }

    GUIStyle Label(GUIStyle labelType, Color _color, int _size, FontStyle fontStyle)
    {
        GUIStyle txt = new GUIStyle(labelType);
        txt.normal.textColor = _color;
        txt.fontSize = _size;
        txt.fontStyle = fontStyle;
        return txt;
    }
}
