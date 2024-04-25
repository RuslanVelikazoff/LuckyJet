using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TemplateSpawner : MonoBehaviour
{
    public static TemplateSpawner Instance { get; private set; }

    [SerializeField] 
    private GameObject[] templates;
    
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField] 
    private Transform spawnNewTemplatePosition;
    [SerializeField] 
    private Transform destroyPosition;

    private int randomIndex;
    
    private float templateSpeed;

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.11f);
        
        SpawnTemplate();
    }

    public void SetTemplateSpeed(float templateSpeed)
    {
        this.templateSpeed = templateSpeed;
    }

    public void SpawnTemplate()
    {
        randomIndex = Random.Range(0, templates.Length);
        GameObject template = Instantiate(templates[randomIndex], spawnPosition.transform.localPosition, Quaternion.identity);
        template.GetComponent<TemplateMove>().SpawnTemplate(templateSpeed, destroyPosition, spawnNewTemplatePosition);
    }
}
