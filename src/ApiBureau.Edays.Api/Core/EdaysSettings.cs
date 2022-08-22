namespace ApiBureau.Edays.Api.Core;

public class EdaysSettings
{
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;

    /// <summary>
    /// Username for v1 API.
    /// </summary>
    public string? ApiUserNameVersion1 { get; set; }

    /// <summary>
    /// Password/Key for v1 API.
    /// </summary>
    public string? ApiKeyVersion1 { get; set; }

    /// <summary>
    /// Base url for v1 API.
    /// </summary>
    public string? BaseAddressVersion1 { get; set; }

    public Uri TokenUri { get; set; } = null!;
    public Uri BaseAddress { get; set; } = null!;
    public bool Enabled { get; set; }
}
