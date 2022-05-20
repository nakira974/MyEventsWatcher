using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record BoxOfficeInfo(
    [property: JsonPropertyName("phoneNumberDetail")] string PhoneNumberDetail,
    [property: JsonPropertyName("willCallDetail")] string WillCallDetail,
    [property: JsonPropertyName("openHoursDetail")] string OpenHoursDetail,
    [property: JsonPropertyName("acceptedPaymentDetail")] string AcceptedPaymentDetail
);