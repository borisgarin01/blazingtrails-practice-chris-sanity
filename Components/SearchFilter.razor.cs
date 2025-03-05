using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Components;

public partial class SearchFilter
{
    private int maxLength;
    private int maxTime;

    [Parameter, EditorRequired]
    public string SearchTerm { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public int? MaxLength { get; set; }

    [Parameter]
    public int? MaxTime { get; set; }

    protected override void OnInitialized()
    {
        maxLength = MaxLength ?? 0;
        maxTime = MaxTime ?? 0;
    }

    public void FilterSearchResults()
    {
        var uriWithQueryString = NavigationManager.GetUriWithQueryParameters(new Dictionary<string, object?>()
        {
            [nameof(SearchPage.MaxLength)] = MaxLength == 0 ? null : MaxLength,
            [nameof(SearchPage.MaxTime)] = MaxTime == 0 ? null : MaxTime
        });

        NavigationManager.NavigateTo(uriWithQueryString);
    }

    public void ClearSearchFilter()
    {
        maxLength = 0;
        NavigationManager.NavigateTo($"/search/{SearchTerm}");
    }
}
