﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.Video;

public static class SerializePropertyExtension
{
    public static void SetObjectValue(SerializedProperty prop, System.Object toValue)
    {
        switch (prop.propertyType)
        {
            case SerializedPropertyType.Boolean:
                prop.boolValue = (bool)toValue;
                break;
            case SerializedPropertyType.Bounds:
                prop.boundsValue = (Bounds)toValue;
                break;
            case SerializedPropertyType.Color:
                prop.colorValue = (Color)toValue;
                break;
            case SerializedPropertyType.Float:
                prop.floatValue = (float)toValue;
                break;
            case SerializedPropertyType.Integer:
                prop.intValue = (int)toValue;
                break;
            case SerializedPropertyType.ObjectReference:
                prop.objectReferenceValue = toValue as UnityEngine.Object;
                break;
            case SerializedPropertyType.Rect:
                prop.rectValue = (Rect)toValue;
                break;
            case SerializedPropertyType.String:
                prop.stringValue = (string)toValue;
                break;
            case SerializedPropertyType.Vector2:
                prop.vector2Value = (Vector2)toValue;
                break;
            case SerializedPropertyType.Vector3:
                prop.vector3Value = (Vector3)toValue;
                break;
        }
    }
}

[CustomEditor(typeof(LevelManager))]
[CanEditMultipleObjects]
public class LevelManagerEditor : Editor {

    //Objects
    LevelManager levelManager;
    UIManager UIManager;
    SerializedObject m_Target;
    Scene m_Scene;

    //Main toolbar button names
    public string[] mainToolbarNames = new string[] { "Creation", "Settings" }; 
    //Level Creation button names
    public string[] toolbarButtonNames = new string[] { "Create New Scene", "Add Scene", "Add to Build Settings" };
    //Difficulty button names
    public string[] difficultyButtonNames = new string[] {"Easy", "Normal", "Hard", "Genius"};

    //Allows you to show LevelManager Script properties
    public bool showInheritedVars = false;

    //GUI Settings
    Color defBackgroundColor;
    GUISkin defGUISkin;
   // GUIStyle defGUIStyle;
    float labelWidth;
    float fieldWidth;
    //Level Creation Toolbar
    GUISkin toolBarSkin;
    GUIStyle tabStyle;
    //Level Editing Toolbar
    GUISkin mainToolbarSkin;
    GUIStyle mainStyle;
    //Difficulty Toolbar
   // GUISkin diffToolbarSkin;// = new GUISkin[5];
    GUIStyle diffStyle = null;

    //Saved Preferences for Creation
    private SerializedProperty sceneNameCapture;
    private SerializedProperty sceneAssetCapture;
    private SerializedProperty containerSizeCapture;
    List<string> buildSettingSceneNames;

    //Saved Preferences for Settings

    
    private SerializedProperty level1Capture;
    private SerializedProperty level1A;
    private SerializedProperty level1B;
    private SerializedProperty level1C;
    private SerializedProperty level1D;
    private SerializedProperty level1E;


    private SerializedProperty[] level1Name = new SerializedProperty[5];
   
    private SerializedProperty[] level1Icon = new SerializedProperty[5];
    private SerializedProperty[] level1VideoTexture = new SerializedProperty[5];
    private SerializedProperty[] level1VideoFile = new SerializedProperty[5];
    private SerializedProperty[] level1Intro = new SerializedProperty[5];
    private SerializedProperty[] level1Outro = new SerializedProperty[5];
    private SerializedProperty level1Description2;
    private List<SerializedProperty> levelDescriptionCapture = new List<SerializedProperty>();
    private List<SerializedProperty> levelVideoCapture = new List<SerializedProperty>();

    private SerializedProperty level2Capture;
    private SerializedProperty level2A;
    private SerializedProperty level2B;
    private SerializedProperty level2C;
    private SerializedProperty level2D;
    private SerializedProperty level2E;
    private SerializedProperty level2F;


    private SerializedProperty[] level2Name = new SerializedProperty[6];

    private SerializedProperty[] level2Icon = new SerializedProperty[6];
    private SerializedProperty[] level2VideoTexture = new SerializedProperty[6];
    private SerializedProperty[] level2VideoFile = new SerializedProperty[6];
    private SerializedProperty[] level2Intro = new SerializedProperty[6];
    private SerializedProperty[] level2Outro = new SerializedProperty[6];
    private SerializedProperty level2Description2;
    private List<SerializedProperty> levelDescriptionCapture2 = new List<SerializedProperty>();
    private List<SerializedProperty> levelVideoCapture2 = new List<SerializedProperty>();

    //GUILayouts
    Texture2D headerTexture;
    Texture2D levelBoxTexture;
    Texture2D levelSettingsTexture;



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

