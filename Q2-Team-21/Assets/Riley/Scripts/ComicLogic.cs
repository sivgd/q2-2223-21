using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicLogic : MonoBehaviour
{
    public int PanelNumber = 0;
    private RectTransform rect;
    public float moveSpeed;
    public int MainMenuSceneNumber = 0;
    private Vector2 Position = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PanelNumber > 5) PanelNumber = 5;
        if (PanelNumber < 0) PanelNumber = 0;

        switch(PanelNumber)
        {
            case 0:
                Position = new Vector2(0, 0);
                break; 
            
            case 1:
                Position = new Vector2(-1024, 0);
                break; 
            
            case 2:
                Position = new Vector2(0, 768);
                break;

            case 3:
                Position = new Vector2(-1024, 768);
                break;
    
            case 4:
                Position = new Vector2(0, 1536);
                break;
    
            case 5:
                Position = new Vector2(-1024, 1536);
                break;
                
            default:
                break;
        }

        if (rect.anchoredPosition.x > Position.x) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x-moveSpeed, rect.anchoredPosition.y);
        if (rect.anchoredPosition.x < Position.x) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x+moveSpeed, rect.anchoredPosition.y);
        if (rect.anchoredPosition.y > Position.y) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y-moveSpeed);
        if (rect.anchoredPosition.y < Position.y) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y+moveSpeed);

        if (rect.anchoredPosition == Position && PanelNumber == 5) SceneManager.LoadScene(MainMenuSceneNumber);

    }

    public void ButtonBack()
    {
        PanelNumber--;
    }
    public void ButtonForward()
    {
        PanelNumber++;
    }
}
