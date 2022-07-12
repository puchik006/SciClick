using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopScreenText : MonoBehaviour
{
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _contentText;

    private string[] _creatorsList = new string[10]
    {"Author of idea: \r\n \r\n Pavel Buriachenko",
    "Progaming: \r\n \r\n Pavel Buriachenko",
    "Musics searching: \r\n \r\n Pavel Buriachenko",
    "Models sneaking: \r\n \r\n Pavel Buriachenko",
    "Sound producer: \r\n \r\n Pavel Buriachenko",
    "Main actor: \r\n \r\n Pavel Buriachenko",
    "Dude: \r\n \r\n Pavel Buriachenko",
    "Big Show: \r\n \r\n Pavel Buriachenko",
    "Beer lover: \r\n \r\n Pavel Buriachenko",
    "Greatest guy: \r\n \r\n Pavel Buriachenko"};

    delegate void CreatorsListAction();
    event CreatorsListAction ListIsOver;

    private BuVisualEffects Effects = new BuVisualEffects();

    private void Start()
    {
        Effects.SetZeroAlfaColor(_contentText);

        ListIsOver += StartShowCreators;

        StartShowCreators();

        Monster.OnMonsterDead += ShowScore;
    }

    public void StartShowCreators()
    {
        _titleText.text = "Creators";

        StartCoroutine(ShowCreators());
    }

    public void SetGameScreen()
    {
        StopAllCoroutines();

        _titleText.text = "Score: ";
        _contentText.text = "\r\n 0";
    }

    public void ShowScore()
    {
        _contentText.text = $"{GameController.GameScore}";
    }

    private IEnumerator ShowCreators()
    {
        foreach (string str in _creatorsList)
        {
            _contentText.text = str;

            StartCoroutine(Effects.FadeIn(_contentText,0.03f));

            yield return new WaitForSeconds(3f);

            StartCoroutine(Effects.FadeOut(_contentText, 0.03f));

            yield return new WaitForSeconds(1f);
        }

        ListIsOver?.Invoke();
    }
}
