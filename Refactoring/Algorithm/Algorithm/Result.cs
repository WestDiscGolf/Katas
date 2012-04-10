using System;

namespace Algorithm
{
    public class Result
    {
        private Person _personOne;
        private Person _personTwo;
        private TimeSpan _delta = TimeSpan.MinValue;

        public Person PersonOne
        {
            get { return _personOne; }
            set
            {
                _personOne = value;
                DetermineOrder();
            }
        }

        public Person PersonTwo
        {
            get { return _personTwo; }
            set
            {
                _personTwo = value;
                DetermineOrder();
            }
        }

        public TimeSpan GetDelta()
        {
            if (PersonOne == null)
            {
                throw new NullReferenceException("Time delta can not be calculated if PersonOne is null");
            }

            if (PersonTwo == null)
            {
                throw new NullReferenceException("Time delta can not be calculated if PersonTwo is null");
            }

            // it won't change after initial calculation, but stop it being calc'ed every time
            if (_delta == TimeSpan.MinValue)
            {
                _delta = PersonTwo.BirthDate - PersonOne.BirthDate;
            }
            return _delta;
        }

        private void DetermineOrder()
        {
            if ((PersonOne == null) || (PersonTwo == null))
            {
                return;
            }

            if (PersonOne.BirthDate > PersonTwo.BirthDate)
            {
                var temp = PersonOne;
                PersonOne = PersonTwo;
                PersonTwo = temp;
            }
        }
    }
}