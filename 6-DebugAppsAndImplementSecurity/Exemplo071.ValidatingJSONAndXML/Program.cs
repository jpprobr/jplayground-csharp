using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Exemplo071.ValidatingJSONAndXML
{
    // Exemplo usando as classes System.Text.Json do .NET Core 3.1
    // https://docs.microsoft.com/pt-br/dotnet/standard/serialization/system-text-json-how-to
    class Program
    {
        static void Main(string[] args)
        {
            var weatherForecast = new WeatherForecast(DateTimeOffset.Now, 25, "quente");
            string jsonString = ConverterDeObjetoParaJson(weatherForecast);
            Console.WriteLine("\n jsonString: {0}", jsonString);
            
            Console.WriteLine("\n ValidateJson - sucesso: {0}", ValidarJson(jsonString));

            // Simula problema no json
            //jsonString = jsonString.Replace("}", "");
            //Console.WriteLine("\n ValidateJson - falha: {0}", ValidarJson(jsonString));

            if (ValidarJson(jsonString))
            {
                var obj = (WeatherForecast)ConverterDeJsonParaObjeto(jsonString);
                Console.WriteLine();
                Console.WriteLine("objeto.TemperatureCelsius: {0}", obj.TemperatureCelsius);
                Console.WriteLine("objeto.Summary: {0}", obj.Summary);
            }           
        }

        public static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                    || input.StartsWith("[") && input.EndsWith("]");
        }

        public static bool ValidarJson(string json)
        {
            try
            {
                var result = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erro ao converter json (ArgumentException). \n Desc.: {0}", ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Erro ao converter json (JsonException). \n Desc.: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao converter json (JsonException). \n Desc.: {0}", ex.Message);
            }
            return false;
        }

        public static string ConverterDeObjetoParaJson(object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            return jsonString;
        }

        public static object ConverterDeJsonParaObjeto(string jsonString)
        {
            var result = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
            return result;
        }
    }

    // Classe de exemplo
    public class WeatherForecast
    {
        public WeatherForecast()
        {

        }

        public WeatherForecast(DateTimeOffset date, int temperatureCelsius, string summary)
        {
            Date = date;
            TemperatureCelsius = temperatureCelsius;
            Summary = summary;
        }

        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
}
