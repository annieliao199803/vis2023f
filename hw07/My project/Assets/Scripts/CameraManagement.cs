using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    [SerializeField]
    Camera[] cameras;

    [SerializeField]
    Camera mainCamera;

    private int cameraIndex;
    // Start is called before the first frame update
    void Start()
    {
        cameraIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cameraIndex += 1;
            if (cameraIndex == 4)
                cameraIndex = 0;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            cameraIndex -= 1;
            if (cameraIndex == -1)
                cameraIndex = 3;
        }
    }
    private void LateUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameras[cameraIndex].transform.position, 5.0f * Time.deltaTime);
    }
}
