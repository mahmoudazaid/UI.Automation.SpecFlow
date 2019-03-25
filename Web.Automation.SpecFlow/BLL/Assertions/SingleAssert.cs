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
            {
                // TODO Act in case of failure, e.g. take screenshot
                var screenshot = "MethodToSaveScreenshotAndReturnFilename";
                _message += $". Screenshot captured at: {screenshot}";
            }
        }

        public override string ToString()
        {
            return $"'{_message}' assert was expected to be " +
                    $"'{_expected}' but was '{_actual}'";
        }
    }
}
