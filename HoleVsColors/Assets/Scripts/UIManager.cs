using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    #region Singleton class: UIManager

    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    

    [Header("Level Progress UI")]
    [SerializeField] int sceneOffset;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] Image progressFillImage;

    // Start is called before the first frame update
    void Start()
    {
        SetLevelProgressText();
        progressFillImage.fillAmount = 0;
    }

    void SetLevelProgressText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }

    // Update is called once per frame
    public void UpdateLevelProgress()
    {
        float val = 1 - ((float)Level.instance.objectInScene / Level.instance.totalObjects);
        progressFillImage.fillAmount = val;
    }
}
