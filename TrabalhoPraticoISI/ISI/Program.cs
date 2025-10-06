using System.Globalization;  /* Formatação de datas e números (ex.: ponto como separador decimal) */
using System.Net.Http.Json; /* Ler respostas JSON diretamente para tipos .NET */
using System.Text.Json; /* Serializar objetos para JSON (gravar em ficheiro) */
using System.Xml.Linq; /* Extensões LINQ (Select, Concat, etc.) */
using System.Linq;

static string ObterCaminhoDaSolucao()
{
    var pastaExecutavel = AppContext.BaseDirectory; // Pasta onde o executável está a correr

    var pastaProjeto = Path.GetFullPath(Path.Combine(pastaExecutavel, "..", "..", ".."));  // Pasta do projeto

    var pastaSolucao = Directory.GetParent(pastaProjeto)!.FullName; // Pasta da solução

    return pastaSolucao; // Pasta onde ficam os dados (Entrada/Saida)
}

// Define as pastas de dados (Entrada e Saida)
var pastaDados = ObterCaminhoDaSolucao();
var pastaEntrada = Path.Combine(pastaDados, "Entrada");
var pastaSaida = Path.Combine(pastaDados, "Saida");

// Cria as pastas se não existirem
Directory.CreateDirectory(pastaEntrada);
Directory.CreateDirectory(pastaSaida);

// Caminhos dos ficheiros de entrada
var caminhoCSV = Path.Combine(pastaEntrada, "ficheiro_csv.csv");
var caminhoTXT = Path.Combine(pastaEntrada, "ficheiro_txt.txt");
var caminhoXML = Path.Combine(pastaEntrada, "ficheiro_xml.xml");
var caminhoJSON = Path.Combine(pastaEntrada, "ficheiro_json.json");  
var caminhoAPI = Path.Combine(pastaEntrada, "api_json.json");

Console.WriteLine($"\n\n***** CRIAÇÃO/VERIFICAÇÃO DE PASTAS *****\n\n");
Console.WriteLine($"Entrada: {pastaEntrada}\n");
Console.WriteLine($"Saída: {pastaSaida}\n");

//*************************************************************************************************
//*************************************************************************************************

Console.WriteLine($"\n\n***** CRIAÇÃO DOS FICHEIROS *****\n\n");

//*************************************************************************************************
//*************************************************************************************************

// Criação de um ficheiro CSV

var guardarDadosCSV =

"data_hora,local,temp_c,humidade_per,vento_kmh,lat_c,long_c\n" +
"01-10-2025 00:00,Aveiro,10.1,10,10.1,10.10,-38,40\n" +
"01-10-2025 01:00,Beja,11.2,11,11.2,11.20,-26.70\n" +
"01-10-2025 02:00,Braga,12.3,12,12.3,12.30,-25.60\n" +
"02-10-2025 03:00,Braganca,13.4,13,13.4,13.40,-24.50\n" +
"02-10-2025 04:00,C.Branco,14.5,14,14.5,14.50,-23.40\n" +
"02-10-2025 05:00,Coimbra,15.6,15,15.6,15.60,-22.30\n" +
"03-10-2025 06:00,Evora,16.7,16,16.7,16.70,-21.20\n" +
"03-10-2025 07:00,Faro,17.8,17,17.8,17.80,-20.10\n" +
"03-10-2025 08:00,Guarda,18.9,18,18.9,18.90,-19.00\n" +
"04-10-2025 09:00,Leiria,19.0,19,19.0,19.00,-18.90\n" +
"04-10-2025 10:00,Lisboa,20.1,20,20.1,20.10,-17.80\n" +
"04-10-2025 11:00,Portalegre,21.2,21,21.2,21.20,-16.70\n" +
"05-10-2025 12:00,Porto,22.3,22,22.3,22.30,-15.60\n" +
"05-10-2025 13:00,Santarem,23.4,23,23.4,23.40,-14.50\n" +
"05-10-2025 14:00,Setubal,24.5,24,24.5,24.50,-13.40\n" +
"06-10-2025 15:00,V.Castelo,25.6,25,25.6,25.60,-12.30\n" +
"06-10-2025 16:00,V.Real,26.7,26,26.7,26.70,-11.20\n" +
"06-10-2025 17:00,Viseu,27.8,27,27.8,27.80,-10.10";

