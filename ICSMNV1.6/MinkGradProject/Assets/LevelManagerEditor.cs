using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(LevelManager))]
[CanEditMultipleObjects]
public class LevelManagerEditor : Editor {

    LevelManager levelManager;
    Scene m_Scene;
    Scene currScene;

    public string sceneName;
    public int showSceneCreation;

    public bool showInheritedVars = false;
    Color defBackgroundColor;
    float labelWidth;
    float fieldWidth;

    List<SceneAsset> sceneAssets = new List<SceneAsset>(); 

    void OnEnable()
    {
        currScene = SceneManager.GetActiveScene();
    }

    public override void OnInspectorGUI()
    {
       // base.OnInspectorGUI();
        levelManager = (LevelManager)target;
        defBackgroundColor = GUI.backgroundColor;
        labelWidth = EditorGUIUtility.labelWidth;
        fieldWidth = EditorGUIUtility.fieldWidth;

       

        for (int i = 0; i < sceneAssets.Count; i++)
            sceneAssets[i] = (SceneAsset)EditorGUILayout.ObjectField(sceneAssets[i], typeof(SceneAsset), false);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical();
        if(showSceneCreation == 1) GUI.color = Color.green; else GUI.color = defBackgroundColor;
        if (GUILayout.Button("Create New Scene"))
        {
            if (showSceneCreation == 1)
                showSceneCreation = 0;
            else
                showSceneCreation = 1;
        }
        GUI.color = defBackgroundColor;

        if (showSceneCreation == 1)
            MakeScene();
        EditorGUILayout.EndVertical();

        if (GUILayout.Button("Add Scene"))
        {
            sceneAssets.Add(null);
        }

        if(GUILayout.Button("Add to Build Settings"))
        {
            AddScenesToEditorBuild();
        }
        EditorGUILayout.EndHorizontal();
        EditorGUIUtility.labelWidth = labelWidth;
        EditorGUIUtility.fieldWidth = fieldWidth;
        showInheritedVars = EditorGUILayout.Toggle("Show Full Script", showInheritedVars);
        GUI.color = defBackgroundColor;
        if (showInheritedVars)
            DrawDefaultInspector();

        serializedObject.Update();
    }

    public void AddScenesToEditorBuild()
    {
        List<EditorBuildSettingsScene> m_Scenes = new List<EditorBuildSettingsScene>();

        foreach(var m_Scene in sceneAssets)
        {
            string pathName = AssetDatabase.GetAssetPath(m_Scene);
            if (!string.IsNullOrEmpty(pathName))
                m_Scenes.Add(new EditorBuildSettingsScene(pathName, true));
        }

        EditorBuildSettings.scenes = m_Scenes.ToArray();
    }

    public void MakeScene()
    {
       sceneName = EditorGUILayout.TextField("Type Scene Name Here: ", sceneName);

        if (GUILayout.Button("Create"))
        {
            m_Scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Additive);
            string pathName = "Assets/Levels/" + m_Scene + ".unity";
            EditorSceneManager.SaveScene(m_Scene, pathName, true);
            AssetDatabase.RenameAsset(pathName, sceneName);
            
            EditorSceneManager.CloseScene(m_Scene, true);
            EditorSceneManager.OpenScene("Assets/Levels/" + sceneName + ".unity", OpenSceneMode.Additive);
        }
    }
}
