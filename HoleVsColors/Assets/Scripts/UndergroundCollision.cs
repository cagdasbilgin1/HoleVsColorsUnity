using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (!Game.isGameOver)
        {
            if (other.tag.Equals("Object"))
            {
                Level.instance.objectInScene--;
                UIManager.instance.UpdateLevelProgress();
                Destroy(other.gameObject);

                if(Level.instance.objectInScene == 0)
                {
                    UIManager.instance.ShowLevelCompletedUI();
                    Level.instance.PlayWinFx();
                    Invoke("NextLevel", 2);
                }
            }
            if (other.tag.Equals("Obstacle"))
            {
                Game.isGameOver = true;
                Camera.main.transform.DOShakePosition(1, 0.2f, 20, 90).OnComplete(() => { Level.instance.RestartLevel(); });
            }
        }        
    }

    void NextLevel()
    {
        Level.instance.LoadNextLevel();
    }
}