File.WriteAllText(caminhoCSV, guardarDadosCSV);

Console.WriteLine($" -- CSV: {caminhoCSV}\n");

//*************************************************************************************************
//*************************************************************************************************

// Criação de um ficheiro TXT

var guardarDadosTXT =

"data_hora,local,temp_c,humidade_per,vento_kmh,lat_c,long_c\n" +
"01-10-2025 00:00,Aveiro,10.1,10,10.1,10.10,-38,40\n" +
"01-10-2025 01:00,Beja,11.2,11,11.2,11.20,-26.70\n" +
"01-10-2025 02:00,Braga,12.3,12,12.3,12.30,-25.60\n" +
"02-10-2025 03:00,Braganca,13.4,13,13.4,13.40,-24.50\n" +
"02-10-2025 04:00,C.Branco,14.5,14,14.5,14.50,-23.40\n" +
"02-10-2025 05:00,Coimbra,15.6,15,15.6,15.60,-22.30\n" +
"03-10-2025 06:00,Evora,16.7,16,16.7,16.70,-21.20\n" +
"03-10-2025 07:00,Faro,17.8,17,17.8,17.80,-20.10\n" +
"03-10-2025 08:00,Guarda,18.9,18,18.9,18.90,-19.00\n" +
"04-10-2025 09:00,Leiria,19.0,19,19.0,19.00,-18.90\n" +
"04-10-2025 10:00,Lisboa,20.1,20,20.1,20.10,-17.80\n" +
"04-10-2025 11:00,Portalegre,21.2,21,21.2,21.20,-16.70\n" +
"05-10-2025 12:00,Porto,22.3,22,22.3,22.30,-15.60\n" +
"05-10-2025 13:00,Santarem,23.4,23,23.4,23.40,-14.50\n" +
"05-10-2025 14:00,Setubal,24.5,24,24.5,24.50,-13.40\n" +
"06-10-2025 15:00,V.Castelo,25.6,25,25.6,25.60,-12.30\n" +
"06-10-2025 16:00,V.Real,26.7,26,26.7,26.70,-11.20\n" +
"06-10-2025 17:00,Viseu,27.8,27,27.8,27.80,-10.10";

File.WriteAllText(caminhoTXT, guardarDadosTXT);

Console.WriteLine($" -- TXT: {caminhoTXT}\n");

//*************************************************************************************************
//*************************************************************************************************

// Criação de um ficheiro XML:

var medicoes = new[]
{
    new { data_hora = "01-10-2025 18:00", local = "Aveiro",     temp_c = 10.1,  humidade_per = 81,  vento_kmh = 11.5,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "01-10-2025 17:00", local = "Beja",       temp_c = 15.9,  humidade_per = 82,  vento_kmh = 10.6,  lat_c = 41.55,  long_c = -8.43 },
    new { data_hora = "01-10-2025 16:00", local = "Braga",      temp_c = 16.5,  humidade_per = 83,  vento_kmh = 11.7,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "02-10-2025 15:00", local = "Braganca",   temp_c = 19.5,  humidade_per = 84,  vento_kmh = 11.8,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "02-10-2025 14:00", local = "C.Branco",   temp_c = 15.1,  humidade_per = 85,  vento_kmh = 11.9,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "02-10-2025 13:00", local = "Coimbra",    temp_c = 13.2,  humidade_per = 86,  vento_kmh = 11.0,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "03-10-2025 12:00", local = "Evora",      temp_c = 22.5,  humidade_per = 87,  vento_kmh = 11.1,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "03-10-2025 11:00", local = "Faro",       temp_c = 27.1,  humidade_per = 81,  vento_kmh = 11.2,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "03-10-2025 10:00", local = "Guarda",     temp_c = 29.8,  humidade_per = 88,  vento_kmh = 11.3,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "04-10-2025 09:00", local = "Leiria",     temp_c = 32.7,  humidade_per = 89,  vento_kmh = 11.4,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "04-10-2025 08:00", local = "Lisboa",     temp_c = 9.5,   humidade_per = 90,  vento_kmh = 11.5,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "04-10-2025 07:00", local = "Portalegre", temp_c = 37.1,  humidade_per = 91,  vento_kmh = 11.6,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "05-10-2025 06:00", local = "Porto",      temp_c = 25.4,  humidade_per = 37,  vento_kmh = 11.7,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "05-10-2025 05:00", local = "Santarem",   temp_c = 32.5,  humidade_per = 38,  vento_kmh = 11.8,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "05-10-2025 04:00", local = "Setubal",    temp_c = 39.5,  humidade_per = 39,  vento_kmh = 11.9,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "06-10-2025 03:00", local = "V.Castelo",  temp_c = 20.1,  humidade_per = 40,  vento_kmh = 11.0,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "06-10-2025 02:00", local = "V.Real",     temp_c = 30.5,  humidade_per = 41,  vento_kmh = 11.1,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "06-10-2025 01:00", local = "Viseu",      temp_c = 39.2,  humidade_per = 42,  vento_kmh = 11.2,  lat_c = 41.15,  long_c = -8.61 }
};

