using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] ParticleSystem winFx;

    [Space]
    [HideInInspector] public int objectInScene;
    [HideInInspector] public int totalObjects;
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

    public void PlayWinFx()
    {
        winFx.Play();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
