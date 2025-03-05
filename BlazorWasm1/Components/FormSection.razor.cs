using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Components;

public partial class FormSection
{
    [Parameter, EditorRequired]
    public string Title { get; set; } = default!;

    [Parameter, EditorRequired]
    public string HelpText { get; set; } = default!;

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = default!;
}
