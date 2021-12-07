using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Mag2_Extensions
{
    public static class SessionExtension //расширение
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));//json (возвращает код json в виде строки)(процесс перевода структуры данных в последовательность битов)
        }
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);// ??? (десериализует строку json в объект типа T и возвращает его(Процесс преобразования сериализованных данных в структуру данных.))
        }
    }
}
