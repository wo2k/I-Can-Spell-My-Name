using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(LevelManager))]
[CanEditMultipleObjects]
public class LevelManagerEditor : Editor {

    //Objects
    LevelManager levelManager;
    UIManager UIManager;
    SerializedObject m_Target;
    Scene m_Scene;

    //Main toolbar button names
    public string[] mainToolbarNames = new string[] { "Level Creation", "Level Editing" }; 
    //Level Creation button names
    public string[] toolbarButtonNames = new string[] { "Create New Scene", "Add Scene", "Add to Build Settings" };

    //Allows you to show LevelManager Script properties
    public bool showInheritedVars = false;

    //GUI Settings
    Color defBackgroundColor;
    GUISkin defGUISkin;
    GUIStyle defGUIStyle;
    float labelWidth;
    float fieldWidth;
    //Level Creation Toolbar
    GUISkin toolBarSkin;
    GUIStyle tabStyle;
    //Level Editing Toolbar
    GUISkin mainToolbarSkin;
    GUIStyle mainStyle;

    //Saved Preferences
    private SerializedProperty sceneNameCapture;
    private SerializedProperty sceneAssetCapture;
    private SerializedProperty containerSizeCapture;
    List<string> buildSettingSceneNames;

    void OnEnable()
    {
        levelManager = (LevelManager)target;
        UIManager = FindObjectOfType<UIManager>();
        m_Target = new SerializedObject(target);

        //Retrieve custom GUISkin for main toolbar
        mainToolbarSkin = Resources.Load("GUISkin/MainToolbar") as GUISkin;
        mainStyle = mainToolbarSkin.GetStyle("Tab");

        //Retrieve custom GUISkin for Toolbar for Level Creation
        toolBarSkin = Resources.Load("GUISkin/Toolbar") as GUISkin;
        tabStyle = toolBarSkin.GetStyle("Tab");

        //Captures saved variable in LevelManager by the name of sceneName 
        sceneNameCapture = m_Target.FindProperty("sceneName");
        this.sceneAssetCapture = this.m_Target.FindProperty("sceneAssets");
        containerSizeCapture = m_Target.FindProperty("containerSize");

        buildSettingSceneNames = new List<string>();
    }

    public override void OnInspectorGUI()
    {

        m_Target.Update();
        SerializedProperty sceneCaptureCopy = sceneAssetCapture.Copy();
        
        //Set Inspector background and parimeters to public variables
        defBackgroundColor = GUI.backgroundColor;
        defGUISkin = GUI.skin;
        labelWidth = EditorGUIUtility.labelWidth;
        fieldWidth = EditorGUIUtility.fieldWidth;

        Heading(MessageType.Warning, "Will not show proper Statistics running till game is being played", Color.yellow, true);

        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField("Game Statistics", Label(GUI.skin.textField, Color.black, 12, FontStyle.Bold));
        EditorGUILayout.LabelField("Console: " + levelManager.m_Console.ToString());
        EditorGUILayout.LabelField("Level Type: " + levelManager.m_Mode.ToString());
        EditorGUILayout.LabelField("Level Playing: " + UIManager.mode.ToString());

        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        GUI.skin = toolBarSkin;
           
        EditorGUILayout.Space();

        levelManager.currentTab = GUILayout.Toolbar(levelManager.currentTab, toolbarButtonNames, tabStyle);
      
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();      

        switch (levelManager.currentTab)
        {
            case 0://Create New Scene button
                MakeScene();              
                break;

            case 1://Add Scene button
                EditSceneContainer();

                for (int i = 0; i < sceneCaptureCopy.arraySize; i++)
                {
                   EditorGUILayout.ObjectField(sceneCaptureCopy.GetArrayElementAtIndex(i));
                }
                break;

            case 2://Add to Build Settings button
                CaptureBuildContainer();
                AddScenesToEditorBuild();
                break;
        }

        GUI.skin = defGUISkin;
        EditorGUIUtility.labelWidth = labelWidth;
        EditorGUIUtility.fieldWidth = fieldWidth;
        showInheritedVars = EditorGUILayout.Toggle("Show Full Script", showInheritedVars);
        GUI.color = defBackgroundColor;
        if (showInheritedVars)
            DrawDefaultInspector();

        m_Target.ApplyModifiedProperties();

    }

    public void AddScenesToEditorBuild()
    {
        if (GUILayout.Button("Generate Scenes to Build"))
        {
            List<EditorBuildSettingsScene> m_Scenes = new List<EditorBuildSettingsScene>();
            SerializedProperty sceneCaptureCopy = sceneAssetCapture.Copy();

            for (int i = 0; i < sceneCaptureCopy.arraySize; i++)
            {
                string pathName = AssetDatabase.GetAssetPath(sceneCaptureCopy.GetArrayElementAtIndex(i).objectReferenceValue);
                if (!string.IsNullOrEmpty(pathName))
                    m_Scenes.Add(new EditorBuildSettingsScene(pathName, true));
            }

            EditorBuildSettings.scenes = m_Scenes.ToArray();
        }
    }

