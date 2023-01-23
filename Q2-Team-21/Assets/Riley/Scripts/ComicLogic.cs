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
    public int GameScene = 1;
    private Vector2 Position = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PanelNumber > 6) PanelNumber = 6;
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
                Position = new Vector2(-60, 90);
                break;
        }

        if (rect.anchoredPosition.x > Position.x) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x-moveSpeed, rect.anchoredPosition.y);
        if (rect.anchoredPosition.x < Position.x) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x+moveSpeed, rect.anchoredPosition.y);
        if (rect.anchoredPosition.y > Position.y) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y-moveSpeed);
        if (rect.anchoredPosition.y < Position.y) rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y+moveSpeed);

        if (PanelNumber == 6 && rect.localScale.x > 0) rect.localScale = new Vector2(rect.localScale.x - 0.0005f, rect.localScale.y - 0.0005f);
        else if (rect.localScale.x < 1) rect.localScale = new Vector2(rect.localScale.x + 0.0005f, rect.localScale.y + 0.0005f);
        else if (rect.localScale.x > 1) rect.localScale = new Vector2(1, 1);

        if (rect.anchoredPosition == Position && PanelNumber == 0) SceneManager.LoadScene(MainMenuSceneNumber);
        if (rect.anchoredPosition == Position && PanelNumber == 6 && rect.localScale.x < 0.001) SceneManager.LoadScene(GameScene);

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
