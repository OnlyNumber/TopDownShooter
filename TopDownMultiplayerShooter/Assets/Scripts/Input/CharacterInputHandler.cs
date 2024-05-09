using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector3 viewDirection = Vector2.zero;

    public Camera camera;

    private void Update()
    {
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        viewDirection = GetDirection();
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.movementInput = moveInputVector;

        networkInputData.rotationInput = viewDirection;

        return networkInputData;
    }

    private Vector3 GetDirection()
    {
        Ray r = camera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(r, out RaycastHit info);

        Vector3 transferVector = info.point;

        transferVector.y = transform.position.y;

        Vector3 dir = transferVector - transform.position;

        dir.Normalize();

        return dir;
    }

}
