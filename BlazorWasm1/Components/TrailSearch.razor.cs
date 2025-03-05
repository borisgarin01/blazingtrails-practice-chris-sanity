using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorWasm1.Components;

public partial class TrailSearch
{
    private string searchTerm = string.Empty;

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private void SearchForTrail(KeyboardEventArgs args)
    {
        if (!string.Equals(args.Key, "Enter"))
            return;

        NavigationManager.NavigateTo($"/search/{searchTerm}");
    }
}
