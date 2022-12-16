using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities;

public class Voter
{
    public Voter()
    {
        PollRelateds = new HashSet<PollRelated>();
    }

    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SocialNetwork { get; set; }
    public DateTime CreatedAt { get; set; }
    public string AddressId { get; set; } = null!;
    public string? ActualStatus { get; set; } = null!;
    public string WorkId { get; set; } = null!;


    public virtual Address Address { get; set; } = null!;
    public virtual Work Work { get; set; } = null!;
    public virtual ICollection<PollRelated> PollRelateds { get; set; }
}
