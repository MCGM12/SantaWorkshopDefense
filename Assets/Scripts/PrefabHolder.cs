using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHolder : MonoBehaviour
{
    public GameObject runnerPrefab, gumPrefab, monsterPrefab;

    private void Start()
    {
        runnerPrefab = GameObject.Find("Basic Runner");
    }
}
