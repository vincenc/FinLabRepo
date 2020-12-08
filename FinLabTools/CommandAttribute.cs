using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace FinLabTools
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        private string m_command;
        private int m_parameterAmmount;
        private string m_usage;

        public string Command
        {
            get { return m_command; }
        }

        public int ParameterAmount
        {
            get { return m_parameterAmmount; }
        }

        public string Usage
        {
            get { return m_usage; }
        }

        public CommandAttribute(string command, int parameterAmount, string usage)
        {
            m_command = command;
            m_parameterAmmount = parameterAmount;
            m_usage = usage;
        }
    } 
}
