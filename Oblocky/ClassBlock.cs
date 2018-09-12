using System;
using System.Collections.Generic;
using System.Linq;

namespace Oblocky
{
    public class ClassDefinition
    {
        public string Name { get; }
        public readonly Dictionary<string, Expression> Fields = new Dictionary<string, Expression>();
        public readonly Dictionary<string, IBlock> Methods = new Dictionary<string, IBlock>();
        public static readonly List<ClassDefinition> DefinitionList = new List<ClassDefinition>();

        public ClassDefinition(string name)
        {
            Name = name;
        }

        public void AddMethod(string name, IBlock method)
        {
            if (Methods.ContainsKey(name))
                throw new Exception("함수명 중첩");
            
            Methods.Add(name, method);
        }

        public void RemoveMethod(IBlock method)
        {
            Methods.Remove(Methods.FirstOrDefault(x => x.Value == method).Key);
        }

        public void AddFields(string name, Expression field)
        {
            if (Fields.ContainsKey(name))
                throw new Exception("필드명 중첩");

            Fields.Add(name, field);
        }

        public void RemoveFields(Expression field)
        {
            Fields.Remove(Fields.FirstOrDefault(x => x.Value == field).Key);
        }
    }
}
