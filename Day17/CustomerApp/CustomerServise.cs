public class CustomerDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

}

public interface ICustomerService
{
    Task<List<CustomerDTO>> GetAllCustomersAsync();
    Task<CustomerDTO?> GetCustomerByIdAsync(int id);
    Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto);
    Task<bool> UpdateCustomerAsync(int id, CustomerDTO dto);
    Task<bool> DeleteCustomerAsync(int id);
}

public class CustomerService : ICustomerService
{
    private static List<CustomerDTO> _customers = new()
    {
        new CustomerDTO { Id = 1, Name = "Acme Corp", Email = "contact@acme.com" },
        new CustomerDTO { Id = 2, Name = "TechStart Inc", Email = "info@techstart.com" }
    };

    private readonly ILogger<CustomerService> _logger;

    public CustomerService(ILogger<CustomerService> logger)
    {
        _logger = logger;
    }

    public Task<List<CustomerDTO>> GetAllCustomersAsync()
    {
        _logger.LogInformation("Fetching all customers");
        return Task.FromResult(_customers);
    }

    public Task<CustomerDTO?> GetCustomerByIdAsync(int id)
    {
        _logger.LogInformation($"Fetching customer {id}");
        var customer = _customers.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(customer);
    }

    public Task<CustomerDTO> CreateCustomerAsync(CustomerDTO dto)
    {
        dto.Id = _customers.Any() ? _customers.Max(x => x.Id) + 1 : 1;
        _customers.Add(dto);
        return Task.FromResult(dto);
    }

    public Task<bool> UpdateCustomerAsync(int id, CustomerDTO dto)
    {
        var existing = _customers.FirstOrDefault(x => x.Id == id);
        if (existing == null)
            return Task.FromResult(false);

        existing.Name = dto.Name;
        existing.Email = dto.Email;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = _customers.FirstOrDefault(x => x.Id == id);
        if (customer == null)
            return Task.FromResult(false);

        _customers.Remove(customer);
        return Task.FromResult(true);
    }
}