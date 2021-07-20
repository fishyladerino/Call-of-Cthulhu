using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomTrees : MonoBehaviour
{
    #region Components
    Transform treeTransform;
    #endregion

    #region Rotation
    public float minRotation, maxRotation;
    float rotationY;
    Quaternion rotation;
    #endregion

    #region Scale
    public float minScaleXZ, maxScaleXZ, minScaleY, maxScaleY;
    float scaleXZ, scaleY;
    Vector3 scale;
    #endregion

    void Start()
    {
        treeTransform = GetComponent<Transform>();
        rotationY = UnityEngine.Random.Range(minRotation, maxRotation);
        scaleXZ = UnityEngine.Random.Range(minScaleXZ, maxScaleXZ);
        scaleY = UnityEngine.Random.Range(minScaleY, maxScaleY);
        treeTransform.rotation = new Quaternion(0, rotationY, 0f, 0f);
        treeTransform.localScale = new Vector3(scaleXZ * 100f, scaleY * 100f, scaleXZ * 100f);
    }
}
