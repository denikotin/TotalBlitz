using System;
using UnityEngine;

public class CharacterRaycast : MonoBehaviour
{
    public bool IsWallForward {  get; private set; }
    public bool IsWallRight { get; private set; }
    public bool IsWallLeft { get; private set; }

    private void Update()
    {
        RaycastHit forwardHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forwardHit, Mathf.Infinity))
        {
            if (forwardHit.distance < 1.2f)
            {
                IsWallForward = true;
            }
            else
            {
                IsWallForward = false;
            }
            Debug.DrawRay(transform.position+Vector3.up*1.5f, transform.TransformDirection(Vector3.forward) * forwardHit.distance, Color.yellow);
        }

        RaycastHit rightHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit, Mathf.Infinity)) 
        {
            if (rightHit.distance < 1.5f)
            {
                IsWallRight = true;
            }
            else
            {
                IsWallRight = false;
            }
            Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(Vector3.right) * rightHit.distance, Color.yellow);
        }

        RaycastHit leftHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out leftHit, Mathf.Infinity))
        {
            if (leftHit.distance < 1.5)
            {
                IsWallLeft = true;
            }
            else
            {
                IsWallLeft = false;
            }
            Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-Vector3.right) * leftHit.distance, Color.yellow);
        }

    }
}
