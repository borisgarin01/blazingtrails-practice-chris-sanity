using BlazorWasm1.Models;
using Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Components;

public partial class TrailCard
{
    [Parameter, EditorRequired]
    public Trail Trail { get; set; } = default!;

    [Parameter, EditorRequired]
    public EventCallback<Trail> OnSelected { get; set; }
}
