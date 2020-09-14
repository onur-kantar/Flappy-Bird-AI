using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Bird : Agent
{
    [Header("References")]

    [SerializeField] private Rigidbody rb = null;
    [SerializeField] private PipeHandler pipeHandler = null;

    [Header("Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxVelocityMagnitude = 5f;

    private Vector3 startingPos;

    public override void Initialize()
    {
        startingPos = transform.position;
    }
    public override void OnEpisodeBegin()
    {
        transform.position = startingPos;
        rb.velocity = Vector3.zero;
        pipeHandler.ResetPipes();
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        AddReward(0.1f);
        if (Mathf.FloorToInt(vectorAction[0]) != 1) { return; }
        jump();
    }
    //public override void Heuristic(float[] actionsOut)
    //{
    //    actionsOut[0] = 0;
    //    if (!Input.GetKeyDown(KeyCode.Space)) { return; }
    //    actionsOut[0] = 1;
    //}
    private void OnTriggerEnter(Collider other)
    {
        AddReward(-1.0f);
        EndEpisode();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
    }
    private void jump()
    {
        rb.velocity = Vector3.up * jumpForce;
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocityMagnitude);
    }
}
