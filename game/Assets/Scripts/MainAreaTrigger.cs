using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainAreaTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player"))
            cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 12;
    }

    private void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag("Player"))
            cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 6;
    }
}
