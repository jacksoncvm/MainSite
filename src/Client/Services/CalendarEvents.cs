using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public interface ICalendarEvents
{
    Task<CalendarEvent[]> GetEventsAsync();
    void LoadEventsAsync();
}
public class CalendarEvents : ICalendarEvents
{
    private HttpClient httpClient;
    public CalendarEvent[] Events { get; private set; }

    public CalendarEvents(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public Task<CalendarEvent[]> GetEventsAsync() =>
        httpClient.GetFromJsonAsync<CalendarEvent[]>("site-data/CalendarEvents.json");

    public async void LoadEventsAsync() => Events =
        await httpClient.GetFromJsonAsync<CalendarEvent[]>("site-data/CalendarEvents.json");
}