        //Retrieve custom GUISkin for Toolbar for Level Creation
        //diffToolbarSkin = defGUISkin;    
        //diffStyle = defGUIStyle;
        //Captures saved variable in LevelManager by the name of sceneName 
        sceneNameCapture = m_Target.FindProperty("sceneName");
        this.sceneAssetCapture = this.m_Target.FindProperty("sceneAssets");
        containerSizeCapture = m_Target.FindProperty("containerSize");

        buildSettingSceneNames = new List<string>();

        //Settings for Level1
        level1A = m_Target.FindProperty("level1A");
        level1B = m_Target.FindProperty("level1B");
        level1C = m_Target.FindProperty("level1C");
        level1D = m_Target.FindProperty("level1D");
        level1E = m_Target.FindProperty("level1E");

        level2A = m_Target.FindProperty("level2A");
        level2B = m_Target.FindProperty("level2B");
        level2C = m_Target.FindProperty("level2C");
        level2D = m_Target.FindProperty("level2D");
        level2E = m_Target.FindProperty("level2E");
        level2F = m_Target.FindProperty("level2F");

        for (int i = 0; i < 5; i++)
        {
            
            switch (i)
            {
                case 0:
                    level1Capture = level1A;
                    break;
                case 1:
                    level1Capture = level1B;
                    break;
                case 2:
                    level1Capture = level1C;
                    break;
                case 3:
                    level1Capture = level1D;
                    break;
                case 4:
                    level1Capture = level1E;
                    break;
            }
            
            level1Name[i] = AssignRelativeProperty(level1Capture, "levelName");
            level1Intro[i] = AssignRelativeProperty(level1Capture, "levelIntro");
            level1Outro[i] = AssignRelativeProperty(level1Capture, "levelOutro");
            level1Icon[i] = AssignRelativeProperty(level1Capture, "levelIcon");
            level1VideoTexture[i] = AssignRelativeProperty(level1Capture, "videoTexture");

            level1VideoFile[i] = AssignRelativeProperty(level1Capture, "videoFile");

            level1Description2 = AssignRelativeProperty(level1Capture, "level");
            levelDescriptionCapture.Add(AssignRelativeProperty(level1Description2.GetArrayElementAtIndex(i), "levelDescription"));
            levelVideoCapture.Add(AssignRelativeProperty(level1Description2.GetArrayElementAtIndex(i), "videoFile"));

        }

        for (int j = 0; j < 6; j++)
        {

            switch (j)
            {
                case 0:
                    level2Capture = level2A;
                    break;
                case 1:
                    level2Capture = level2B;
                    break;
                case 2:
                    level2Capture = level2C;
                    break;
                case 3:
                    level2Capture = level2D;
                    break;
                case 4:
                    level2Capture = level2E;
                    break;
                case 5:
                    level2Capture = level2F;
                    break;
            }

            level2Name[j] = AssignRelativeProperty(level2Capture, "levelName");
            level2Intro[j] = AssignRelativeProperty(level2Capture, "levelIntro");
            level2Outro[j] = AssignRelativeProperty(level2Capture, "levelOutro");
            level2Icon[j] = AssignRelativeProperty(level2Capture, "levelIcon");
            level2VideoTexture[j] = AssignRelativeProperty(level2Capture, "videoTexture");

            level2VideoFile[j] = AssignRelativeProperty(level2Capture, "videoFile");

            level2Description2 = AssignRelativeProperty(level2Capture, "level2");
            levelDescriptionCapture2.Add(AssignRelativeProperty(level2Description2.GetArrayElementAtIndex(j), "levelDescription2"));
            levelVideoCapture2.Add(AssignRelativeProperty(level2Description2.GetArrayElementAtIndex(j), "videoFile"));

        }

