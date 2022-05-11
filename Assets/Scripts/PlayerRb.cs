using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRb : MonoBehaviour
{
    public float Velocidade;
    public float VelocidadeRotacaoCamera;

    void Start()
    {

    }

    void FixedUpdate()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        transform.Translate(direcao * Velocidade * Time.deltaTime, Space.World);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcao), 5 * Time.deltaTime);

        if (direcao != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcao), VelocidadeRotacaoCamera * Time.deltaTime);
            Quaternion paraRotacionar = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, paraRotacionar, VelocidadeRotacaoCamera * Time.deltaTime);
            GetComponent<Animator>().SetInteger("transition", 1);
        }
        else
        {
            GetComponent<Animator>().SetInteger("transition", 0);
        }
    }
}
