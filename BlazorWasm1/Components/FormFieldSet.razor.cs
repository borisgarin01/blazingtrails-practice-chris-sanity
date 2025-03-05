using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Components;

public partial class FormFieldSet
{
    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = default!;

    [Parameter]
    public string Width { get; set; } = "col";
}
