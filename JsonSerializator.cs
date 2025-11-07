using System.Text;

namespace AppConsole
{
    class JsonSerializator<T> : ISerializable<T> where T : new()
    {
        public string Serialize(T obj)
        {
            StringBuilder json = new StringBuilder();

            var props = obj.GetType().GetProperties().ToList();

            json.Append(obj.GetType().Name.ToLower() + ":{");
            json.Append("properties:{");

            for (int i = 0; i < props.Count; i++)
            {

                var propInfo = props[i];

                json.Append($"{propInfo.Name.ToLower()}:{propInfo.GetValue(obj)}");
                json.Append("}");          
                if (i != props.Count - 1)
                {
                    json.Append(",");
                    json.Append("{");
                }
            }

            json.Append("}");

            return json.ToString();
        }

        public T Deserialize(string obj)
        {
            string propsKeyJson = obj.Substring(obj.IndexOf("properties"));
            string propsValues = propsKeyJson.Substring(propsKeyJson.IndexOf("{")).Replace("{" , "").Replace("}" , "");
            string[] KeysAndValuesArray = propsValues.Split(",");

            List<string> values = new();

            foreach (string pair in KeysAndValuesArray)
            {
                values.Add(pair.Split(":")[1]);
            }

            T obj1 = new T();

            for (int i = 0; i < obj1.GetType().GetProperties().Count(); i++)
            {
                obj1.GetType().GetProperties()[i].SetValue(obj1, values[i]);
            }

            return obj1;
        }
    }
}