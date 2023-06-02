using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    private MoveController _moveController;

    private void Start() => _moveController = GetComponent<MoveController>();

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.distance < 1.2f)
            {
                _moveController.IsAbleToForward = false;
            }
            else
            {
                _moveController.IsAbleToForward = true;
            }
            Debug.DrawRay(transform.position+Vector3.up*1.5f, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
