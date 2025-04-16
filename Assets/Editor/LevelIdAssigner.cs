using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class AutoLevelIdAssigner
{
    private static int currentId = 1;
    static AutoLevelIdAssigner()
    {
        // Automatically called when Unity loads the editor or recompiles scripts
        AssignIDs();
    }

    public static void AssignIDs()
    {
        string[] guids = AssetDatabase.FindAssets("Level t:LevelConfig");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            LevelConfig config = AssetDatabase.LoadAssetAtPath<LevelConfig>(path);
            if (config != null && !config.idAssigned)
            {
                config.SetId(currentId);
                EditorUtility.SetDirty(config);
                currentId++;
            }
        }

        AssetDatabase.SaveAssets();
        Debug.Log("Assigned level IDs to all unassigned LevelConfigs.");
    }
}
