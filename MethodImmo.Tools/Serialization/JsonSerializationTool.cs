using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Dynamic;

namespace Mid.Tools
{
    public class JsonSerializationTool<T> where T:class
    {
        public static T Deserialize(string serializedObject)
        {
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public static string Serialize(T toSerialize, Dictionary<Type, HashSet<string>> inclusions =null, Dictionary<Type, HashSet<string>> exclusions = null, ForEachRecursiveFilterDelegate filter=null)
        {
            StringBuilder result = new StringBuilder();

            ObjectTools.ForEachMemberRecursive(toSerialize, inclusions, exclusions,
                (val, parent, memberInfo, context) =>
                {
                    Type valueType = val.GetType();
                    string memberNamePrefix = memberInfo == null ? "" : "\""+ memberInfo.Name + "\":";
                    if (ObjectTools.IsArrayType(valueType))
                    {
                        result.Append(memberNamePrefix + "[");
                    }
                    else
                    {
                        result.Append(memberNamePrefix + "{");
                    }
                },
                (val, parent, memberInfo, context) =>
                {
                    Type valueType = val.GetType();
                    string memberNamePrefix = memberInfo == null ? "" : "\"" + memberInfo.Name + "\":";
                    if (ObjectTools.IsPrimitiveType(valueType))
                    {
                        if(IsNumber(val))
                            result.Append(memberNamePrefix +  val.ToString() +",");
                        else
                            result.Append(memberNamePrefix + "\"" + val.ToString() + "\",");
                    }
                },
                (val, parent, memberInfo, context) =>
                {
                    Type valueType = val.GetType();
                    string memberNamePrefix = memberInfo == null ? "" : "\"" + memberInfo.Name + "\":";
                    if (ObjectTools.IsArrayType(valueType))
                    {
                        result.Remove(result.Length - 1, 1);
                        result.Append("],");
                    }
                    else if (!ObjectTools.IsPrimitiveType(valueType))
                    {
                        result.Remove(result.Length - 1, 1);
                        result.Append("},");
                    }
                }, filter);
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        public static bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        public static void FillObject(string serialized, T toFill, Dictionary<Type, List<string>> inclusions=null, Dictionary<Type, List<string>> exclusions=null,ForEachRecursiveFilterDelegate filter=null)
        {
            JObject jsonDynamic = JObject.Parse(serialized);

            ObjectTools.ForEachExpandoRecursive(jsonDynamic, null, null,
                (val, parent, memberName, context) =>
                {
                    if (memberName != null)
                        ((List<string>)context).Add(memberName);
                    //update context
                },
                (val, parent, memberName, context) =>
                {
                    ((List<string>)context).Add(memberName);
                    string path = ((List<string>)context).Aggregate((a, b) => (a + (b.StartsWith("[") ? "" : ".") + b));
                    ((List<string>)context).RemoveAt(((List<string>)context).Count - 1);
                    //set value
                    ObjectTools.SetMemberValuePath(toFill, path, val);
                },
                (val, parent, memberName, context) =>
                {
                    //update context
                    if (memberName != null && memberName != "*")
                        ((List<string>)context).RemoveAt(((List<string>)context).Count - 1);
                }, null,new List<string>() 
               );
        }

    }
}
