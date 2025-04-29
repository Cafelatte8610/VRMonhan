using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleUIManager : MonoBehaviour
{
    [SerializeField] private float MaxRadius;
    [SerializeField] private List<GameObject> UIElem;
    private float defaultRad;

    [SerializeField] private bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var elem in UIElem)
        {
            elem.SetActive(false);
        }

        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        // OpenCircleUI();
    }

    public void OpenCircleUI()
    {
        if(isOpen) return;
        foreach (var elem in UIElem)
        {
            elem.SetActive(true);
        }
        defaultRad = UIElem[0].transform.localEulerAngles.x;
        float elemCut = UIElem.Count;
        float parRad = MaxRadius / elemCut;
        for (int i = 0; i < elemCut; i++)
        {
            UIElem[i].transform.DOLocalRotate(new Vector3(0, defaultRad + parRad * i, 0), 0.6f);
        }

        isOpen = true;
    }
    
    public void CloseCircleUI()
    {
        if (!isOpen) return;
        float elemCut = UIElem.Count;
        foreach (var elem in UIElem)
        {
            elem.transform.DOLocalRotate(new Vector3(0, defaultRad, 0), 0.6f)
                .OnComplete(() => elem.SetActive(false));
        }

        isOpen = false;
    }
}
