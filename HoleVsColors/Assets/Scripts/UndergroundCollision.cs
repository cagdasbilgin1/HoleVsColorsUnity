using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Object"))
        {
            Debug.Log("object");
        }
        if (other.tag.Equals("Obstacle"))
        {
            Debug.Log("obstacle");

        }
    }
}
