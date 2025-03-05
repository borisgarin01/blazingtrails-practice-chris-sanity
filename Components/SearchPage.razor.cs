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

    [Parameter, SupplyParameterFromQuery]
    public int? MaxLength { get; set; }

    [Parameter, SupplyParameterFromQuery]
    public int? MaxTime { get; set; }

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

    protected override void OnParametersSet() => UpdateFilters();

    private void HandleTrailSelected(Trail trail) =>
        selectedTrail = trail;

    private void UpdateFilters()
    {
        var filters = new List<Func<Trail, bool>>();

        if (MaxLength is not null && MaxLength > 0)
        {
            filters.Add(x => x.Length <= MaxLength);
        }

        if (MaxTime is not null && MaxTime > 0)
        {
            filters.Add(x => x.TimeInMinutes <= MaxTime * 60);
        }

        if (filters.Any())
        {
            searchResults = cachedSearchResults.Where(trail => filters.All(filter => filter(trail)));
        }

        else
        {
            searchResults = cachedSearchResults;
        }

        Console.WriteLine(filters.Count);
    }
}
