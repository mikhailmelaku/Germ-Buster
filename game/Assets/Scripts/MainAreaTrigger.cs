using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainAreaTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    private float defaultSize;
    private IEnumerator coroutine;

    
    void Awake() {
        defaultSize = cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
    }
    /* FIXME: figure out coroutines looool
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            coroutine = ZoomCamera(12f);
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            coroutine = ZoomCamera(defaultSize);
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize =
                Mathf.Lerp(cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize, 12, 0.1f);
    }


    private IEnumerator ZoomCamera(float endPoint) {
        float difference =
        Mathf.Abs(
            cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize - endPoint);

        while (difference > 0.5) {
            Mathf.Lerp(cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize,
                endPoint, 0.1f);
            difference = Mathf.Abs(
            cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize - endPoint);
        
        }


    }
    */

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            float difference = Mathf.Abs(cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize
                - 12);
            if (difference > 0.5) {
            cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize =
                    Mathf.Lerp(cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize, 12, 0.01f);

            difference = Mathf.Abs(cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize - 12);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            cam.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = defaultSize;
        }
    }

}