var guardarDadosXML = new XDocument(
    new XElement("medicoes",
        medicoes.Select(m => new XElement("medicao",
            new XElement("data_hora", m.data_hora),
            new XElement("local", m.local),
            new XElement("temp_c", m.temp_c),
            new XElement("humidade_per", m.humidade_per),
            new XElement("vento_kmh", m.vento_kmh),
            new XElement("lat_c", m.lat_c),
            new XElement("long_c", m.long_c)
        ))
    )
);

guardarDadosXML.Save(caminhoXML);

Console.WriteLine($" -- XML: {caminhoXML}\n");

//*************************************************************************************************
//*************************************************************************************************

// Criação de um ficheiro JSON:

var guardarDadosJSON = new
{    
    medicoes = new[] {
    new { data_hora = "01-10-2025 18:00", local = "Aveiro",     temp_c = 10.1,  humidade_per = 81,  vento_kmh = 11.5,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "01-10-2025 17:00", local = "Beja",       temp_c = 15.9,  humidade_per = 82,  vento_kmh = 10.6,  lat_c = 41.55,  long_c = -8.43 },
    new { data_hora = "01-10-2025 16:00", local = "Braga",      temp_c = 16.5,  humidade_per = 83,  vento_kmh = 11.7,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "02-10-2025 15:00", local = "Braganca",   temp_c = 19.5,  humidade_per = 84,  vento_kmh = 11.8,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "02-10-2025 14:00", local = "C.Branco",   temp_c = 15.1,  humidade_per = 85,  vento_kmh = 11.9,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "02-10-2025 13:00", local = "Coimbra",    temp_c = 13.2,  humidade_per = 86,  vento_kmh = 11.0,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "03-10-2025 12:00", local = "Evora",      temp_c = 22.5,  humidade_per = 87,  vento_kmh = 11.1,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "03-10-2025 11:00", local = "Faro",       temp_c = 27.1,  humidade_per = 81,  vento_kmh = 11.2,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "03-10-2025 10:00", local = "Guarda",     temp_c = 29.8,  humidade_per = 88,  vento_kmh = 11.3,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "04-10-2025 09:00", local = "Leiria",     temp_c = 32.7,  humidade_per = 89,  vento_kmh = 11.4,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "04-10-2025 08:00", local = "Lisboa",     temp_c = 9.5,   humidade_per = 90,  vento_kmh = 11.5,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "04-10-2025 07:00", local = "Portalegre", temp_c = 37.1,  humidade_per = 91,  vento_kmh = 11.6,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "05-10-2025 06:00", local = "Porto",      temp_c = 25.4,  humidade_per = 37,  vento_kmh = 11.7,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "05-10-2025 05:00", local = "Santarem",   temp_c = 32.5,  humidade_per = 38,  vento_kmh = 11.8,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "05-10-2025 04:00", local = "Setubal",    temp_c = 39.5,  humidade_per = 39,  vento_kmh = 11.9,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "06-10-2025 03:00", local = "V.Castelo",  temp_c = 20.1,  humidade_per = 40,  vento_kmh = 11.0,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "06-10-2025 02:00", local = "V.Real",     temp_c = 30.5,  humidade_per = 41,  vento_kmh = 11.1,  lat_c = 41.15,  long_c = -8.61 },
    new { data_hora = "06-10-2025 01:00", local = "Viseu",      temp_c = 39.2,  humidade_per = 42,  vento_kmh = 11.2,  lat_c = 41.15,  long_c = -8.61 }
  }
};

File.WriteAllText(caminhoJSON, JsonSerializer.Serialize(guardarDadosJSON, new JsonSerializerOptions { WriteIndented = true }));

