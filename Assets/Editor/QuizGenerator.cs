﻿using System;
using System.Collections.Generic;
using System.IO;
using Data;
using UnityEngine;

namespace Editor
{
    [CreateAssetMenu(fileName = "QuizGenerator", menuName = "Editor/QuizGenerator")]
    public class QuizGenerator : ScriptableObject
    {
        public string FilePath;
        public SubjectiveQuizList TargetList;
        [SerializeField] private bool _lolQuizUpdate = false;
        [SerializeField] private bool _overwatchQuizUpdate = false;
        [SerializeField] private bool _maplestoryQuizUpdate = false;
        [SerializeField] private bool _tekkenQuizUpdate = false;
        [SerializeField] private bool _steamQuizUpdate = false;
        [SerializeField] private bool _hearthstoneQuizUpdate = false;
        [SerializeField] private bool _minecraftQuizUpdate = false;
        [SerializeField] private bool _valorantQuizUpdate = false;
        private const string LOL_FILE = "LOL";
        private const string OVERWATCH_FILE = "OVERWATCH";
        private const string MAPLESTORY_FILE = "MAPLESTORY";
        private const string TEKKEN_FILE = "TEKKEN";
        private const string STEAM_FILE = "STEAM";
        private const string HEARTHSTONE_FILE = "HEARTHSTONE";
        private const string MINECRAFT_FILE = "MINECRAFT";
        private const string VALORANT_FILE = "VALORANT";
        private const string FILE_TYPE = "txt";


        public void Generate()
        {
            TargetList.LolQuizzes = _lolQuizUpdate ? ParsData($"{LOL_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.OverwatchQuizzes = _overwatchQuizUpdate ? ParsData($"{OVERWATCH_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.MapleQuizzes = _maplestoryQuizUpdate ? ParsData($"{MAPLESTORY_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.TekkenQuizzes = _tekkenQuizUpdate ? ParsData($"{TEKKEN_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.SteamQuizzes = _steamQuizUpdate ? ParsData($"{STEAM_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.HearthStoneQuizzes = _hearthstoneQuizUpdate ? ParsData($"{HEARTHSTONE_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.MinecraftQuizzes = _minecraftQuizUpdate ? ParsData($"{MINECRAFT_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
            TargetList.ValorantQuizzes = _valorantQuizUpdate ? ParsData($"{VALORANT_FILE}.{FILE_TYPE}") : new List<SubjectiveQuiz>();
        }

        private List<SubjectiveQuiz> ParsData(string fileName)
        {
            Debug.Log(fileName);
            var path = $"{FilePath}/{fileName}";
            if (!File.Exists(path)) {
                Debug.LogError($"{fileName} not found.");
                return new List<SubjectiveQuiz>();
            }
            var reader = GetFileStreamReader(path);
            var count = 0;
            List<SubjectiveQuiz> subjectiveQuizzes = new List<SubjectiveQuiz>();
            while (reader.Peek() != -1)
            {
                var line = reader.ReadLine();
                try
                {
                    SubjectiveQuiz subjectiveQuiz = CreateSubjectiveQuiz(line);
                    subjectiveQuizzes.Add(subjectiveQuiz);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error position : {count}\n{e.StackTrace}");
                }
                count++;
            }
            Debug.Log(count);
            reader.Close();
            return subjectiveQuizzes;
        }

        private SubjectiveQuiz CreateSubjectiveQuiz(string text)
        {
            var quiz = new SubjectiveQuiz();
            var texts = text.Split('?','/');
            quiz.Question = texts[0] + "?";
            quiz.Answer = texts[1];
            return quiz;
        }

        private StreamReader GetFileStreamReader(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            return new StreamReader(fileStream);
        }
    }
}