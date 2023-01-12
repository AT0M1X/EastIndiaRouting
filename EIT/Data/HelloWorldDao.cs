using FTOP.Dappersetup;
using Microsoft.Extensions.Logging;

namespace EIT.Data
{
    public class HelloWorldDao : BaseDao
    {
        public HelloWorldDao(IConnectionProvider cp, ILogger<HelloWorldDao> logger) : base(cp, logger)
        {
        }
    }
}