Console.WriteLine($" -- JSON: {caminhoJSON}\n");

//*************************************************************************************************
//*************************************************************************************************

// Criação de um ficheiro JSON a partir da API Open-Meteo:

// ---------------------------------------------------------------------------
// 1) Função assíncrona (pode pausar a sua execução) que chama a Open-Meteo e normaliza os dados
//    Parâmetros:
//      lat, lon  → coordenadas do local
//      local     → nome do local (ex.: "Porto")
//      maxHoras  → nº de registos horários a recolher (default = 6)
//    Retorna: lista de objetos anónimos já no formato do teu projeto
// ---------------------------------------------------------------------------

static async Task<List<dynamic>> ObterDadosMeteoAsync(double lat, double lon, string local, int maxHoras = 6)
{
    // HttpClient para fazer pedidos HTTP (usa 'using' para libertar recursos)
    using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };

    // URL da Open-Meteo:
    // - hourly = variáveis horárias que queremos
    // - timezone=UTC para facilitar comparações entre fontes
    // - forecast_days=1 chega para obter horas do dia corrente
    var url = $"https://api.open-meteo.com/v1/forecast?" +
              $"latitude={lat.ToString(CultureInfo.InvariantCulture)}" +
              $"&longitude={lon.ToString(CultureInfo.InvariantCulture)}" +
              $"&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m" +
              $"&windspeed_unit=kmh" + // garante que o vento vem em km/h
              $"&timezone=UTC&forecast_days=1";

    // Faz o pedido e lê diretamente para um JsonElement (árvore JSON navegável)
    var doc = await http.GetFromJsonAsync<JsonElement>(url);

    // A secção "hourly" contém arrays paralelos (time, temperature_2m, etc.)
    var hourly = doc.GetProperty("hourly");

    // Extrai os arrays da resposta (listas paralelas por índice)
    var tempos = hourly.GetProperty("time").EnumerateArray().Select(x => x.GetString()!).ToList();
    var temperaturas = hourly.GetProperty("temperature_2m").EnumerateArray().Select(x => x.GetDouble()).ToList();
    var humidades = hourly.GetProperty("relative_humidity_2m").EnumerateArray().Select(x => (double?)x.GetInt32()).ToList();
    var ventos = hourly.GetProperty("wind_speed_10m").EnumerateArray().Select(x => x.GetDouble()).ToList();

    // Criação da lista final com o mesmo formato que os outros ficheiros
    var lista = new List<dynamic>();

    // Limita ao nº de horas pedido (maxHoras) e evita "out of range"
    for (int i = 0; i < Math.Min(maxHoras, tempos.Count); i++)
    {
        var dt = DateTime.Parse(tempos[i], null, DateTimeStyles.AdjustToUniversal);

        // Adiciona um registo com os nomes de campos NORMALIZADOS
        lista.Add(new
        {
            data_hora = dt.ToString("dd-MM-yyyy HH:mm"),
            local = local,
            temp_c = Math.Round(temperaturas[i], 1), // arredonda a 1 casa decimal
            humidade_per = humidades[i], // já é %
            vento_kmh = Math.Round(ventos[i], 1), // arredonda a 1 casa decimal
            lat_c = lat,
            long_c = lon
        });
    }
    return lista; // pronto para serializar em JSON/CSV/XML
}

// ---------------------------------------------------------------------------
// 2) Recolha de dados de múltiplos locais (ex.: Porto e Braga)
//    → podes adicionar mais chamadas para outras cidades facilmente
// ---------------------------------------------------------------------------
var porto = await ObterDadosMeteoAsync(41.14, -8.61, "Porto");
var braga = await ObterDadosMeteoAsync(41.55, -8.43, "Braga");

// Junta todas as medições num único conjunto
var dadosAPI = new
{
    source = "open-meteo",
    medicoes = porto.Concat(braga).ToList()
};

// Guarda o ficheiro formatado (indentado para leitura fácil)
await File.WriteAllTextAsync(
    caminhoAPI,
    JsonSerializer.Serialize(dadosAPI, new JsonSerializerOptions { WriteIndented = true })
);

Console.WriteLine($" -- JSON: {caminhoAPI}\n");

/* Mensagem final */
Console.WriteLine("Todos os ficheiros foram criados com sucesso (CSV, TXT, XML, JSON e JSON da API).");