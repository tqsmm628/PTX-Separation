using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Separation.Services
{
    public static class SqlSL
    {
        public static string Insert(string table, object pairs)
            => Insert(table, pairs.GetType().GetFields().ToDictionary(o => o.Name, o => o.GetValue(pairs)));
        
        private static string Insert(string table, Dictionary<string, object> pairs)
            => $"insert into {table} " +
               $"({string.Join(", ", pairs.Keys)}) " +
               "values " +
               $"({string.Join(", ", pairs.Values.Select(AsString))});";

        private static string Delete(string table, string where = null)
            => $"delete from {table}{(where == null ? string.Empty : $" where {where}")};";

        private static string AsString(object o)
        {
            switch (o)
            {
                case null: return "null";
                
                case int _:
                case float _:
                case double _: return $"{o}";
                
                case bool b: return $"b'{(b ? 1 : 0)}'";
                
                case DateTime dt: return $"'{dt:yyyy-MM-dd hh:mm:ss}'";
            }
            return $"'{o}'";
        }
    }
}