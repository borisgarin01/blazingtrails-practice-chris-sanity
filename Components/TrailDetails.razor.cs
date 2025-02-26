using BlazorWasm1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Components;

public partial class TrailDetails
{
    private bool isOpen;
    private Trail? activeTrail;

    [Parameter, EditorRequired]
    public Trail? Trail { get; set; }

    protected override void OnParametersSet()
    {
        if (Trail is not null)
        {
            activeTrail = Trail;
            isOpen = true;
        }
    }

    private void Close()
    {
        activeTrail = null;
        isOpen = false;
    }
}
