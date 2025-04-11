using UnityEngine;
using UnityEditor;

public class LevelIdAssigner 
{
    [MenuItem("Tools/Assign Level IDs")]

    public static void AssignIDs()
    {
        string[] guids = AssetDatabase.FindAssets("Level t:LevelConfig");
        int currentId = 1;

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
