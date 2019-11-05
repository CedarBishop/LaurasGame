using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private PlayerController player;
    private bool followPlayer;
    private bool moveToFinishLocation;
    private Vector2 finishLocation = new Vector2(35.0f,-15f);
    private Camera mainCamera;

    private float cameraSize;

    void Start()
    {
        mainCamera = Camera.main;
        cameraSize = mainCamera.orthographicSize;
        followPlayer = true;
        player = FindObjectOfType<PlayerController>();
        Respawner.CompleteGame += ZoomOut;
    }

    private void OnDestroy()
    {
        Respawner.CompleteGame -= ZoomOut;
    }

    void Update()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        else if (moveToFinishLocation)
        {
            cameraSize = Mathf.Lerp(cameraSize,45f,0.04f);
            mainCamera.orthographicSize = cameraSize;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(finishLocation.x,finishLocation.y, transform.position.z), 0.3f);
        }
    }

    void ZoomOut ()
    {
        followPlayer = false;
        moveToFinishLocation = true;
    }
}
