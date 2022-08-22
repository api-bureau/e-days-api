using Edays.Core;

namespace Edays;

public class EdaysClient
{
    public AbsenceEndpoint Absences { get; }
    public AbsenceTypeEndpoint AbsenceTypes { get; }
    public UserEndpoint Users { get; }
    public RotaV1Endpoint RotaV1Endpoint { get; }

    public EdaysClient(EdaysHttpFacade client)
    {
        Absences = new AbsenceEndpoint(client);
        AbsenceTypes = new AbsenceTypeEndpoint(client);
        Users = new UserEndpoint(client);
        RotaV1Endpoint = new RotaV1Endpoint(client);
    }
}
