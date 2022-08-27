using ApiBureau.Edays.Api.Endpoints;
using ApiBureau.Edays.Api.Http;

namespace ApiBureau.Edays.Api;

public class EdaysClient
{
    public AbsenceEndpoint Absences { get; }
    public AbsenceTypeEndpoint AbsenceTypes { get; }
    public UserEndpoint Users { get; }
    public RotaV1Endpoint RotaV1Endpoint { get; }

    public EdaysClient(ApiConnection client)
    {
        Absences = new AbsenceEndpoint(client);
        AbsenceTypes = new AbsenceTypeEndpoint(client);
        Users = new UserEndpoint(client);
        RotaV1Endpoint = new RotaV1Endpoint(client);
    }
}
