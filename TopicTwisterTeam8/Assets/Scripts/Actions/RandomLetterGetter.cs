﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class RandomLetterGetter : ILetterGetter
    {
        public char GetLetter()
        {
            System.Random rnd = new System.Random();
            //char randomChar = (char)rnd.Next('A', 'Z');
            char randomChar = (char)rnd.Next('A', 'E');
            return randomChar;
        }
    }

