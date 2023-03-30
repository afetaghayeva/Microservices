using Microsoft.AspNetCore.Mvc;
using Reservation.API.Infrastructure;
using Reservation.API.Models;

namespace Reservation.Api.Controllers
{
    public class ResController : Controller
    {
        private readonly IReservationService _reservationService;
        public ResController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        [HttpGet("{id}")]
        public ReservationDTO Get(int id)
        {
            return _reservationService.GetResByBkgNumber(id);
        }
    }
}
