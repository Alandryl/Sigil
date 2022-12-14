using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public TextMeshPro text;
    public float lifetime = 1f;
    public float minDist = 2f;
    public float maxDist = 3f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;

    public void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);

        float direction = Random.rotation.eulerAngles.z;
        iniPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        //targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0f));
        targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(0f, 2, 0f));
        transform.localScale = Vector3.zero;

        transform.position = iniPos;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float fraction = lifetime / 2;



        if (timer > lifetime)
        {
            Destroy(gameObject);
        }

        if (timer > fraction)
        {
            text.color = Color.Lerp(text.color, Color.clear, (timer - fraction) / (lifetime - fraction));
        }


        //transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / lifetime));
        //transform.position += transform.TransformDirection(Vector3.up * 0.02f);
        //transform.localPosition += transform.TransformDirection(Vector3.up * 0.02f);
        transform.localPosition += new Vector3(0f, 1 * 0.02f, 0f);
        
        transform.localScale = Vector3.Lerp(Vector3.one / 2, Vector3.one, Mathf.Sin(timer / lifetime));

    }

    public void SetDamageText(float damage)
    {
        text.text = damage.ToString();
    }




}
