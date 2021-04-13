using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoleMovement : MonoBehaviour
{
    [Header("Hole mesh")]
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshCollider MeshCollider;

    [Header("Hole vertices radius")]
    [SerializeField] Vector2 moveLimits;
    [SerializeField] float radius;
    [SerializeField] Transform holeCenter;
    [SerializeField] Transform rotatingCircle;

    Mesh mesh;
    List<int> holeVertices;
    List<Vector3> offsets;
    //int holeVerticesCount;

    [Space]
    [SerializeField] float moveSpeed;

    float x, y;
    Vector3 touch, targetPos;

    // Start is called before the first frame update
    void Start()
    {
        RotateCircleAnim();
        Game.isMoving = false;
        Game.isGameOver = false;

        holeVertices = new List<int>();
        offsets = new List<Vector3>();
        mesh = meshFilter.mesh;        
        FindHoleVertices();
    }

    void RotateCircleAnim()
    {
        rotatingCircle.DORotate(new Vector3(90, 0, -90), 0.2f).SetEase(Ease.Linear).From(new Vector3(90, 0, 0)).SetLoops(-1, LoopType.Incremental);
    }
 

    // Update is called once per frame
    void Update()
    {
        Game.isMoving = Input.GetMouseButton(0);

        if (!Game.isGameOver && Game.isMoving)
        {
            MoveHole();
            UpdateHoleVerticesPosition();
        }
    }

    private void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touch = Vector3.Lerp(holeCenter.position,
            holeCenter.position + new Vector3(x, 0, y),
            moveSpeed * Time.deltaTime
        );
        targetPos  = new Vector3(Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x), touch.y, Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y));
        holeCenter.position = targetPos;
    }

    private void UpdateHoleVerticesPosition()
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < holeVertices.Count; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }
        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        MeshCollider.sharedMesh = mesh;
    }

    private void FindHoleVertices()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);
            if (distance < radius)
            {
                holeVertices.Add(i);
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }

}
