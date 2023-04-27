using ApiBureau.Edays.Api.Endpoints;

namespace ApiBureau.Edays.Api;

public class EdaysClient
{
    public AbsenceEndpoint Absences { get; }
    public AbsenceTypeEndpoint AbsenceTypes { get; }
    public UserEndpoint Users { get; }
    public RotaV1Endpoint RotaV1Endpoint { get; }

    public EdaysClient(HttpClient client, IOptions<EdaysSettings> settings, ILogger<ApiConnection> logger)
    {
        var apiConnection = new ApiConnection(client, settings, logger);

        Absences = new AbsenceEndpoint(apiConnection);
        AbsenceTypes = new AbsenceTypeEndpoint(apiConnection);
        Users = new UserEndpoint(apiConnection);
        RotaV1Endpoint = new RotaV1Endpoint(apiConnection);
    }
}