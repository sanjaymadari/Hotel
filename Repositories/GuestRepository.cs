using Dapper;
using Hotel.Models;
using Hotel.Utilities;

namespace Hotel.Repositories;

public interface IGuestRepository
{
    Task<Guest> Create(Guest Item);
    Task<bool> Update(Guest Item);
    Task<bool> Delete(int Id);
    Task<List<Guest>> GetList();
    Task<Guest> GetById(int Id);
    Task<List<Guest>> GetListByScheduleId(int ScheduleId);
}

public class GuestRepository : BaseRepository, IGuestRepository
{
    public GuestRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Guest> Create(Guest Item)
    {
        var query = $@"INSERT INTO {TableNames.guest} 
        (name, mobile, email, date_of_birth, address, gender) 
        VALUES (@Name, @Mobile, @Email, @DateOfBirth, @Address, @Gender) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Guest>(query, Item);
    }

    public async Task<bool> Delete(int Id)
    {
        var query = $@"DELETE FROM {TableNames.guest} WHERE id = @Id";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, new { Id }) > 0;
    }

    public async Task<Guest> GetById(int Id)
    {
        var query = $@"SELECT * FROM {TableNames.guest} WHERE id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Guest>(query, new { Id });
    }

    public async Task<List<Guest>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.guest}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Guest>(query)).AsList();
    }

    public async Task<List<Guest>> GetListByScheduleId(int ScheduleId)
    {
        var query = $@"SELECT * FROM {TableNames.schedule} s
        LEFT JOIN {TableNames.guest} g ON g.id = s.guest_id
        WHERE s.id = @ScheduleID";

        using (var con = NewConnection)
            return (await con.QueryAsync<Guest>(query, new { ScheduleId })).AsList();

    }

    public async Task<bool> Update(Guest Item)
    {
        var query = $@"UPDATE {TableNames.guest} 
        SET name = @Name, mobile = @Mobile, email = @Email, 
        date_of_birth = @DateOfBirth, address = @Address WHERE id = @Id";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, Item) > 0;
    }
}