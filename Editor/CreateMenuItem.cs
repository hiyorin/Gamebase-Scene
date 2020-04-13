using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Gamebase.Scene.Editor
{
    public static class CreateMenuItem
    {
        private const string TemplatePath = "Packages/com.gamebase.scene/Editor/Templates";
        
        [MenuItem("Assets/Create/Gamebase-Scene/Application", false, 0)]
        public static void CreateApplication()
        {
            if (!Copy("Application", "Application"))
                throw new Exception();
        }
        
        [MenuItem("Assets/Create/Gamebase-Scene/Scene", false, 1)]
        public static void CreateScene()
        {
            if (!Copy("Scene", "Scene"))
                throw new Exception();
        }

        #if GAMEBASE_ADD_NODECANVAS
        
        [MenuItem("Assets/Create/Gamebase-Scene/Application (NodeCanvas)", false, 10)]
        public static void CreateApplicationNodeCanvas()
        {
            if (!Copy("ApplicationNodeCanvas", "Application"))
                throw new Exception();
        }

        [MenuItem("Assets/Create/Gamebase-Scene/Scene (NodeCanvas)", false, 11)]
        public static void CreateSceneNodeCanvas()
        {
            if (!Copy("SceneNodeCanvas", "Scene"))
                throw new Exception();
        }
        
        #endif
        
        private static bool Copy(string fileName, string newFileName)
        {
            var selectObject = Selection.objects.FirstOrDefault();
            var newPath = selectObject != null ? AssetDatabase.GetAssetPath(selectObject) : Application.dataPath;
            if (!AssetDatabase.CopyAsset($"{TemplatePath}/{fileName}.unity", $"{newPath}/{newFileName}.unity"))
                return false;
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return true;
        }
    }
}