﻿using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Crogen.ObjectPooling.Editor
{
    [CustomEditor(typeof(PoolManager))]
    public class PoolEditor : UnityEditor.Editor
    {
        private PoolManager _poolManager;
    
        private void OnEnable()
        {
            _poolManager = target as PoolManager;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.Label("PoolBase");
            GUILayout.BeginHorizontal();

            _poolManager.poolBase = EditorGUILayout.ObjectField(_poolManager.poolBase, typeof(PoolBase), false) as PoolBase;
            
            if (GUILayout.Button("New"))
            {
                var poolBase = ScriptableObject.CreateInstance<PoolBase>();

                CreatePoolBaseAsset(poolBase);
            }

            if (_poolManager.poolBase != null)
            {
                if (GUILayout.Button("Clone"))
                {
                    var poolBase = Instantiate(_poolManager.poolBase);
                    CreatePoolBaseAsset(poolBase);
                }
            }
        
            GUILayout.EndHorizontal();

            GUILayout.Space(20);

            //PoolBase Serialize
            if (_poolManager.poolBase != null)
            {
                _poolManager.poolingPairs = _poolManager.poolBase.pairs;
                var poolBaseArrayObject = serializedObject.FindProperty("poolingPairs");
                EditorGUILayout.PropertyField(poolBaseArrayObject, true);
                serializedObject.ApplyModifiedProperties();
                _poolManager.poolBase.pairs = _poolManager.poolingPairs;
                _poolManager.poolBase.PairInit();

                serializedObject.Update();
            }

            if (GUILayout.Button("Generate Enum"))
            {
                GeneratePoolingEnumFile();
                Debug.Log("Success!");
            }
        }

        
        private void GeneratePoolingEnumFile()
        {
            StringBuilder codeBuilder = new StringBuilder();
        
            foreach(var item in _poolManager.poolBase.pairs)
            {
                codeBuilder.Append(item.poolType);
                codeBuilder.Append(", ");
            }

            string code = string.Format(CodeFormat.PoolingTypeFormat, codeBuilder.ToString());

            string path = $"{Application.dataPath}/Crogen/ObjectPooling";

            File.WriteAllText($"{path}/PoolType.cs", code);

            EditorUtility.SetDirty(_poolManager.poolBase);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        
        private void CreatePoolBaseAsset(PoolBase clonePoolBase)
        {
            var uniqueFileName = AssetDatabase.GenerateUniqueAssetPath($"Assets/New Pool Base.asset");
            AssetDatabase.CreateAsset(clonePoolBase, uniqueFileName);
            _poolManager.poolBase = clonePoolBase;
            EditorUtility.SetDirty(_poolManager.poolBase);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}

