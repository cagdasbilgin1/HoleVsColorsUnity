using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            }
            if (other.tag.Equals("Obstacle"))
            {
                Game.isGameOver = true;
            }
        }        
    }
}
