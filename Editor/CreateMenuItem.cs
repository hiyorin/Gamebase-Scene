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
            if (!Copy("Application"))
                throw new Exception();
        }
        
        [MenuItem("Assets/Create/Gamebase-Scene/Scene", false, 1)]
        public static void CreateScene()
        {
            if (!Copy("Scene"))
                throw new Exception();
        }

        private static bool Copy(string fileName)
        {
            var selectObject = Selection.objects.FirstOrDefault();
            var newPath = selectObject != null ? AssetDatabase.GetAssetPath(selectObject) : Application.dataPath;
            if (!AssetDatabase.CopyAsset($"{TemplatePath}/{fileName}.unity", $"{newPath}/{fileName}.unity"))
                return false;
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return true;
        }
    }
}