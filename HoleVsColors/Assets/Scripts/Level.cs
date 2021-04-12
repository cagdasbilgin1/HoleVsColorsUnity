using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Space]
    [Header("Level Objects & Obstacles")]
    [SerializeField] Material groundMaterial;
    [SerializeField] Material objectMaterial;
    [SerializeField] Material obstacleMaterial;
    [SerializeField] SpriteRenderer groundBorderSprite;
    [SerializeField] SpriteRenderer groundSideSprite;
    [SerializeField] Image progressFillImage;

    [SerializeField] SpriteRenderer bgFadeSprite;

    [Space]
    [Header("Level Colors")]
    [Header("Ground")]
    [SerializeField] Color groundColor;
    [SerializeField] Color bordersColor;
    [SerializeField] Color sideColor;
    [Header("Objects & Obstacles")]
    [SerializeField] Color objectColor;
    [SerializeField] Color obstacleColor;
    [Header("UI (progress)")]
    [SerializeField] Color progressFillColor;

    [Header("Background")]
    [SerializeField] Color cameraColor;
    [SerializeField] Color fadeColor;

    void Start()
    {
        CountObjects();
        UpdateLevelColors();
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

    void UpdateLevelColors()
    {
        groundMaterial.color = groundColor;
        groundSideSprite.color = sideColor;
        groundBorderSprite.color = bordersColor;

        obstacleMaterial.color = obstacleColor;
        objectMaterial.color = objectColor;

        progressFillImage.color = progressFillColor;

        Camera.main.backgroundColor = cameraColor;
        bgFadeSprite.color = fadeColor;

    }

    private void OnValidate()
    {
        UpdateLevelColors();
    }
}
