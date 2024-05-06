using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    Camera main_camera;
    public Camera Main_camera { 
        get 
        { 
            if(main_camera == null)
            {
                main_camera = GameObject.FindAnyObjectByType<Camera>();
            }
            return main_camera;
        } 
    }
}
