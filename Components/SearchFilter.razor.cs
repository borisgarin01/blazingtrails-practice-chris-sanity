using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Components;

public partial class SearchFilter
{
    private int maxLength;

    [Parameter, EditorRequired]
    public string SearchTerm { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private void FilterSearchResults() => NavigationManager.NavigateTo($"/search/{SearchTerm}/maxlength/{maxLength}");

    private void ClearSearchFilter()
    {
        maxLength = 0;
        NavigationManager.NavigateTo($"/search/{SearchTerm}");
    }
}
