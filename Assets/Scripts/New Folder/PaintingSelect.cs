using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaintingSelect : MonoBehaviour
{
    private Transform content;
    private Object[] textures;
    void Start()
    {
        content = gameObject.transform;
        textures = Resources.LoadAll("Intro", typeof(Sprite));

        foreach (var intro in textures)
        {
            GameObject Btn = new GameObject(intro.name);
            Btn.transform.SetParent(content, false);
            Btn.AddComponent<Image>().sprite = intro as Sprite;
            Btn.AddComponent<Button>().onClick.AddListener(() => ButtonClicked(intro.name));
        }
    }
    private void ButtonClicked(string name="") {
        PlayerPrefs.SetString("picture",name);
        if (name!="") SceneManager.LoadScene(1);
    }

}
        
 