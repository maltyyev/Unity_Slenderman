using System;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private byte _papersCount = 8;
    [SerializeField] private GameObject[] _papersPlaces;

    private byte _collectedPapers = 0;

    private void Start()
    {
        ActivateRandomPapers();
    }

    /// <summary>
    /// Activates random papers from <see cref="_papersPlaces"/>. Method activates papers at random places on the scene, therefore <see cref="_papersPlaces"/> length should always be bigger or equal than <see cref="_papersCount"/>
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

    }

    private void ShowDefeatScreen()
    {

    }

    /// <summary>
    /// Collects paper and deactivates it
    /// </summary>
    public void CollectPaper(GameObject paper)
    {
        paper.SetActive(false);
        _collectedPapers++;

        if (_collectedPapers == _papersCount)
            ShowVictoryScreen();
    }
}
