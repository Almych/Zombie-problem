using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class AutoLevelIdAssigner
{
    private static int currentId = 1;

    static AutoLevelIdAssigner()
    {
        AssignIDs();
    }

    public static void AssignIDs()
    {
        string[] guids = AssetDatabase.FindAssets("t:LevelConfig");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            LevelConfig config = AssetDatabase.LoadAssetAtPath<LevelConfig>(path);

            if (config != null)
            {
                config.SetId(currentId, true);
                Debug.Log($"{config.name} is level id {config.LevelId}");
                EditorUtility.SetDirty(config);
                currentId++;
            }
        }

        AssetDatabase.SaveAssets();
        Debug.Log("Assigned level IDs.");
    }
}
