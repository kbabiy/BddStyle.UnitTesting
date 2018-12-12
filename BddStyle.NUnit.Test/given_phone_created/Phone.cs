using System;

namespace BddStyle.NUnit.Test.given_phone_created
{
    public class Phone
    {
        internal const string ServicePin = "911";

        private bool _unlocked;
        private readonly string _pinCode;

        public Phone(string pinCode)
        {
            if (string.IsNullOrEmpty(pinCode))
                throw new ArgumentNullException(nameof(pinCode));
            _pinCode = pinCode;
        }

        public bool LastCallSucceeded { get; private set; }
        public string LastCalled { get; private set; }

        public bool Unlock(string pinCode)
        {
            if(string.IsNullOrEmpty(pinCode))
                throw new ArgumentNullException();

            if (pinCode == _pinCode || pinCode == ServicePin)
                _unlocked = true;
            return _unlocked;
        }

        public void Call(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentNullException();

            LastCalled = phoneNumber;
            LastCallSucceeded = _unlocked;
        }
    }
}