using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text.Json;

namespace DesafioHandcom.Client
{
    //Criação de uma Autenticação Custom
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localstorage;

        public CustomAuthProvider(ILocalStorageService localstorage)
        {
            _localstorage = localstorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localstorage.GetItemAsStringAsync("token");

            var identity = new ClaimsIdentity();

            if (!string.IsNullOrEmpty(token))
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);


            var claimsList = new List<Claim>();

            foreach (var kvp in keyValuePairs)
            {
                var name = kvp.Key;
                var value = kvp.Value;

                if (value != null || (value is JsonElement element && element.ValueKind != JsonValueKind.Undefined && element.ValueKind != JsonValueKind.Null))
                {
                    if (value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Array)
                    {
                        var claims = jsonElement.EnumerateArray()
                            .Select(x => new Claim(name, x.ToString()));
                        claimsList.AddRange(claims);
                    }
                    else
                    {
                        claimsList.Add(new Claim(name, value.ToString()));
                    }
                }
            }
            return claimsList;
        }
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
