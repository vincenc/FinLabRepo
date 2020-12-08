using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Threading.Tasks;
using FinLabLibs;
using System.Linq;

namespace FinLabTools
{
    public class FinLabToolCommand
    {

        private static FinLabToolCommand _instanct;
        public static FinLabToolCommand Instance
        {
            get
            {
                if (_instanct == null)
                {
                    _instanct = new FinLabToolCommand();
                    _instanct.Init();
                }

                return _instanct;
            }
        }

        [Command("AddPfl", 1, " Add Pfl")]
        public string AddPfl(string[] args)
        {
            Portfolio pfl = new Portfolio(@"C:\Users\wencliao\source\repos\FinLabRepo2\FinLabRepo\portfolio.csv");
            pfl.Add(args[0]);
            pfl.Save();
            pfl.Stocks.OrderBy(n=>n).ToList().ForEach(n =>
            {
                Console.WriteLine(n);
            });

            return " AddPfl";
        }


        public Dictionary<string, MethodInfo> m_Methods = new Dictionary<string, MethodInfo>();

        public void Init()
        {
            System.Type type = typeof(FinLabToolCommand);
            var methods = type.GetMethods();

            foreach (var methodInfo in methods)
            {
                object[] attribute = methodInfo.GetCustomAttributes(typeof(CommandAttribute), false);
                if (attribute.IsNullOrEmpty() == false)
                {
                    CommandAttribute cma = attribute[0] as CommandAttribute;
                    m_Methods.Add(cma.Command, methodInfo);
                }
            }
        }

        public string Call(string imput)
        {
            var tmpStr = imput.Split(',');

            if (m_Methods.ContainsKey(tmpStr[0]))
            {
                List<string> parameters = new List<string>();
                for (int i = 1; i < tmpStr.Length; i++)
                {
                    parameters.Add(tmpStr[i]);
                }

                var method = m_Methods[tmpStr[0]];
                var info = method.GetCustomAttributes(typeof(CommandAttribute), false)[0] as CommandAttribute;

                if (parameters.Count != info.ParameterAmount)
                {
                    return "Usage: " + info.Usage;
                }
                else
                {
                    return method.Invoke(this, new object[] { parameters.ToArray() }) as string;
                }
            }
            else
            {
                return "Command not found";
            }
        }

    } 
}
