using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryController : MonoBehaviour
{
    public GameObject m_Ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            m_Ball.transform.position.y,
            gameObject.transform.position.z
        );
    }
}
