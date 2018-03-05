//////////////////////
// Ramón Guardia López
// Curso 2017-2018
// GameManager.cs
/////////////////////
public static class GameManager
{
    // Clave para la dirección ip
    public const string IP_ADDRESS = "IP_ADDRESS";

    // Variable para almacenar el DNI de un cliente de la Web API
    public static string clientDni;

    // variable para almacenar el nombre del cliente de la web API
    public static string clientName;

    // Variable para almacenar la direccion ip de la web API
    public static string ipAddress;

    // Variable para almacenar el número de entranamiento
    public static int training;

    // Constante con la url del emodo con la web api para comprobar la conectividad
    public const string WEB_API_CHECK_CONNECTIVITY = "http://{0}/SaladilloVR/api/SaladilloVR/CheckConnectivity";

    public const string WEB_API_GET_CLIENTS = "http://{0}/SaladilloVR/api/SaladilloVR/GetClients";

    public const string WEB_API_LOG_CLIENT = "http://{0}/SaladilloVR/api/SaladilloVR/LogClient";

    // Constante con la URL para poder obtener el nombre del cliente cuendo introducimos un DNI
    public const string WEB_API_GET_CLIENT_BY_DNI =
        "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetClientName?dni={1}";

    // Constante con la URL para poder obtener la lista de entrenamientos
    public const string WEB_API_GET_TRAINING_LIST =
        "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining?training={1}";
    // Constante con la que iniciamos un log de entrenamiento en la Web API
    public const string WEB_API_LOG_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/LogTraining";
}