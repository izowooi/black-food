using UnityEditor;
using UnityEngine;

public class TestMenu
{
#if UNITY_EDITOR
    [MenuItem("Tools/Run Test Menu Item")]
    public static void RunHelloWorld()
    {
        Debug.Log("hello world");
    }
#endif        
}