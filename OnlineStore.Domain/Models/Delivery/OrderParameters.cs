namespace OnlineStore.Core.Models;

public class OrderParameters
{
    // Фильтр по пользователю
    public User? User { get; set; }              // Пользователь, чьи заказы ищем
    
    // Фильтр по статусу доставки
    public DeliveryStatus? DeliveryStatus { get; set; }
    
    // Фильтр по ID заказа
    public int? Id { get; set; }                 // Конкретный заказ
    
    // Фильтр по датам
    public DateTime? StartDate { get; set; }     // Начальная дата периода
    public DateTime? EndDate { get; set; }       // Конечная дата периода
    
    // Фильтр по активности
    public bool? IsActive { get; set; }          // Активные/неактивные заказы
    
    // Фильтр по цене
    public float? MinPrice { get; set; }         // Минимальная сумма заказа
    public float? MaxPrice { get; set; }         // Максимальная сумма заказа
}