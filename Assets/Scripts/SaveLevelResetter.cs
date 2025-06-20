#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
public static class LevelSaveResetter
{
    [MenuItem("Tools/Clear Level Progress")]
    public static void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Level progress cleared.");
    }
}
#endif
