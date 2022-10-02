using UnityEngine;

/// <summary>
/// Transformクラスの拡張
/// </summary>
public static class TransformExtension
{
    //=====================================================================================================================
    // Public関数
    //=====================================================================================================================

    /// <summary>
    /// 子にTransformを保持する全てのGameObjectを放棄する
    /// </summary>
    /// <param name="self"></param>
    public static void DestroyChildren(this Transform self)
    {
        Transform[] children = self.GetComponentsInChildren<Transform>();
        
        foreach(Transform child in children)
        {
            Object.Destroy(child);
        }

        children = null;
    }
}
