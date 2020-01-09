using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_Speed = 15.0f;
    private CharacterController Charcon;
	// Use this for initialization
	void Start ()
    {
        Charcon=GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Grundlegende Steuerung des Spielers
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //Wandelt die Bewegungsrichtung von local in Worldspace um
        Move = transform.TransformDirection(Move);
        //Normaisieren damit man Diagonal nicht scheller läuft
        Move = Move.normalized * Time.deltaTime* m_Speed;
        Charcon.Move(Move);
	}
}
