﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public Level level;

    public Text nameText;
    public Text sizeXText;
    public Text sizeYText;
    public InputField pathText;
    public Text bpmText;
    public Text framesText;

    private GridGenerator gridGenerator;

    private void Start()
    {
        gridGenerator = FindObjectOfType<GridGenerator>();
    }

    public void CreateLevel()
    {
        WWW www = new WWW("file://" + pathText.text);
        AudioClip song = www.GetAudioClip();

        level = new Level(nameText.text, new Vector2(int.Parse(sizeXText.text), int.Parse(sizeYText.text)), song, int.Parse(bpmText.text), int.Parse(framesText.text));
        gridGenerator.GenerateGrid(level.size);
    }
}

[System.Serializable]
public class Level
{
    public string name = "New Level";
    public Vector2 size = Vector2.one * 13f;
    public AudioClip song;
    public int bpm;
    public int amountOfFrames;

    public Level()
    {

    }

    public Level(string name, Vector2 size, AudioClip song, int bpm, int amountOfFrames)
    {
        this.name = name;
        this.size = size;
        this.song = song;
        this.bpm = bpm;
        this.amountOfFrames = amountOfFrames;
    }
}