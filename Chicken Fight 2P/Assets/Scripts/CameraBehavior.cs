using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private float cameraSize;
    private Camera mainCam;
    [SerializeField] private GameObject players;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    void AdjustCameraSize() {
        float outOfBoundsX = 100;
        float outOfBoundsY = 50;
        float minX = outOfBoundsX, maxX = -outOfBoundsX, minY = outOfBoundsY, maxY = -outOfBoundsY;
        foreach (Transform child in players.transform) {
            Vector2 childPos = child.transform.position;
            if (childPos.x < minX)
                minX = childPos.x;
            if (childPos.x > maxX)
                maxX = childPos.x;

            if (childPos.y < minY)
                minY = childPos.y;
            if (childPos.y > maxY)
                maxY = childPos.y;
        }

        float avX = (minX + maxX) / 2;
        float avY = (minY + maxY) / 2;

        mainCam.transform.position = new Vector3(avX, avY, 0f);

        // calculate orthographic size.
        float xDist = avX - minX;
        float yDist = avY - minY;
        // if the players are going to be vertically out of range, then make camera adjust based on y distance. else, camera should be focus on x distance.
        if (yDist > xDist/2) {
            mainCam.orthographicSize = yDist*2;
        }
        else 
            mainCam.orthographicSize = xDist;

        // however, don't go below nor above a certain number.
        if (mainCam.orthographicSize < minSize) {
            mainCam.orthographicSize = minSize;
        }
        else if (mainCam.orthographicSize > maxSize) {
            mainCam.orthographicSize = maxSize;
        }
    }

    void LateUpdate()
    {
        if (!PlayerSettings.instance.camLock)
        {
            AdjustCameraSize();
        }
        else
        {
            mainCam.orthographicSize = 8;
            mainCam.transform.position = Vector3.zero;
        }
    }
}
