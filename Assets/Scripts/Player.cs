using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float vel = 6, velRot = 100;
    [SerializeField]
    private Animator heroiAnim;

    void Update()
    {
        float move = Input.GetAxis("Vertical") * vel;
        float rotacao = Input.GetAxis("Horizontal") * velRot;
        move *= Time.deltaTime;
        rotacao *= Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            transform.Rotate(0, rotacao, 0);
        else
            transform.Rotate(0, 0, 0);
        if (move != 0)
        {
            Vector3 moveDirection = new Vector3(0, 0, move);
            transform.Translate(moveDirection);
            if (move > 0)
                heroiAnim.SetInteger("transition", 1);
            else
                heroiAnim.SetInteger("transition", 2);
        }
        else
        {
            heroiAnim.SetInteger("transition", 0);
        }
    }
}
