using BLL.Utilities;

namespace BLL.Assertions
{
    public class SingleAssert
    {
        private readonly string _message;
        private readonly string _expected;
        private readonly string _actual;

        public bool Failed { get; }

        public SingleAssert(string message, string expected, string actual)
        {
            _message = message;
            _expected = expected;
            _actual = actual;

            Failed = _expected != _actual;
            if (Failed)
                ScreenShot.TakeScreenShot();           
        }

        public override string ToString()
        {
            return $"'{_message}' assert was expected to be " +
                    $"'{_expected}' but was '{_actual}'";
        }
    }
}
