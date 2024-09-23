using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contracts;

public interface IPersonService
{
    Task<IActionResult> RegisterPersonAsync<T>(T newPerson) where T : class, IPerson;
}