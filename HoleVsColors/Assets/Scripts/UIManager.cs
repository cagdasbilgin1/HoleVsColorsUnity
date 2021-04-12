using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

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

    [Space]
    [SerializeField] TMP_Text levelCompletedText;

    [Space]
    [SerializeField] Image fadePanel;

    // Start is called before the first frame update
    void Start()
    {
        FadeAtStart();
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
        //progressFillImage.fillAmount = val;
        progressFillImage.DOFillAmount(val, 0.4f);
    }

    public void ShowLevelCompletedUI()
    {
        levelCompletedText.DOFade(1, 0.6f).From(0);
    }

    public void FadeAtStart()
    {
        fadePanel.DOFade(0, 1.3f).From(1);
    }
}
