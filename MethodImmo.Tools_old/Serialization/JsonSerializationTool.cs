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
using System.Reflection;

namespace Mid.Tools
{
    public class JsonSerializationTool<T> where T:class
    {
        public static T Deserialize(string serializedObject)
        {
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public static string SerializeAllTree(T toSerialize, Dictionary<Type, HashSet<string>> inclusions =null, Dictionary<Type, HashSet<string>> exclusions = null, ForEachRecursiveBoolDelegate keep=null)
        {
            StringBuilder result = new StringBuilder();

            ObjectTools.ForEachMemberRecursive(toSerialize, inclusions, exclusions,
                (val, parent, memberInfo, context) =>
                {
                    PropertyInfo prop = memberInfo as PropertyInfo;
                    FieldInfo field = memberInfo as FieldInfo;
                    Type valueType = prop != null ? prop.PropertyType : field != null ? field.FieldType : val == null ? null : val.GetType();

                    string memberNamePrefix = memberInfo == null ? "" : "\"" + memberInfo.Name + "\":";
                 
                    if (valueType == null || valueType.Namespace.Contains("System.Reflection"))
                    {
                        return false;
                    }

                    result.Append(memberNamePrefix);

                    if (!ObjectTools.IsPrimitiveType(valueType))
                    {
                        if (ObjectTools.IsArrayType(valueType))
                        {
                            result.Append("[");
                        }
                        else
                        {
                            result.Append("{");
                        }
                        //#region avoid loops
                        //if (context == null)
                        //    context = new HashSet<int>();
                        //if (root != null)
                        //{
                        //    int hash = root.GetHashCode();
                        //    if (context.Contains(hash))
                        //        return false;
                        //    else
                        //        context.Add(hash);
                        //}
                        //#endregion
                    }
                    return true;    
                },
                (val, parent, memberInfo, context) =>
                {
                    
                    if (val == null)
                    {
                        result.Append("null,");

                    }
                    else
                    {
                        Type valueType = val.GetType();
                        if (ObjectTools.IsPrimitiveType(valueType))
                        {
                            if (IsNumber(val))
                                result.Append( val.ToString() + ",");
                            else
                                result.Append( "\"" + val.ToString() + "\",");
                        }
                    }
                },
                (val, parent, memberInfo, context) =>
                {
                    PropertyInfo prop = memberInfo as PropertyInfo;
                    FieldInfo field = memberInfo as FieldInfo;
                    Type valueType = prop != null ? prop.PropertyType : field != null ? field.FieldType : val == null ? null : val.GetType();

                    if (valueType == null)
                    {
                        return;
                    }

                    if (!ObjectTools.IsPrimitiveType(valueType))
                    {
                        char[] lastChar = new char[1];
                        result.CopyTo(result.Length - 1, lastChar, 0, 1);
                        if(lastChar.First()==',')
                            result.Remove(result.Length - 1, 1);

                        result.Append(ObjectTools.IsArrayType(valueType)? "]," : "},");

                    }
                }, keep);
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        class IntValue { internal int Value=0; public IntValue(int value) { Value = value; } }

        public static string SerializeRootSinglesAndIds(T toSerialize, Dictionary<Type, HashSet<string>> inclusions = null, Dictionary<Type, HashSet<string>> exclusions = null, ForEachRecursiveBoolDelegate keep = null)
        {
            StringBuilder result = new StringBuilder();

            ObjectTools.ForEachMemberRecursive(toSerialize, inclusions, exclusions,
                (val, parent, memberInfo, context) =>
                {
                    PropertyInfo prop = memberInfo as PropertyInfo;
                    FieldInfo field = memberInfo as FieldInfo;
                    Type valueType = prop != null ? prop.PropertyType : field != null ? field.FieldType : val == null ? null : val.GetType();

                    string memberNamePrefix = memberInfo == null ? "" : "\"" + memberInfo.Name + "\":";

                    if (valueType == null)
                    {
                        return false;
                    }

                    result.Append(memberNamePrefix);

                    if (!ObjectTools.IsPrimitiveType(valueType))
                    {
                        ((IntValue)context).Value++;
                        if (ObjectTools.IsArrayType(valueType))
                        {
                            result.Append("[");
                            return parent==null || ((IntValue)context).Value <4;
                        }
                        else
                        {
                            result.Append("{");
                        }
                    }
                    return true;
                },
                (val, parent, memberInfo, context) =>
                {
                    if (val == null)
                    {
                        result.Append("null,");
                    }
                    else
                    {
                        Type valueType = val.GetType();
                        if (ObjectTools.IsPrimitiveType(valueType))
                        {
                            if (IsNumber(val))
                                result.Append(val.ToString() + ",");                            
                            else
                                result.Append("\"" + val.ToString() + "\",");
                        }
                        else if (ObjectTools.IsArrayType(valueType))
                        {
                            Type generic = valueType.GetGenericArguments().First();
                            if (ObjectTools.HasMember(generic, "Id"))
                            {
                                //switch
                                var property = generic.GetProperty("Id");
                                var collection = val as IEnumerable;
                                foreach (var item in collection)
                                {
                                    result.Append(property.GetValue(item) + ",");
                                }
                            }
                        }
                    }
                },
                (val, parent, memberInfo, context) =>
                {
                    PropertyInfo prop = memberInfo as PropertyInfo;
                    FieldInfo field = memberInfo as FieldInfo;
                    Type valueType = prop != null ? prop.PropertyType : field != null ? field.FieldType : val == null ? null : val.GetType();

                    if (valueType == null)
                    {
                        return;
                    }

                    if (!ObjectTools.IsPrimitiveType(valueType))
                    {
                        char[] lastChar = new char[1];
                        result.CopyTo(result.Length - 1, lastChar, 0, 1);
                        if (lastChar.First() == ',')
                            result.Remove(result.Length - 1, 1);

                        result.Append(ObjectTools.IsArrayType(valueType) ? "]," : "},");
                        ((IntValue)context).Value--;
                    }
                }, keep,new IntValue(0));
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

        public static void FillObject(string serialized, T toFill, Dictionary<Type, List<string>> inclusions=null, Dictionary<Type, List<string>> exclusions=null,ForEachRecursiveBoolDelegate filter=null)
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
