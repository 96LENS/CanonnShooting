using UnityEngine;

/// <summary>
/// Transform�N���X�̊g��
/// </summary>
public static class TransformExtension
{
    //=====================================================================================================================
    // Public�֐�
    //=====================================================================================================================

    /// <summary>
    /// �q��Transform��ێ�����S�Ă�GameObject���������
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
