using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Stealer
{
    internal class Spy
    {
        public string StealFieldInfo(string className, string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();

            Type hacker = Type.GetType(className);

            var fields = hacker.GetFields(BindingFlags.Public
                | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in fields.Where(x => fieldNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(Activator.CreateInstance(hacker))}");
            }
            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();
            Type classType = Type.GetType(className);

            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo[] methodInfoSetters = classType.GetMethods(BindingFlags.Public 
                | BindingFlags.Instance).Where(m => m.Name.StartsWith("set")).ToArray();
            MethodInfo[] methodInfoGetters = classType.GetMethods(BindingFlags.Instance 
                | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("get")).ToArray();

            foreach (var field in fieldInfos)
            {
                if (!field.IsPrivate)
                {
                    result.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var method in methodInfoGetters)
            {
                result.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in methodInfoSetters)
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] methodsPrivate = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var method in methodsPrivate)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] getters = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static).Where(m => m.Name.StartsWith("get")).ToArray();
            
            MethodInfo[] setters = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static).Where(m => m.Name.StartsWith("set")).ToArray();

            foreach (var method in getters)
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in setters)
            {
                result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return result.ToString();
        }
    }
}
