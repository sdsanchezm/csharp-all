
namespace composition1
{
    class Installer
    {
        private readonly Logger _logger;

        public Installer(Logger logger)
        {
            _logger = logger;
        }

        public void Install()
        {
            _logger.Log("we are installing... from Install Method, in Installed class");
        }
    }
}