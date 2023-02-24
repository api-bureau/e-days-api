namespace ApiBureau.Edays.Api.Endpoints;

public class BaseEndpoint
{
    protected ApiConnection ApiConnection { get; }

    public BaseEndpoint(ApiConnection apiConnection) => ApiConnection = apiConnection;
}