using BlazorWasm1.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorWasm1.Components;

public partial class SearchPage
{
    [Inject]
    public HttpClient HttpClient { get; set; }

    [Parameter]
    public string SearchTerm { get; set; } = default!;

    [Parameter]
    public int? MaxLength { get; set; }

    private IEnumerable<Trail>? searchResults;
    private Trail? selectedTrail;

    private IEnumerable<Trail> cachedSearchResults = Array.Empty<Trail>();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var allTrails = await HttpClient.GetFromJsonAsync<IEnumerable<Trail>>("trails/trail-data.json");
            searchResults = allTrails!.Where(x => x.Name.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase) || x.Location.Contains(SearchTerm, StringComparison.CurrentCultureIgnoreCase));
            cachedSearchResults = searchResults;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"There was a problem loading trail data: {ex.Message}");
        }
    }

    protected override void OnParametersSet()
    {
        if (cachedSearchResults.Any() && MaxLength.HasValue)
        {
            searchResults = cachedSearchResults
                .Where(x => x.Length <= MaxLength.Value);
        }
        else if (cachedSearchResults.Any() && MaxLength is null)
        {
            searchResults = cachedSearchResults;
        }
    }

    private void HandleTrailSelected(Trail trail) =>
        selectedTrail = trail;
}
