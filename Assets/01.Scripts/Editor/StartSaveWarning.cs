using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class StartSaveWarning : Editor
{
    [InitializeOnLoadMethod]
    static void StartSave()
    {
        EditorApplication.playModeStateChanged += SaveWarning;
    }

    static void SaveWarning(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode && EditorSceneManager.GetActiveScene().isDirty)
        {
            if (EditorUtility.DisplayDialog("Save Warning", "Do you want to save the scene?", "Yes", "No"))
            {
                EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
            }
        }
    }
}
