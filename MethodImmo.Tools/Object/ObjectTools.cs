using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections;

namespace Mid.Tools
{
    public delegate void ForEachRecursiveDelegate(object currentMemberValue, object parent, MemberInfo memberInfo,object context);
    public delegate bool ForEachRecursiveFilterDelegate(object currentMemberValue, object parent, MemberInfo memberInfo, object context);
    public delegate object ForEachRecursiveConverterDelegate(object currentMemberValue, object parent, MemberInfo memberInfo, object context);

    public delegate void ForEachExpandoRecursiveDelegate(object currentMemberValue, object parent, string parentMemberName, object context);
    public delegate bool ForEachExpandoRecursiveFilterDelegate(object currentMemberValue, object parent, string parentMemberName, object context);

    public class ObjectTools:IObjectTools
    {
        #region object explorer tools


        public static void ForEachExpandoRecursive(dynamic root, Dictionary<string, HashSet<string>> includesLinks, Dictionary<string, HashSet<string>> excludesLinks, ForEachExpandoRecursiveDelegate todoAtBegin, ForEachExpandoRecursiveDelegate todoOnLeaf, ForEachExpandoRecursiveDelegate todoAtEnd, ForEachExpandoRecursiveFilterDelegate filter = null, object context = null, object parent = null, string parentMemberName = null)
        {
            if (root == null || IsPrimitiveType(root.GetType()))
            {
                if (todoOnLeaf != null)
                {
                    todoOnLeaf(root, parent, parentMemberName, context);
                }
                return;
            }

            if (todoAtBegin != null)
            {
                todoAtBegin(root, parent, parentMemberName, context);
            }

            var membersKeyPairs = root as IDictionary<string, object>;

            foreach (var memberKeyPair in membersKeyPairs)
            {
                object memberValue = memberKeyPair.Value;
                Type memberType = memberValue.GetType();
                string memberName = memberKeyPair.Key;

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

                if (IsPrimitiveType(memberType))
                {
                    if (todoOnLeaf != null)
                    {
                        todoOnLeaf(memberValue, root, memberName, context);
                    }
                    continue;
                }

                if (!IsArrayType(memberType))
                {
                    ForEachExpandoRecursive(memberValue, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, filter, context, root, memberName);
                }
                else
                {
                    if (todoAtBegin != null)
                    {
                        todoAtBegin(memberValue, root, memberName, context);
                    }
                    IEnumerable list = memberValue as IEnumerable;

                    foreach (object item in list)
                    {
                        ForEachExpandoRecursive(item, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, filter, context, root, null);
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

        public static void ForEachMemberRecursive(object root, Dictionary<Type, HashSet<string>> includesLinks, Dictionary<Type, HashSet<string>> excludesLinks,  ForEachRecursiveDelegate todoAtBegin, ForEachRecursiveDelegate todoOnLeaf, ForEachRecursiveDelegate todoAtEnd, ForEachRecursiveFilterDelegate filter=null, object context = null, Dictionary<Type,List<MemberInfo>> cache= null, object parent =null, MemberInfo parentRootInfo =null )
        {

            if (root == null || IsPrimitiveType(root.GetType()))
            {
                if (todoOnLeaf != null)
                {
                    todoOnLeaf(root,parent, parentRootInfo, context);
                }
                return;
            }
            
            if (todoAtBegin!=null)
            {
                todoAtBegin(root, parent, parentRootInfo, context);
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

                object memberValue = GetMemberValue(root, member);

                if (filter != null && filter(memberValue, root, member, context))
                {
                    continue;
                }
                #endregion filters

                if (IsPrimitiveType(memberType))
                {
                    if (todoOnLeaf != null)
                    {
                        todoOnLeaf(memberValue, root, member, context);
                    }
                    continue;
                }

                //member is a complex type

                if (!IsArrayType(memberType))
                {
                    ForEachMemberRecursive(memberValue, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, filter, context, cache, root, member);
                }
                else
                {
                    if (todoAtBegin != null)
                    {
                        todoAtBegin(memberValue, root, member, context);
                    }
                    IEnumerable list = memberValue as IEnumerable;

                    foreach (object item in list)
                    {
                        ForEachMemberRecursive(item, includesLinks, excludesLinks, todoAtBegin, todoOnLeaf, todoAtEnd, filter, context, cache, root, null);
                    }
                    if (todoAtEnd != null)
                    {
                        todoAtEnd(memberValue, root, member, context);
                    }
                }
            }
            if (todoAtEnd!=null)
            {
                todoAtEnd(root, parent,parentRootInfo, context);
            }
        }


        public static bool IsPrimitiveType(Type objType)
        {
            return objType.IsPrimitive || objType == typeof(Decimal) || objType == typeof(String) || objType == typeof(DateTime);
        }
        public static bool IsArrayType(Type objType)
        {
            return typeof(IEnumerable).IsAssignableFrom(objType);
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
                else if (memberType.IsGenericType && typesToGoThrough.Contains(memberType.GetGenericArguments()[0]))
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
            List<MemberInfo> result = new List<MemberInfo>(typeToSearchIn.GetProperties());
            result.AddRange(typeToSearchIn.GetFields());
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
            MemberInfo prop = sourceObject.GetType().GetMember(PropName).FirstOrDefault();
            return GetMemberValue(sourceObject, prop);
        }

        public static bool HasMember(Type type, string propertyOrFieldName)
        {
            MemberInfo prop = type.GetMember(propertyOrFieldName).FirstOrDefault();
            return prop != null;
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
        public static void SetMemberValue(object destinationObject, string memberName, object value)
        {
            MemberInfo member = destinationObject.GetType().GetMember(memberName).FirstOrDefault();
            SetMemberValue(destinationObject, member, value);
        }
        public static void SetMemberValue(object destinationObject, MemberInfo member, object value)
        {
            if (destinationObject == null)
                return;
            if (member is PropertyInfo)
            {
                PropertyInfo prop = member as PropertyInfo;
                if (prop == null)
                    return;
                if(prop.CanWrite)
                    prop.SetValue(destinationObject, value, null);
            }
            else
            {
                FieldInfo prop = member as FieldInfo;
                if (prop == null)
                    return;
                prop.SetValue(destinationObject, value);
            }
        }
        #endregion Field and Properties tools
    }

}
