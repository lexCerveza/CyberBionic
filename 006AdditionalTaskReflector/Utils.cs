using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _006AdditionalTaskReflector
{
    public class Utils
    {
        public static string GetVarType(string typeName)
        {
            switch (typeName)
            {
                case "Byte":
                    return "byte";
                case "SByte":
                    return "sbyte";
                case "Int16":
                    return "short";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "UInt16":
                    return "ushort";
                case "UInt32":
                    return "uint";
                case "UInt64":
                    return "ulong";
                case "Boolean":
                    return "bool";
                case "Void":
                    return typeName.ToLower();
                case "String":
                    return typeName.ToLower();
                case "Object":
                    return typeName.ToLower();
                default:
                    return typeName;
            }
        }

        public static string ReplacePlaceholders(string str)
        {
            return str.Replace("`4", "<T, Y, X, Z>")
                      .Replace("`3", "<T, Y, X>")
                      .Replace("`2", "<T, Y>")
                      .Replace("`1", "<T>");
        }

        public static string GetAttributes(Type type)
        {
            var attributeInfos = new StringBuilder();
            foreach (var attrInfo in type.GetCustomAttributes())
            {
                var attribute = attrInfo.ToString().Split('.').Last();
                attributeInfos.AppendFormat("[{0}]\n", attribute);
            }
            return attributeInfos.ToString();
        }

        public static string GetClass(Type type)
        {
            var info = new StringBuilder();
            info.Append("public ");
            info.Append(type.IsAbstract ? "abstract " : String.Empty);

            if (type.IsValueType) info.Append(type.IsEnum ? "enum " : "struct ");
            else info.Append(type.IsSealed ? "sealed " : String.Empty);

            info.Append(type.IsClass ? "class " : String.Empty);
            info.Append(type.IsInterface ? "interface " : String.Empty);

            info.Append(ReplacePlaceholders(type.Name));
            return info.ToString();
        }

        private static string GetInterfaces(Type type)
        {
            var interfaceInfos = new StringBuilder();
            var interfaceList = type.GetInterfaces();
            if (interfaceList.Length != 0)
            {
                interfaceInfos.Append(" : ");
                foreach (var interfInfo in interfaceList)
                {
                    interfaceInfos.AppendFormat("{0} ", ReplacePlaceholders(interfInfo.Name));
                    if (!(interfInfo == interfaceList.Last()))
                    {
                        interfaceInfos.Append(", ");
                    }
                }
            }
            interfaceInfos.AppendLine();
            return interfaceInfos.ToString();
        }

        public static string GetPrivateFields(Type type)
        {
            var privateFieldsInfos = new StringBuilder();
            var list = type.GetFields().ToList();
            list.RemoveAll(item => item.IsPublic);
            foreach (var field in list)
            {
                privateFieldsInfos.AppendFormat("\tprivate {0} {1};\n", field.FieldType, field.Name);
            }
            return privateFieldsInfos.ToString();
        }

        public static string GetPublicFields(Type type)
        {
            var publicFieldsInfos = new StringBuilder();
            var list = type.GetFields().ToList();
            list.RemoveAll(item => item.IsPrivate);
            foreach (var field in list)
            {
                publicFieldsInfos.AppendFormat("\tpublic {0} {1}", GetVarType(field.FieldType.Name), field.Name);
            }
            return publicFieldsInfos.ToString();
        }

        public static string GetProperties(Type type)
        {
            var propertyInfos = new StringBuilder();
            foreach (var prop in type.GetProperties())
            {
                if (type.IsClass)
                {
                    propertyInfos.AppendFormat("\tpublic {0} ", prop.Name);
                    propertyInfos.Append("{get; set;}\n");
                }
                else if (type.IsValueType && !type.IsEnum)
                {
                    var returnType = GetVarType(prop.PropertyType.Name);
                    propertyInfos.AppendFormat("\tpublic {0} {1};\n", returnType, prop.Name);
                }
            }
            return propertyInfos.ToString();
        }

        public static string GetConstructors(Type type)
        {
            var constructorInfos = new StringBuilder();
            foreach (var constrInfo in type.GetConstructors())
            {
                constructorInfos.AppendFormat("\tpublic {0} (", ReplacePlaceholders(type.Name));
                foreach (var param in constrInfo.GetParameters())
                {
                    constructorInfos.AppendFormat("{0} {1}", GetVarType(param.ParameterType.Name), param.Name);
                    if(param != constrInfo.GetParameters().Last())
                    {
                        constructorInfos.Append(", ");
                    }
                }
                constructorInfos.AppendLine(")");
            }
            constructorInfos.AppendLine();
            return constructorInfos.ToString();
        }

        public static string GetMethods(Type type)
        {
            var methodInfos = new StringBuilder();
            foreach (var methodInfo in type.GetMethods())
            {
                var returnType = GetVarType(methodInfo.GetBaseDefinition().ReturnType.Name);
                methodInfos.AppendFormat("\tpublic {0} {1} (", returnType, methodInfo.GetBaseDefinition().Name);
                foreach (var param in methodInfo.GetParameters())
                {
                    methodInfos.AppendFormat("{0} {1}", GetVarType(param.ParameterType.Name), param.Name);
                    if (param != methodInfo.GetParameters().Last())
                    {
                        methodInfos.Append(", ");
                    }
                }
                methodInfos.AppendFormat(");\n");
            }
            return methodInfos.ToString();
        }

        public static string GetEvents(Type type)
        {
            var eventInfos = new StringBuilder();
            foreach (var eventInfo in type.GetEvents())
            {
                eventInfos.AppendFormat("\tpublic event {0}\n", eventInfo.Name);
            }
            
            return eventInfos.ToString();
        }
    }
}
