using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private byte _papersCount = 8;
    [SerializeField] private GameObject[] _papersPlaces;

    [SerializeField] private Text _papersCountText;
    [SerializeField, Min(0.1f)] private float _papersCountTextDeactivationTimeout;

    [SerializeField] private string _papersCountTextTemplate = "{0}/{1} записок";

    private byte _collectedPapers = 0;
    private Coroutine _deactivatePapersCountTextCoroutine;

    private void Start()
    {
        ActivateRandomPapers();
    }

    /// <summary>
    /// Activates random papers from <see cref="_papersPlaces"/>. Method activates papers at random places on the scene, therefore <see cref="_papersPlaces"/> array's length should always be bigger or equal than <see cref="_papersCount"/>
    /// </summary>
    private void ActivateRandomPapers()
    {
        GameObject[] _papersPlacesCopy = new GameObject[_papersPlaces.Length];
        Array.Copy(_papersPlaces, _papersPlacesCopy, _papersPlaces.Length);

        System.Random random = new System.Random();
        int index;
        for (int i = 0; i < _papersCount; i++)
        {
            index = random.Next(0, _papersPlacesCopy.Length);
            _papersPlacesCopy[index].SetActive(true);
            _papersPlacesCopy = _papersPlacesCopy.Where(el => el != _papersPlacesCopy[index]).ToArray();
        }
    }

    private void ShowVictoryScreen()
    {
        Debug.Log("Victory!!!");
    }

    private void ShowDefeatScreen()
    {

    }

    /// <summary>
    /// Collects paper and deactivates it
    /// </summary>
    public void CollectPaper(GameObject paper)
    {
        if (_deactivatePapersCountTextCoroutine != null)
            StopCoroutine(_deactivatePapersCountTextCoroutine);

        paper.SetActive(false);
        _collectedPapers++;

        ShowPapersCount();

        if (_collectedPapers == _papersCount)
            ShowVictoryScreen();
    }

    private void ShowPapersCount()
    {
        _papersCountText.text = string.Format(_papersCountTextTemplate, _collectedPapers, _papersCount);
        _papersCountText.gameObject.SetActive(true);

        _deactivatePapersCountTextCoroutine = StartCoroutine(DeactivatePapersCountText());
    }

    private IEnumerator DeactivatePapersCountText()
    {
        yield return new WaitForSeconds(_papersCountTextDeactivationTimeout);
        _papersCountText.gameObject.SetActive(false);
    }
}
