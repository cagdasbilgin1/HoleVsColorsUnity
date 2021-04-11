using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Singleton class: Level
    
    public static Level instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    public int objectInScene;
    public int totalObjects;
    // Start is called before the first frame update

    [SerializeField] Transform objectsParent;

    void Start()
    {
        CountObjects();
    }

    // Update is called once per frame
    void CountObjects()
    {
        totalObjects = objectsParent.childCount;
        objectInScene = totalObjects;
    }
}
