﻿using System;
using System.Runtime.Serialization;
using IPersonLib;

namespace PersonVacationLib
{
    [Serializable]
    public class PersonVacation : IPersonVacation
    {
        public PersonVacation()
        {
            _name = "";
            _startDateVacation = null;
            _endDateVacation = null;
        }
        public PersonVacation(string name)
        {
            _name = name;
            _startDateVacation = null;
            _endDateVacation = null;
        }
        private string _name;
        private DateTime? _startDateVacation;
        private DateTime? _endDateVacation;
        public string Name 
        { 
            get => _name;            
            set 
            {
                if (value.Length > 0) _name = value;
                else new Exception("Пустое имя");
            }
        }
        public DateTime? StartDateVacation
        {
            get => _startDateVacation;
            set 
            {
                _startDateVacation = value;
            }
        }
        public DateTime? EndDateVacation
        {
            get => _endDateVacation;
            set
            {
                _endDateVacation = value;
            }
        }
    }
}
