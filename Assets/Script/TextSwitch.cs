using System.Collections;
using UnityEngine;

public class TextSwitch : MonoBehaviour
{
    public GameObject textAwal;
    public GameObject textSetelah;

    public float delay = 2f;

    void Start()
    {
        // pastikan kondisi awal
        textAwal.SetActive(true);
        textSetelah.SetActive(false);

        StartCoroutine(SwitchText());
    }

    IEnumerator SwitchText()
    {
        yield return new WaitForSeconds(delay);

        textAwal.SetActive(false);
        textSetelah.SetActive(true);
    }
}