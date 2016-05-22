using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

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


        public static void FillObject(string serialized, T toFill, Dictionary<Type, List<string>> inclusions=null, Dictionary<Type, List<string>> exclusions=null,ForEachRecursiveFilterDelegate filter=null)
        {
            dynamic jsonDynamic = JObject.Parse(serialized);

            ObjectTools.ForEachExpandoRecursive(jsonDynamic, null, null,
                (ForEachExpandoRecursiveDelegate)((val, parent, memberName, context) =>
                {
                    //update context
                }),
                (ForEachExpandoRecursiveDelegate)((val, parent, memberName, context) =>
                {
                    //set value
                }),
                (ForEachExpandoRecursiveDelegate)((val, parent, memberName, context) =>
                {
                    //update context
                })
               );
        }

    }
}