    public void MakeScene()
    {
        Heading(MessageType.Info, "Create your scene here. First type the name of the scene you want it to be called. Then hit Create and go to Add Scene.", Color.cyan, true);
        sceneNameCapture.stringValue = EditorGUILayout.TextField("Type Scene Name Here: ", sceneNameCapture.stringValue);

        if (GUILayout.Button("Create"))
        {
            m_Scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Additive);
            string pathName = "Assets/Levels/" + m_Scene + ".unity";
            EditorSceneManager.SaveScene(m_Scene, pathName, true);
            AssetDatabase.RenameAsset(pathName, levelManager.sceneName);
            
            EditorSceneManager.CloseScene(m_Scene, true);
            EditorSceneManager.OpenScene("Assets/Levels/" + sceneNameCapture.stringValue + ".unity", OpenSceneMode.Additive);
        }
    }

    public void EditSceneContainer()
    {
        Heading(MessageType.Info, "Container Size of scenes in Build Settings.", Color.cyan, true);

        EditorGUILayout.BeginHorizontal("box");
        containerSizeCapture.intValue = EditorGUILayout.IntField("Size of Container", containerSizeCapture.intValue);
        SerializedProperty sceneCaptureCopy = sceneAssetCapture.Copy();

        if (GUILayout.Button("+1"))
        {
            containerSizeCapture.intValue += 1;
            sceneCaptureCopy.InsertArrayElementAtIndex(containerSizeCapture.intValue-1);
        }

        if (GUILayout.Button("-1"))
        {
            if (sceneAssetCapture.arraySize > 0)
            {
                containerSizeCapture.intValue -= 1;
                sceneCaptureCopy.DeleteArrayElementAtIndex(containerSizeCapture.intValue);
            }
        }

        if (GUILayout.Button("Clear"))
        {
            containerSizeCapture.intValue = 0;
            sceneCaptureCopy.ClearArray();
        }
        EditorGUILayout.EndHorizontal();
    }

    public void CaptureBuildContainer()
    {
        Heading(MessageType.Info, "Shows all scenes in build settings. If no scenes are visible, please add scenes then generate.", Color.cyan , true);
        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                buildSettingSceneNames.Add(scene.path);
        }
        for (int i = 0; i < EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes).Length; i++)
        {
            EditorGUILayout.BeginHorizontal("Box");
            EditorGUILayout.LabelField(buildSettingSceneNames.ToArray()[i].ToString());         
            EditorGUILayout.EndHorizontal();
        }
    }


    #region Custom GUI Settings
    bool TitleBar(bool fold)
    {
        fold = EditorGUILayout.InspectorTitlebar(fold, Selection.activeObject);
        return fold;
    }

    void Heading(MessageType type, string _heading, Color _color, bool _AddSpaces = false)
    {

        if (_AddSpaces) EditorGUILayout.Space();
        GUI.color = _color;
        EditorGUILayout.HelpBox(_heading, type);
        GUI.color = defBackgroundColor;
        if (_AddSpaces) EditorGUILayout.Space();
    }

    void Heading2(MessageType type, string _heading, Color _color, Color txtColor, bool _AddSpaces = false)
    {
        GUIStyle txt = new GUIStyle();
        txt.normal.textColor = txtColor;
        if (_AddSpaces) EditorGUILayout.Space();
        GUI.color = _color;
        EditorGUILayout.HelpBox(_heading, type);
        GUI.color = defBackgroundColor;
        if (_AddSpaces) EditorGUILayout.Space();
    }

    void CustomHelpBox(string txt, Color txtColor, int size, FontStyle fontStyle, Color boxColor)
    {
        GUI.color = boxColor;
        GUIStyle style = GUI.skin.GetStyle("HelpBox");
        style.richText = true;
        style.normal.textColor = txtColor;
        style.fontSize = size;
        style.fontStyle = fontStyle;
        EditorGUILayout.TextArea(txt, style);
        GUI.color = defBackgroundColor;
    }
    void CustomHelpBox(string txt, Color txtColor, int size, FontStyle fontStyle, Color boxColor, TextAnchor align)
    {
        GUI.color = boxColor;
        GUIStyle style = GUI.skin.GetStyle("HelpBox");
        style.alignment = align;
        style.richText = true;
        style.normal.textColor = txtColor;
        style.fontSize = size;
        style.fontStyle = fontStyle;
        EditorGUILayout.TextArea(txt, style);
        GUI.color = defBackgroundColor;
    }

    GUIStyle Label(GUIStyle labelType, Color _color, int _size)
    {
        GUIStyle txt = new GUIStyle(labelType);
        txt.normal.textColor = _color;
        txt.fontSize = _size;
        return txt;
    }

    GUIStyle Label(GUIStyle labelType, Color _color, int _size, FontStyle fontStyle)
    {
        GUIStyle txt = new GUIStyle(labelType);
        txt.normal.textColor = _color;
        txt.fontSize = _size;
        txt.fontStyle = fontStyle;
        return txt;
    }
    #endregion
}
