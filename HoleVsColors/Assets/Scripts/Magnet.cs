using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(SphereCollider))]
public class Magnet : MonoBehaviour
{
    #region Singleton class: Magnet

    public static Magnet instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] float magnetForce;
    List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
    Transform magnet;

    // Start is called before the first frame update
    void Start()
    {
        magnet = transform;
        affectedRigidbodies.Clear();

    }

    private void FixedUpdate()
    {
        if(!Game.isGameOver && Game.isMoving)
        {
            foreach(Rigidbody rb in affectedRigidbodies)
            {
                rb.AddForce((magnet.position - rb.position)*magnetForce*Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameOver && (other.tag.Equals("Obstacle") || other.tag.Equals("Object")))
        {
            AddToMagnetField(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!Game.isGameOver && (other.tag.Equals("Obstacle") || other.tag.Equals("Object")))
        {
            RemoveFromMagnetField(other.attachedRigidbody);
        }
    }

    public void AddToMagnetField(Rigidbody rb)
    {
        affectedRigidbodies.Add(rb);
    }
    public void RemoveFromMagnetField(Rigidbody rb)
    {
        affectedRigidbodies.Remove(rb);
    }
}
