using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public GameObject gyroDebug;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Application.targetFrameRate = 60; //Set le framerate a 60 pour eviter de drain la batterie trop vite
    }

    public static GameController Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.LogError("Game controller is NULL");
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGyroDebugRot(Vector3 eulerRot)
    {
        gyroDebug.transform.eulerAngles = eulerRot;
    }

    public void ChangeGyroDebugRot(Quaternion quaterRot)
    {
        gyroDebug.transform.rotation = quaterRot;
    }
}
