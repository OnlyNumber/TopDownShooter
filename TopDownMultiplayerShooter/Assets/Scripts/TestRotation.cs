using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    public GameObject player;

    public CharacterController CC;

    Vector3 moveInputVector = Vector2.zero;

    public float speed;

    void Update()
    {
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.z = Input.GetAxis("Vertical");

        CC.Move(moveInputVector * Time.deltaTime * speed);

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(r, out RaycastHit info);

        Vector3 dir = info.point - player.transform.position;

        dir.Normalize();

        player.transform.forward = dir;



    }
}
