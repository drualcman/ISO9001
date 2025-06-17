# AnalyzeCustomerFeedback
Vamos ahora a implementar el módulo de análisis de feedback, usando MVVM en Blazor, para visualizar insights como:

- Valoración media
- Total de feedbacks recibidos
- Últimos comentarios
- Distribución por rating (1 a 5)

## Caso de uso: AnalyzeCustomerFeedback
### Request y Response
```csharp
public class AnalyzeFeedbackRequest { }

public class AnalyzeFeedbackResponse
{
    public double AverageRating { get; set; }
    public int TotalCount { get; set; }
    public Dictionary<int, int> RatingsByValue { get; set; } = new();
    public List<string> RecentComments { get; set; } = new();
}
```
### InputPort / OutputPort
```csharp
public interface IAnalyzeFeedbackInputPort
{
    Task HandleAsync(AnalyzeFeedbackRequest request);
}

public interface IAnalyzeFeedbackOutputPort
{
    Task HandleAsync(AnalyzeFeedbackResponse response);
}
```
### Interactor
```csharp
public class AnalyzeFeedbackInteractor : IAnalyzeFeedbackInputPort
{
    private readonly ICustomerFeedbackRepository repository;
    private readonly IAnalyzeFeedbackOutputPort outputPort;

    public AnalyzeFeedbackInteractor(
        ICustomerFeedbackRepository repository,
        IAnalyzeFeedbackOutputPort outputPort)
    {
        this.repository = repository;
        this.outputPort = outputPort;
    }

    public async Task HandleAsync(AnalyzeFeedbackRequest request)
    {
        List<CustomerFeedback> all = await repository.GetAllAsync();
        int total = all.Count;

        double avg = total > 0 ? all.Average(f => f.Rating) : 0;

        Dictionary<int, int> byRating = all
            .GroupBy(f => f.Rating)
            .ToDictionary(g => g.Key, g => g.Count());

        List<string> recent = all
            .OrderByDescending(f => f.SubmittedAt)
            .Take(5)
            .Select(f => f.Comments)
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .ToList();

        AnalyzeFeedbackResponse response = new AnalyzeFeedbackResponse
        {
            AverageRating = avg,
            TotalCount = total,
            RatingsByValue = byRating,
            RecentComments = recent
        };

        await outputPort.HandleAsync(response);
    }
}
```

## Módulo de análisis de feedback con:

- ViewModel
- Presenter
-
Componente Blazor con estilos Bulma CSS (sin JS)

### ViewModel: AnalyzeFeedbackViewModel
```csharp
public class AnalyzeFeedbackViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private double averageRating;
    private int totalCount;
    private Dictionary<int, int> ratingsByValue = new();
    private List<string> recentComments = new();

    public double AverageRating
    {
        get => averageRating;
        set
        {
            if (averageRating != value)
            {
                averageRating = value;
                NotifyPropertyChanged(nameof(AverageRating));
            }
        }
    }

    public int TotalCount
    {
        get => totalCount;
        set
        {
            if (totalCount != value)
            {
                totalCount = value;
                NotifyPropertyChanged(nameof(TotalCount));
            }
        }
    }

    public Dictionary<int, int> RatingsByValue
    {
        get => ratingsByValue;
        set
        {
            ratingsByValue = value;
            NotifyPropertyChanged(nameof(RatingsByValue));
        }
    }

    public List<string> RecentComments
    {
        get => recentComments;
        set
        {
            recentComments = value;
            NotifyPropertyChanged(nameof(RecentComments));
        }
    }

    private void NotifyPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```
### Presenter: AnalyzeFeedbackPresenter
```csharp
public class AnalyzeFeedbackPresenter : IAnalyzeFeedbackOutputPort
{
    private readonly AnalyzeFeedbackViewModel viewModel;

    public AnalyzeFeedbackPresenter(AnalyzeFeedbackViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task HandleAsync(AnalyzeFeedbackResponse response)
    {
        viewModel.AverageRating = response.AverageRating;
        viewModel.TotalCount = response.TotalCount;
        viewModel.RatingsByValue = response.RatingsByValue;
        viewModel.RecentComments = response.RecentComments;
        return Task.CompletedTask;
    }
}
```

### Componente Blazor: FeedbackStats.razor
```razor
@page "/feedback-stats"
@inject IAnalyzeFeedbackInputPort AnalyzeFeedbackInputPort

@code {
    private AnalyzeFeedbackViewModel viewModel = new AnalyzeFeedbackViewModel();
    private AnalyzeFeedbackPresenter? presenter;

    protected override async Task OnInitializedAsync()
    {
        presenter = new AnalyzeFeedbackPresenter(viewModel);
        AnalyzeFeedbackRequest request = new AnalyzeFeedbackRequest();
        await AnalyzeFeedbackInputPort.HandleAsync(request);
    }
}

<div class="box">
    <h3 class="title is-4">Customer Feedback Summary</h3>

    <p><strong>Average Rating:</strong> @viewModel.AverageRating.ToString("0.0")</p>
    <p><strong>Total Feedbacks:</strong> @viewModel.TotalCount</p>

    <h4 class="title is-5 mt-4">Ratings Distribution</h4>
    @foreach (KeyValuePair<int, int> entry in viewModel.RatingsByValue.OrderBy(e => e.Key))
    {
        <div class="mb-2">
            <label class="label">@entry.Key Stars (@entry.Value)</label>
            <progress class="progress is-info" max="@viewModel.TotalCount" value="@entry.Value">
                @entry.Value
            </progress>
        </div>
    }

    <h4 class="title is-5 mt-5">Recent Comments</h4>
    @if (viewModel.RecentComments.Count == 0)
    {
        <p>No comments submitted.</p>
    }
    else
    {
        <ul>
            @foreach (string comment in viewModel.RecentComments)
            {
                <li class="mb-2 has-background-light p-2 is-italic">@comment</li>
            }
        </ul>
    }
</div>
```