        InitTextures();
    }

    void ChangeTheColor(Texture2D texture, Color c, int width, int height)
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                texture.SetPixel(x, y, c);
        texture.Apply();
    }

    void InitTextures()
    {
        headerTexture = new Texture2D(Screen.width, 75);
        levelBoxTexture = new Texture2D(Screen.width+200, Screen.height+600);
        levelSettingsTexture = new Texture2D(Screen.width+150, Screen.height + 920);
        ChangeTheColor(levelSettingsTexture, CustomColors.salmon, Screen.width+150, Screen.height + 920);
        ChangeTheColor(levelBoxTexture, CustomColors.medium_aqua_marine, Screen.width+200, Screen.height+600);
        ChangeTheColor(headerTexture, Color.red, Screen.width, 75);
    }


    public override void OnInspectorGUI()
    {

        m_Target.Update();
      //  m_Target.ApplyModifiedProperties();
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
        EditorGUILayout.LabelField("Level Selected: " + UIManager.mode.ToString());
        EditorGUILayout.LabelField("Level to Beat: " + levelManager.m_LevelToBeat.ToString());
        EditorGUILayout.LabelField("Difficulty to Beat: " + levelManager.levelCaptureEditor.m_DifficultyToBeat.ToString());
        EditorGUILayout.LabelField("Difficulty Selected: " + levelManager.m_Difficulty.ToString());

        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        GUI.skin = mainToolbarSkin;
        EditorGUILayout.Space();
        levelManager.mainTBCurrentTab = GUILayout.Toolbar(levelManager.mainTBCurrentTab, mainToolbarNames, mainStyle);  

        switch(levelManager.mainTBCurrentTab)
        {
            case 0:
                ShowCreation();
              //  levelManager.currentTab = 0;
                break;
            case 1:
                ShowSettings();
                levelManager.currentTab = 3;//Set Default state so help box doesn't show up
                break;
        }

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

            default:
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

        if (EditorApplication.isPlaying)
        {
            EditorUtility.SetDirty(target);
            Repaint();
        }

       


    }

    // Get child property of parent serializedProperty
    SerializedProperty AssignRelativeProperty(SerializedProperty serializedProperty, string propertyName)
    {
        if (serializedProperty.FindPropertyRelative(propertyName) == null)
        {
            Debug.LogError("No child property found by name. Please make sure child property is created or is spelled correctly as it is case sensitive.");
            return null;
        }
        else
        {
            SerializedProperty property = serializedProperty.FindPropertyRelative(propertyName);
            return property;
        }     
    }

    #region Settings

    public void ShowCreation()
    {
        EditorGUILayout.Space();
        GUI.skin = toolBarSkin;
        EditorGUILayout.Space();

        levelManager.currentTab = GUILayout.Toolbar(levelManager.currentTab, toolbarButtonNames, tabStyle);

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }

    public void ShowSettings()
    {
        GUI.skin = defGUISkin;
        Heading(MessageType.Info, "Change the settings of each level here that appear in the level overview. Select a level and edit away.", Color.cyan, true);

        for (int i = 0; i < 5; i++)
        {
            string levelName = "";
            switch (i)
            {
                case 0:
                    levelName = "Level 1A";
                    levelManager.level1Capture = levelManager.level1A;
                    break;
                case 1:
                    levelName = "Level 1B";
                    levelManager.level1Capture = levelManager.level1B;
                    break;
                case 2:
                    levelName = "Level 1C";
                    levelManager.level1Capture = levelManager.level1C;
                    break;
                case 3:
                    levelName = "Level 1D";
                 //   levelManager.level1Capture = levelManager.level1D;
                    break;
                case 4:
                    levelName = "Level 1E";
                   // levelManager.level1Capture = levelManager.level1E;
                    break;
            }

            EditorGUILayout.LabelField(levelName, Label(EditorStyles.largeLabel, CustomColors.teal, 12, FontStyle.Bold));
            levelManager.diffCurrentTab = GUILayout.Toolbar(levelManager.diffCurrentTab, difficultyButtonNames, diffStyle);

            GUILayout.BeginHorizontal(levelBoxTexture, "Box");//-------------------------------------------------------------2
            EditorGUILayout.BeginVertical();//-------------------------------------------------------------3
            EditorGUILayout.LabelField("Level Icon", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold), GUILayout.Width(75));
            level1Icon[i].objectReferenceValue = (Sprite)EditorGUILayout.ObjectField(level1Icon[i].objectReferenceValue, typeof(Sprite), false, GUILayout.Width(100), GUILayout.Height(100));
            EditorGUILayout.LabelField("Highscore", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold), GUILayout.Width(75));
            for (int j = 0; j < 4; j++)
            {
                switch (j)
                {
                    case 0:
                        EditorGUILayout.LabelField("Easy: " + levelManager.level1Capture.highScore[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                    case 1:
                        EditorGUILayout.LabelField("Normal: " + levelManager.level1Capture.highScore[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                    case 2:
                        EditorGUILayout.LabelField("Hard: " + levelManager.level1Capture.highScore[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                    case 3:
                        EditorGUILayout.LabelField("Genius: " + levelManager.level1Capture.highScore[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                }

                
            }
            EditorGUILayout.EndVertical();//-------------------------------------------------------------3

            EditorGUILayout.Space();
            GUILayout.BeginVertical(levelSettingsTexture, GUIStyle.none);//-------------------------------------------------------------4
            EditorGUILayout.LabelField("Level Name", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level1Name[i].stringValue = GUILayout.TextField(level1Name[i].stringValue, GUILayout.Width(200), GUILayout.Height(15));

            EditorGUILayout.LabelField(levelName + " Story", Label(EditorStyles.label, CustomColors.dark_slate_gray, 13, FontStyle.BoldAndItalic));

            EditorGUILayout.LabelField("Intro", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level1Intro[i].stringValue = GUILayout.TextArea(level1Intro[i].stringValue, GUILayout.Width(300), GUILayout.Height(50));

            EditorGUILayout.LabelField("Outro", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level1Outro[i].stringValue = GUILayout.TextArea(level1Outro[i].stringValue, GUILayout.Width(300), GUILayout.Height(50));

            EditorGUILayout.LabelField("Level Description", Label(EditorStyles.label, CustomColors.dark_slate_gray, 13, FontStyle.BoldAndItalic));
            for (int mode = 0; mode < 4; mode++)
            {
                switch (mode)
                {
                    case 0:
                        EditorGUILayout.LabelField("Easy", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                    case 1:
                        EditorGUILayout.LabelField("Normal", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                    case 2:
                        EditorGUILayout.LabelField("Hard", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                    case 3:
                        EditorGUILayout.LabelField("Genius", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                }
                levelDescriptionCapture[i].GetArrayElementAtIndex(mode).stringValue = EditorGUILayout.TextArea(levelDescriptionCapture[i].GetArrayElementAtIndex(mode).stringValue, GUILayout.Width(300), GUILayout.Height(50));

                EditorGUILayout.LabelField("Video File", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                levelVideoCapture[i].GetArrayElementAtIndex(mode).objectReferenceValue = (VideoClip)EditorGUILayout.ObjectField(levelVideoCapture[i].GetArrayElementAtIndex(mode).objectReferenceValue, typeof(VideoClip), false, GUILayout.Width(200), GUILayout.Height(15));
            }

            EditorGUILayout.LabelField("Video Texture", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level1VideoTexture[i].objectReferenceValue = (Texture)EditorGUILayout.ObjectField(level1VideoTexture[i].objectReferenceValue, typeof(Texture), false, GUILayout.Width(200), GUILayout.Height(15));

            EditorGUILayout.EndVertical();//-------------------------------------------------------------4
            EditorGUILayout.EndHorizontal();//-------------------------------------------------------------2

        }

        for (int i = 0; i < 6; i++)
        {
            string levelName = "";
            switch (i)
            {
                case 0:
                    levelName = "Level 2A";
                    levelManager.level2Capture = levelManager.level2A;
                    break;
                case 1:
                    levelName = "Level 2B";
                    levelManager.level2Capture = levelManager.level2B;
                    break;
                case 2:
                    levelName = "Level 2C";
                   // levelManager.level2Capture = levelManager.level2C;
                    break;
                case 3:
                    levelName = "Level 2D";
                    //levelManager.level2Capture = levelManager.level2D;
                    break;
                case 4:
                    levelName = "Level 2E";
                   // levelManager.level2Capture = levelManager.level2E;
                    break;
                case 5:
                    levelName = "Level 2F";
                 //   levelManager.level2Capture = levelManager.level2F;
                    break;
            }

            EditorGUILayout.LabelField(levelName, Label(EditorStyles.largeLabel, CustomColors.teal, 12, FontStyle.Bold));
            levelManager.diffCurrentTab = GUILayout.Toolbar(levelManager.diffCurrentTab, difficultyButtonNames, diffStyle);

            GUILayout.BeginHorizontal(levelBoxTexture, "Box");//-------------------------------------------------------------2
            EditorGUILayout.BeginVertical();//-------------------------------------------------------------3
            EditorGUILayout.LabelField("Level Icon", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold), GUILayout.Width(75));
            level2Icon[i].objectReferenceValue = (Sprite)EditorGUILayout.ObjectField(level2Icon[i].objectReferenceValue, typeof(Sprite), false, GUILayout.Width(100), GUILayout.Height(100));
            EditorGUILayout.LabelField("Highscore", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold), GUILayout.Width(75));
         /*   for (int j = 0; j < 4; j++)
            {
                switch (j)
                {
                    case 0:
                        EditorGUILayout.LabelField("Easy: " + levelManager.level2Capture.highScore2[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                    case 1:
                        EditorGUILayout.LabelField("Normal: " + levelManager.level2Capture.highScore2[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                    case 2:
                        EditorGUILayout.LabelField("Hard: " + levelManager.level2Capture.highScore2[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                    case 3:
                        EditorGUILayout.LabelField("Genius: " + levelManager.level2Capture.highScore2[i, j], Label(EditorStyles.radioButton, Color.black, 10, FontStyle.Bold), GUILayout.Width(90));
                        break;
                }


            }*/
            EditorGUILayout.EndVertical();//-------------------------------------------------------------3

            EditorGUILayout.Space();
            GUILayout.BeginVertical(levelSettingsTexture, GUIStyle.none);//-------------------------------------------------------------4
            EditorGUILayout.LabelField("Level Name", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level2Name[i].stringValue = GUILayout.TextField(level2Name[i].stringValue, GUILayout.Width(200), GUILayout.Height(15));

            EditorGUILayout.LabelField(levelName + " Story", Label(EditorStyles.label, CustomColors.dark_slate_gray, 13, FontStyle.BoldAndItalic));

            EditorGUILayout.LabelField("Intro", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level2Intro[i].stringValue = GUILayout.TextArea(level2Intro[i].stringValue, GUILayout.Width(300), GUILayout.Height(50));

            EditorGUILayout.LabelField("Outro", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level2Outro[i].stringValue = GUILayout.TextArea(level2Outro[i].stringValue, GUILayout.Width(300), GUILayout.Height(50));

            EditorGUILayout.LabelField("Level Description", Label(EditorStyles.label, CustomColors.dark_slate_gray, 13, FontStyle.BoldAndItalic));
            for (int mode = 0; mode < 4; mode++)
            {
                switch (mode)
                {
                    case 0:
                        EditorGUILayout.LabelField("Easy", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                    case 1:
                        EditorGUILayout.LabelField("Normal", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                    case 2:
                        EditorGUILayout.LabelField("Hard", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                    case 3:
                        EditorGUILayout.LabelField("Genius", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                        break;
                }
                levelDescriptionCapture2[i].GetArrayElementAtIndex(mode).stringValue = EditorGUILayout.TextArea(levelDescriptionCapture2[i].GetArrayElementAtIndex(mode).stringValue, GUILayout.Width(300), GUILayout.Height(50));

                EditorGUILayout.LabelField("Video File", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
                levelVideoCapture2[i].GetArrayElementAtIndex(mode).objectReferenceValue = (VideoClip)EditorGUILayout.ObjectField(levelVideoCapture2[i].GetArrayElementAtIndex(mode).objectReferenceValue, typeof(VideoClip), false, GUILayout.Width(200), GUILayout.Height(15));
            }

            EditorGUILayout.LabelField("Video Texture", Label(EditorStyles.miniLabel, Color.black, 10, FontStyle.Bold));
            level2VideoTexture[i].objectReferenceValue = (Texture)EditorGUILayout.ObjectField(level2VideoTexture[i].objectReferenceValue, typeof(Texture), false, GUILayout.Width(200), GUILayout.Height(15));

            EditorGUILayout.EndVertical();//-------------------------------------------------------------4
            EditorGUILayout.EndHorizontal();//-------------------------------------------------------------2

        }
    }

    #endregion

    #region Creation
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
    #endregion


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

    GUIStyle Label(GUIStyle labelType, Color _color, int _size, FontStyle fontStyle, Font Font)
    {
        GUIStyle txt = new GUIStyle(labelType);
        txt.normal.textColor = _color;
        txt.fontSize = _size;
        txt.fontStyle = fontStyle;
        txt.font = Font;
        return txt;
    }

    GUIStyle DrawTextInEditor(GUIStyle labelType, string _text, Color _color, int _size)
    {
        int fontSizeOld = EditorStyles.label.fontSize;
        EditorStyles.boldLabel.fontSize = _size;

        GUI.color = _color;
        GUIStyle style = new GUIStyle(labelType);
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = _color;
        style.richText = true;

        EditorGUILayout.LabelField(_text, style);

        //  EditorGUILayout.HelpBox(_heading, MessageType.None);
        GUI.color = Color.white;
        EditorStyles.boldLabel.fontSize = fontSizeOld;

        return style;
    }


    public class CustomColors
    {
        public static Color RED = new Color(0.6f, 0, 0);
        public static Color GREEN = new Color(0, 0.5f, 0);
        public static Color DARKGREEN = new Color(0, 0.2f, 0);
        public static Color BLUE = new Color(0, 0, 0.6f);
        public static Color GREY = new Color(0.6f, 0.6f, 0.6f);
        public static Color DARKGREY = new Color(0.2f, 0.2f, 0.2f);
        public static Color CYAN = new Color(0, 0.3f, 0.8f);
        public static Color PURPLE = new Color(0.5f, 0.1f, 0.5f);
        public static Color MAGENTA = new Color(0.8f, 0.1f, 0.8f);
        public static Color WHITE = new Color(1f, 1f, 1f);

        public static Color LightRED = new Color(1, 0.419f, 0.419f, 1f);
        public static Color LightBLUE = new Color(0.529f, 0.807f, 0.98f, 1f);
        public static Color LightBLUE_SKY = new Color(0, 0.749f, 1f, 1f);// (0,191,255)
        public static Color LightMAGENTA = new Color(0.8f, 0.01f, 0.8f, 1f);
        public static Color LightYELLOW = new Color(1f, 0.92f, 0.016f, 1f);
        public static Color LightGREEN = new Color(0.59f, 0.96f, 0.59f, 1f);
        public static Color DarkGREEN = new Color(0.0f, 0.5f, 0.0f, 1f);
        public static Color LightPURPLE = new Color(0.576f, 0.439f, 0.858f, 1f); //(147,112,219)

        public static Color BROWN = new Color(0.803f, 0.439f, 0.521f, 1f); //(205,133,63)
        public static Color LightGOLD = new Color(0.933f, 0.909f, 0.666f, 1f); //(238,232,170)//
        public static Color PINK = new Color(1f, 0.411f, 0.705f, 1f);//	(255,105,180)


        /// *********************************************************************
        /// To see the colors, this is the site  
        /// https://www.rapidtables.com/web/color/RGB_Color.html


        // full color spectrum
        public static Color maroon = new Color(128f / 255f, 0, 0);
        public static Color darkred = new Color(139f / 255f, 0, 0);
        public static Color brown = new Color(165f / 255f, 42f / 255f, 42);
        public static Color firebrick = new Color(178f / 255f, 34f / 255f, 34f / 255f);
        public static Color crimson = new Color(220f / 255f, 20f / 255f, 60f / 255f);
        public static Color red = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        public static Color tomato = new Color(255f / 255f, 99f / 255f, 71f / 255f);
        public static Color coral = new Color(255f / 255f, 127f / 255f, 80f / 255f);
        public static Color indian_red = new Color(20f / 255f, 92f / 255f, 92f / 255f);
        public static Color light_coral = new Color(240f / 255f, 128f / 255f, 128f / 255f);
        public static Color dark_salmon = new Color(233f / 255f, 150f / 255f, 122f / 255f);
        public static Color salmon = new Color(250f / 255f, 128f / 255f, 114f / 255f);
        public static Color light_salmon = new Color(255f / 255f, 160f / 255f, 122f / 255f);
        public static Color orange_red = new Color(255f / 255f, 69f / 255f, 0f / 255f);
        public static Color dark_orange = new Color(255f / 255f, 140f / 255f, 0f / 255f);
        public static Color orange = new Color(255f / 255f, 165f / 255f, 0f / 255f);
        public static Color gold = new Color(255f / 255f, 215f / 255f, 0f);
        public static Color dark_golden_rod = new Color(184f / 255f, 134f / 255f, 11f / 255f);
        public static Color golden_rod = new Color(218f / 255f, 165f / 255f, 32f / 255f);
        public static Color pale_golden_rod = new Color(238f / 255f, 232f / 255f, 170f / 255f);
        public static Color dark_khaki = new Color(189f / 255f, 183f / 255f, 107f / 255f);
        public static Color khaki = new Color(240f / 255f, 230f / 255f, 140f / 255f);
        public static Color olive = new Color(128f / 255f, 12f / 2558f, 0f);
        public static Color yellow = new Color(255f / 255f, 255f / 255f, 0f);
        public static Color yellow_green = new Color(154f / 255f, 205f / 255f, 50f);
        public static Color dark_olive_green = new Color(85f / 255f, 107f / 255f, 47f / 255f);
        public static Color olive_drab = new Color(107f / 255f, 142f / 255f, 35f / 255f);
        public static Color lawn_green = new Color(124f / 255f, 252f / 255f, 0f / 255f);
        public static Color chart_reuse = new Color(127f / 255f, 255f / 255f, 0f / 255f);
        public static Color green_yellow = new Color(173f / 255f, 255f / 255f, 47f / 255f);
        public static Color dark_green = new Color(0, 100f / 255f, 0f);
        public static Color green = new Color(0f, 128f / 255f, 0f);
        public static Color forest_green = new Color(34f / 255f, 139f / 255f, 34f / 255f);
        public static Color lime = new Color(0f / 255f, 255f / 255f, 0f);
        public static Color lime_green = new Color(50f / 255f, 205f / 255f, 50f / 255f);
        public static Color light_green = new Color(144f / 255f, 238f / 255f, 144f / 255f);
        public static Color pale_green = new Color(152f / 255f, 251f / 255f, 152f / 255f);
        public static Color dark_sea_green = new Color(143f / 255f, 188f / 255f, 143f / 255f);
        public static Color medium_spring_green = new Color(0f, 250f / 255f, 154f / 255f);
        public static Color spring_green = new Color(0f, 255f / 255f, 127f / 255f);
        public static Color sea_green = new Color(46f / 255f, 139f / 255f, 87f / 255f);
        public static Color medium_aqua_marine = new Color(102f / 255f, 205f / 255f, 170f / 255f);
        public static Color medium_sea_green = new Color(60f / 255f, 179f / 255f, 113f / 255f);
        public static Color light_sea_green = new Color(32f / 255f, 178f / 255f, 170f / 255f);
        public static Color dark_slate_gray = new Color(47f / 255f, 79f / 255f, 79f / 255f);
        public static Color teal = new Color(0f, 128f / 255f, 128f / 255f);
        public static Color dark_cyan = new Color(0, 139f / 255f, 139f / 255f);
        public static Color aqua = new Color(0f, 255f / 255f, 255f / 255f);
        public static Color cyan = new Color(0f, 255f / 255f, 255f / 255f);
        public static Color light_cyan = new Color(224f / 255f, 255f / 255f, 255f / 255f);
        public static Color dark_turquoise = new Color(0f, 206f / 255f, 209f / 255f);
        public static Color turquoise = new Color(64f / 255f, 224f / 255f, 208f / 255f);
        public static Color medium_turquoise = new Color(72f / 255f, 209f / 255f, 204f / 255f);
        public static Color pale_turquoise = new Color(175f / 255f, 238f / 255f, 238f / 255f);
        public static Color aqua_marine = new Color(127f / 255f, 255f / 255f, 212f / 255f);
        public static Color powder_blue = new Color(176f / 255f, 224f / 255f, 230f / 255f);
        public static Color cadet_blue = new Color(95f / 255f, 158f / 255f, 160f / 255f);
        public static Color steel_blue = new Color(70f / 255f, 130f / 255f, 180f / 255f);
        public static Color corn_flower_blue = new Color(100f / 255f, 149f / 255f, 237f / 255f);
        public static Color deep_sky_blue = new Color(0, 191f / 255f, 255f / 255f);
        public static Color dodger_blue = new Color(30f / 255f, 144f / 255f, 1f);
        public static Color light_blue = new Color(173f / 255f, 216f / 255f, 230f / 255f);
        public static Color sky_blue = new Color(135f / 255f, 206f / 255f, 235f / 255f);
        public static Color light_sky_blue = new Color(135f / 255f, 206f / 255f, 250f / 255f);
        public static Color midnight_blue = new Color(25f / 255f, 25f / 255f, 112f / 255f);
        public static Color navy = new Color(0f, 0f, 128f / 255f);
        public static Color dark_blue = new Color(0f, 0f, 139f / 255f);
        public static Color medium_blue = new Color(0f, 0f, 205f / 255f);
        public static Color blue = new Color(0f, 0f, 1f);
        public static Color royal_blue = new Color(65f / 255f, 105f / 255f, 1f);
        public static Color blue_violet = new Color(138f / 255f, 43f / 255f, 226f / 255f);
        public static Color indigo = new Color(75f / 255f, 0f, 130f / 255f);
        public static Color dark_slate_blue = new Color(72f / 255f, 61f / 255f, 139f / 255f);
        public static Color slate_blue = new Color(106f / 255f, 90f / 255f, 205f / 255f);
        public static Color medium_slate_blue = new Color(123f / 255f, 104f / 255f, 238f / 255f);
        public static Color medium_purple = new Color(147 / 255f, 112f / 255f, 219f / 255f);
        public static Color dark_magenta = new Color(139f / 255f, 0f, 139f / 255f);
        public static Color dark_violet = new Color(148f / 255f, 0f, 211f / 255f);
        public static Color dark_orchid = new Color(153f, 50f, 204f);
        public static Color medium_orchid = new Color(186f / 255f, 85f / 255f, 211f / 255f);
        public static Color purple = new Color(128f / 255f, 0f, 128f / 255f);
        public static Color thistle = new Color(216f / 255f, 191f / 255f, 216f / 255f);
        public static Color plum = new Color(221f / 255f, 160f / 255f, 221f / 255f);
        public static Color violet = new Color(238f / 255f, 130f / 255f, 238f / 255f);
        public static Color fuchsia = new Color(255f / 255f, 0f / 255f, 255f / 255f);
        public static Color orchid = new Color(218f / 255f, 112f / 255f, 214f / 255f);
        public static Color medium_violet_red = new Color(199f / 255f, 21f / 255f, 133f / 255f);
        public static Color pale_violet_red = new Color(219f / 255f, 112f / 255f, 147f / 255f);
        public static Color deep_pink = new Color(255f / 255f, 20f / 255f, 147f / 255f);
        public static Color hot_pink = new Color(255f / 255f, 105f / 255f, 180f / 255f);
        public static Color light_pink = new Color(255f / 255f, 182f / 255f, 193f / 255f);
        public static Color pink = new Color(255f / 255f, 192f / 255f, 203f / 255f);
        public static Color antique_white = new Color(250f / 255f, 235f / 255f, 215f / 255f);
        public static Color beige = new Color(245f / 255f, 245f / 255f, 220f / 255f);
        public static Color bisque = new Color(255f / 255f, 228f / 255f, 196f / 255f);
        public static Color blanched_almond = new Color(255f, 235f, 205f);
        public static Color wheat = new Color(245f / 255f, 222f / 255f, 179f / 255f);
        public static Color corn_silk = new Color(255f / 255f, 248f / 255f, 220f / 255f);
        public static Color lemon_chiffon = new Color(255f / 255f, 250f / 255f, 205f / 255f);
        public static Color light_golden_rod_yellow = new Color(250f / 255f, 250f / 255f, 210f / 255f);
        public static Color light_yellow = new Color(255f / 255f, 255f / 255f, 224f / 255f);
        public static Color saddle_brown = new Color(139f / 255f, 69f / 255f, 19f / 255f);
        public static Color sienna = new Color(160 / 255f, 82f / 255f, 45f / 255f);
        public static Color chocolate = new Color(210f / 255f, 105f / 255f, 30f / 255f);
        public static Color peru = new Color(205f / 255f, 133f / 255f, 63f / 255f);
        public static Color sandy_brown = new Color(244f / 255f, 164f / 255f, 96f / 255f);
        public static Color burly_wood = new Color(222f / 255f, 184f / 255f, 135f / 255f);
        public static Color tan = new Color(210f / 255f, 180f / 255f, 140f / 255f);
        public static Color rosy_brown = new Color(188f / 255f, 143f / 255f, 143f / 255f);
        public static Color moccasin = new Color(255f / 255f, 228f / 255f, 181f / 255f);
        public static Color navajo_white = new Color(255f / 255f, 222f / 255f, 173f / 255f);
        public static Color peach_puff = new Color(255f / 255f, 218f / 255f, 185f / 255f);
        public static Color misty_rose = new Color(255f / 255f, 228f / 255f, 225f / 255f);
        public static Color lavender_blush = new Color(255f / 255f, 240f / 255f, 245f / 255f);
        public static Color linen = new Color(250f / 255f, 240f / 255f, 230f / 255f);
        public static Color old_lace = new Color(253f / 255f, 245f / 255f, 230f / 255f);
        public static Color papaya_whip = new Color(255f / 255f, 239f / 255f, 213f / 255f);
        public static Color sea_shell = new Color(255f / 255f, 245f / 255f, 238f / 255f);
        public static Color mint_cream = new Color(245f / 255f, 255f / 255f, 250f / 255f);
        public static Color slate_gray = new Color(112f / 255f, 128f / 255f, 144f / 255f);
        public static Color light_slate_gray = new Color(119f / 255f, 136f / 255f, 153f / 255f);
        public static Color light_steel_lue = new Color(176f / 255f, 196f / 255f, 222f / 255f);
        public static Color lavender = new Color(230f / 255f, 230f / 255f, 250f / 255f);
        public static Color floral_white = new Color(255f / 255f, 250f / 255f, 240f / 255f);
        public static Color alice_blue = new Color(240f / 255f, 248f / 255f, 255f / 255f);
        public static Color ghost_white = new Color(248f / 255f, 248f / 255f, 255f / 255f);
        public static Color honeydew = new Color(240f / 255f, 255f / 255f, 240f / 255f);
        public static Color ivory = new Color(255f / 255f, 255f / 255f, 240f / 255f);
        public static Color azure = new Color(240f / 255f, 255f / 255f, 255f / 255f);
        public static Color snow = new Color(255f / 255f, 250f / 255f, 250f / 255f);
        public static Color black = new Color(0, 0, 0);
        public static Color dim_gray = new Color(105f / 255f, 105f / 255f, 105f / 255f, 1f);
        public static Color gray = new Color(128f / 255f, 128f / 255f, 128f / 255f);
        public static Color dark_grey = new Color(169f / 255f, 169f / 255f, 169f / 255f);
        public static Color silver = new Color(192f / 255f, 192f / 255f, 192f / 255f);
        public static Color ight_grey = new Color(211f / 255f, 211f / 255f, 211f / 255f);
        public static Color gainsboro = new Color(220f / 255f, 220f / 255f, 220f / 255f);
        public static Color white_smoke = new Color(245f / 255f, 245f / 255f, 245f / 255f);
        public static Color white = new Color(255f / 255f, 255f / 255f, 255f / 255f);



    }
    #endregion
}
