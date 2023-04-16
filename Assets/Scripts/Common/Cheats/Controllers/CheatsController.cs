using System;
using Common.Cheats.Configs;
using Zenject;

namespace Common.Cheats.Controllers
{
    public class CheatsController : IInitializable, IDisposable
    {
        private readonly CheatsConfig _config;

        public CheatsController(CheatsConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
    }
}