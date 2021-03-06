﻿using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

class EndNameEdit : EndNameEditAction {
    public override void Action (int instanceId, string pathName, string resourceFile) {
        AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(instanceId), AssetDatabase.GenerateUniqueAssetPath(pathName));
    }
}

public class CreateScriptableObject : EditorWindow {
    static List<Type> FindTypes() {
        var asm = Assembly.Load(new AssemblyName("Assembly-CSharp"));
        var types = new List<Type>();
        foreach (Type t in asm.GetTypes())
            if (t.IsSubclassOf(typeof(ScriptableObject)) && !t.IsAbstract)
                types.Add(t);
        
        return types;
    }
    
    void OnGUI() {
        GUILayout.Label("Select the type to create:");
        foreach (Type t in FindTypes()) {
            if (GUILayout.Button(t.FullName)) {
                var asset = ScriptableObject.CreateInstance(t);
                ProjectWindowUtil.StartNameEditingIfProjectWindowExists(asset.GetInstanceID(), ScriptableObject.CreateInstance<EndNameEdit>(), t.FullName + ".asset", AssetPreview.GetMiniThumbnail(asset), null);
                Close();
            }
        }
    }

    [MenuItem("FastFramework/Create/ScriptableObject")]
    public static void ShowWindow() {
        var win = EditorWindow.GetWindow<CreateScriptableObject>(true, "Create ScriptableObject");
        win.ShowPopup();
    }
}