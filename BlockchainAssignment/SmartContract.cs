using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;

namespace BlockchainAssignment
{
    public class SmartContract
            public string Address { get; }
            private Engine _engine;

            public SmartContract(string code)
            {
                // generate an address (hash) from the code
                Address = ComputeAddress(code);

                // set up a fresh JS engine
                _engine = new Engine(cfg => cfg.LimitRecursion(64))
                    .SetValue("storage", new Dictionary<string, object>())
                    .Execute(code);
            }

            public object Invoke(string method, params object[] args)
            {
                // call the JS function, passing in storage and args
                var fn = _engine.GetValue(method);
                return fn.Invoke(args).ToObject();
            }

            private static string ComputeAddress(string code)
            {
                using (var sha = System.Security.Cryptography.SHA256.Create())
                {
                    var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(code));
                    return string.Concat(hash.Select(b => b.ToString("x2")));
                }
            }
        }
    }

}
}
