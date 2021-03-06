﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace Mid.Tools
{
    public delegate void ForEachRecursiveDelegate(object currentMemberValue, object parent, MemberInfo memberInfo, object context);
    public delegate bool ForEachRecursiveBoolDelegate(object currentMemberValue, object parent, MemberInfo memberInfo,object context);
    public delegate object ForEachRecursiveConverterDelegate(object currentMemberValue, object parent, MemberInfo memberInfo, object context);

    public delegate void ForEachExpandoRecursiveDelegate(object currentMemberValue, object parent, string parentMemberName, object context);
    public delegate bool ForEachExpandoRecursiveBoolDelegate(object currentMemberValue, object parent, string parentMemberName, object context);

    public class ObjectTools:IObjectTools
    {
        #region object explorer tools


        public static void ForEachExpandoRecursive(JToken root, Dictionary<string, HashSet<string>> includesLinks, Dictionary<string, HashSet<string>> excludesLinks, ForEachExpandoRecursiveDelegate todoAtBegin, ForEachExpandoRecursiveDelegate todoOnLeaf, ForEachExpandoRecursiveDelegate todoAtEnd, ForEachExpandoRecursiveBoolDelegate filter = null, object context = null, object parent = null, string parentMemberName = null)
        {
            if (root is JValue)
            {
                if (todoOnLeaf != null)
                {
                    todoOnLeaf((root as JValue).Value, parent, parentMemberName, context);
                }
                return;
            }

            if (todoAtBegin != null)
            {
                todoAtBegin(root, parent, parentMemberName, context);
            }

            foreach (JProperty memberKeyPair in root)
            {
                object memberValue = memberKeyPair.Value;
                string memberName = memberKeyPair.Name;

                if (parentMemberName == null)
                    parentMemberName = "*";

                #region filters
                if (includesLinks != null)
                {
                    bool isTypeInLinks = includesLinks.ContainsKey(parentMemberName);
                    bool isMemberInLinks = isTypeInLinks && includesLinks[parentMemberName].Contains(memberName);

                    if (!isTypeInLinks)
                    {
                        continue;
                    }

                    if (!includesLinks[parentMemberName].Contains("*") && !isMemberInLinks)
                    {
                        continue;
                    }
                }
                if (excludesLinks != null)
                {
                    bool isTypeInLinks = excludesLinks.ContainsKey(parentMemberName);
                    bool isMemberInLinks = isTypeInLinks && excludesLinks[parentMemberName].Contains(memberName);

                    if (isTypeInLinks && isMemberInLinks)
                    {
                        continue;
                    }
                }

                if (filter != null && filter(memberValue, root, memberName, context))
                {
                    continue;
                }
                #endregion filters

                if (memberValue is JValue)
                {
                    if (todoOnLeaf != null)
                    {
                        todoOnLeaf((memberValue as JValue).Value, root, memberName, context);
                    }
                    continue;
                }

                if (memberValue is JObject)
                {
                    ForEachExpandoRecursive(memberValue as JObject, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, filter, context, root, memberName);
                }
                else if (memberValue is JArray)
                {
                    if (todoAtBegin != null)
                    {
                        todoAtBegin(memberValue, root, memberName, context);
                    }
                    IEnumerable list = memberValue as IEnumerable;
                    int index = 0;
                    foreach (object item in list)
                    {
                        ForEachExpandoRecursive(item as JObject, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, filter, context, root,$"[{index}]");
                        index++;
                    }
                    if (todoAtEnd != null)
                    {
                        todoAtEnd(memberValue, root, memberName, context);
                    }
                }
            }
            if (todoAtEnd != null)
            {
                todoAtEnd(root, parent, parentMemberName, context);
            }
        }

        public static void ForEachMemberRecursive(object root, Dictionary<Type, HashSet<string>> includesLinks, Dictionary<Type, HashSet<string>> excludesLinks,  ForEachRecursiveBoolDelegate todoAtBegin, ForEachRecursiveDelegate todoOnLeaf, ForEachRecursiveDelegate todoAtEnd, ForEachRecursiveBoolDelegate keep=null, object context = null, Dictionary<Type,List<MemberInfo>> cache= null, object parent =null, MemberInfo parentRootInfo =null, HashSet<int> loopAvoider=null )
        {                       
            bool goDeeper = true;
            if (todoAtBegin!=null)
            {
                goDeeper=todoAtBegin(root, parent, parentRootInfo, context);
            }


            if (root == null || IsPrimitiveType(root.GetType()) || !goDeeper)
            {
                if (todoOnLeaf != null)
                {
                    todoOnLeaf(root, parent, parentRootInfo, context);
                }

                if (todoAtEnd != null)
                {
                    todoAtEnd(root, parent, parentRootInfo, context);
                }
                return;
            }

            IEnumerable list = root as IEnumerable;
            if (list != null)
            {
                foreach (object item in list)
                {
                    ForEachMemberRecursive(item, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, keep, context, cache, root, null, loopAvoider);
                }
                if (todoAtEnd != null)
                {
                    todoAtEnd(root, parent, parentRootInfo, context);
                }
                return;
            }

            if (cache == null)
                cache = new Dictionary<Type, List<MemberInfo>>(); 

            List<MemberInfo> members = null;

            Type rootType = root.GetType();

            if (cache.ContainsKey(rootType))
                members = cache[rootType];
            else
            {
                members = GetPropertiesAndFields(rootType);
                cache.Add(rootType, members);
            }

            foreach (var member in members)
            {
                Type memberType = GetMemberType(member);

                // neither a property or a field (method or other)
                if (memberType == null)
                {
                    continue;
                }
                object memberValue = GetMemberValue(root, member);

                #region filters
                if (includesLinks != null)
                {
                    bool isTypeInLinks = includesLinks.ContainsKey(rootType);
                    bool isMemberInLinks = isTypeInLinks && includesLinks[rootType].Contains(member.Name);

                    if (!isTypeInLinks)
                    {
                        continue;
                    }

                    if (!includesLinks[rootType].Contains("*") && !isMemberInLinks)
                    {
                        continue;
                    }
                }
                if (excludesLinks != null)
                {
                    bool isTypeInLinks = excludesLinks.ContainsKey(rootType);
                    bool isMemberInLinks = isTypeInLinks && excludesLinks[rootType].Contains(member.Name);

                    if (isTypeInLinks && isMemberInLinks)
                    {
                        continue;
                    }
                }

                if (keep != null && !keep(memberValue, root, member, context))
                {
                    continue;
                }
                #endregion filters
                
                ForEachMemberRecursive(memberValue, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, keep, context, cache, root, member,loopAvoider);                
            }
            if (todoAtEnd!=null)
            {
                todoAtEnd(root, parent,parentRootInfo, context);
            }
        }


        public static bool IsPrimitiveType(Type objType)
        {
            return !objType.IsByRef;// objType.IsPrimitive|| objType.IsEnum || objType == typeof(Decimal) || objType == typeof(String) || objType == typeof(DateTime);
        }
        public static bool IsArrayType(Type objType)
        {
            return objType.IsArray;//typeof(IEnumerable).IsAssignableFrom(objType);
        }

        public static List<T> RetrieveObjectsRecursively<T>(object root, List<Type> typesToGoThrough)
        {
            var result = new List<T>();
            if (root is T)
            {
                result.Add((T)root);
            }

            foreach (MemberInfo member in GetPropertiesAndFields(root.GetType()))
            {
                Type memberType=GetMemberType(member);
                if(memberType==null)
                {
                    continue;
                }
                if (typesToGoThrough.Contains(memberType))
                {
                    result.AddRange(RetrieveObjectsRecursively<T>(ObjectTools.GetMemberValue(root, member),  typesToGoThrough));
                }
                else if (memberType.IsConstructedGenericType && typesToGoThrough.Contains(memberType.GenericTypeArguments[0]))
                {
                    IEnumerable list = ObjectTools.GetMemberValue(root, member) as IEnumerable;
                    if (list != null)
                    {
                        foreach (object item in list)
                        {
                            result.AddRange(RetrieveObjectsRecursively<T>(item,  typesToGoThrough));
                        }
                    }
                }
            }
            return result;
        }
       
        #endregion object explorer tools

        #region Field and Properties tools

        public static List<MemberInfo> GetPropertiesAndFields(Type typeToSearchIn)
        {
            List<MemberInfo> result = new List<MemberInfo>(typeToSearchIn.GetRuntimeProperties());
            result.AddRange(typeToSearchIn.GetRuntimeFields());
            return result;
        }

        public static Type GetMemberType(MemberInfo FieldOrProperty)
        {
            if (FieldOrProperty is PropertyInfo)
                return ((PropertyInfo)FieldOrProperty).PropertyType;
            else if (FieldOrProperty is FieldInfo)
                return ((FieldInfo)FieldOrProperty).FieldType;
            else
                return null;
        }

        public static void CopyValues(object source, object destination)
        {
            CopyValues(source, destination, null);
        }

        public static void CopyValues(object source, object destination, List<string> excludedProperties)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            List<MemberInfo> sourceMembers = GetPropertiesAndFields(sourceType);
            List<MemberInfo> destMembers = GetPropertiesAndFields(destinationType);

            foreach (var member in destMembers)
            {
                if ( (excludedProperties == null) || (!excludedProperties.Contains(member.Name)))
                {
                    var commonSourceMember = sourceMembers.FirstOrDefault(m => m.Name.ToLower() == member.Name.ToLower());
                    if (commonSourceMember != null)
                    {
                        try
                        {
                            object value = GetMemberValue(source, commonSourceMember);
                            SetMemberValue(destination, member, value);
                        }
                        catch (ArgumentException ex)
                        {
                            //can happen when property has no set{} defined
                            Console.WriteLine(ex.Message);
                        }
                        catch
                        {
                            
                        }
                    }
                }
            }
        }

        public static object GetMemberValuePath(object sourceObject, string PropPath)
        {
            var propertiesChain = PropPath.Split('.');
            var currentObject = sourceObject;
            foreach (var propertyName in propertiesChain)
            {
                currentObject = GetMemberValue(currentObject, propertyName);
                if (currentObject == null)
                {
                    return null;
                }
            }
            return currentObject;
        }

        public static object GetMemberValue(object sourceObject, string PropName)
        {
            if (sourceObject == null)
                return null;
            MemberInfo prop = sourceObject.GetType().GetRuntimeField(PropName);
            if(prop==null)
                prop = sourceObject.GetType().GetRuntimeProperty(PropName);
            return GetMemberValue(sourceObject, prop);
        }

        public static bool HasMember(Type type, string propertyOrFieldName)
        {
               return type.GetRuntimeField(propertyOrFieldName) == null && type.GetType().GetRuntimeProperty(propertyOrFieldName) == null;
        }

        public static object GetMemberValue(object sourceObject, MemberInfo member)
        {
            if (sourceObject == null)
                return null;
            if (member is PropertyInfo)
            {
                PropertyInfo prop = member as PropertyInfo;
                if (prop == null)
                    return null;
                return prop.GetValue(sourceObject, null);
            }
            else
            {
                FieldInfo prop = member as FieldInfo;
                if (prop == null)
                    return null;
                return prop.GetValue(sourceObject);
            }
        }
        public static void SetMemberValue(object destinationObject, string memberName, object value, bool tryConvert=false)
        {
            MemberInfo member = destinationObject.GetType().GetRuntimeField(memberName);
            if(member== null)
                member= destinationObject.GetType().GetRuntimeProperty(memberName);
            SetMemberValue(destinationObject, member, value, tryConvert);
        }
        public static void SetMemberValue(object destinationObject, MemberInfo member, object value, bool tryConvert = false)
        {
            if (destinationObject == null)
                return;
            if (member is PropertyInfo)
            {
                PropertyInfo prop = member as PropertyInfo;
                if (prop == null)
                    return;
                if (prop.CanWrite)
                {
                    if (tryConvert && value.GetType() != prop.PropertyType)
                    {
                        value = Convert.ChangeType(value, prop.PropertyType);
                    }
                    prop.SetValue(destinationObject, value, null);
                }
            }
            else
            {
                FieldInfo prop = member as FieldInfo;
                if (prop == null)
                    return;
                if(tryConvert && value.GetType()!= prop.FieldType)
                {
                    value = Convert.ChangeType(value, prop.FieldType);
                }
                prop.SetValue(destinationObject, value);
            }
        }

        public static void SetMemberValuePath(object sourceObject, string PropPath, object value)
        {
            var propertiesChain = PropPath.Split('.');
            var currentObject = sourceObject;
            for (int i=0;i<propertiesChain.Count()-1;i++)
            {
                var propertyString = propertiesChain[i];
                int index = 0;
                string propertyName = propertyString;
                bool isArrayProperty = propertyName.EndsWith("]");
                if (isArrayProperty)
                {
                    var values = propertyName.Split(new char[] { '[', ']' },StringSplitOptions.RemoveEmptyEntries);
                    propertyName = values.First();
                    index = int.Parse(values.Last());
                }
                currentObject = GetMemberValue(currentObject, propertyName);
                if (currentObject == null)
                {
                    throw new Exception("property path " + PropPath + " not found");
                }
                if(isArrayProperty && currentObject as ICollection != null)
                {
                    var enumerator = (currentObject as ICollection).GetEnumerator();
                    for (int j = 0; j <= index; j++)
                        enumerator.MoveNext();
                    currentObject = enumerator.Current;
                }
            }
            SetMemberValue(currentObject, propertiesChain.Last(), value,true);
        }
        #endregion Field and Properties tools
    }

}
