using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionChanger : MonoBehaviour
{

    public GameObject tilemap;
    public GameObject tilemap2;
    public GameObject m_MainCamera;
    public GameObject m_CameraTwo;
    private bool active = true;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && active)
        {
            tilemap.SetActive(false);
            tilemap2.SetActive(true);
            m_MainCamera.SetActive(false);
            m_CameraTwo.SetActive(true);
            Debug.Log("disabled");
            active = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !active)
        {
            tilemap.SetActive(true);
            tilemap2.SetActive(false);
            m_CameraTwo.SetActive(false);
            m_MainCamera.SetActive(true);
            Debug.Log("Enabled");
            active = true;
        }
    }
}
