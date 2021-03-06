﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldText : MonoBehaviour
{
    // Create Text in the world
  public static TextMesh CreateWorldText (string text, Color color, Transform parent = null,  Vector3 localPosition = default, int fontSize = 40,
        TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
    {
        GameObject gameObject = new GameObject("world_Text",typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
       textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder=sortingOrder;
        return textMesh;

    }
    
}