using Dapper;
using Hotel.Models;
using Hotel.Utilities;

namespace Hotel.Repositories;

public interface IStaffRepository
{
    Task<Staff> Create(Staff Data);
    Task<bool> Update(Staff Data);
    Task Delete(int Id);
    Task<List<Staff>> GetList();
    Task<Staff> GetById(int Id);
}

public class StaffRepository : BaseRepository, IStaffRepository
{
    public StaffRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Staff> Create(Staff Data)
    {
        var query = $@"INSERT INTO {TableNames.staff} 
        (name, mobile, date_of_birth, gender, shift) 
        VALUES (@Name, @Mobile, @DateOfBirth, @Gender, @Shift) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Staff>(query, Data);
    }

    public Task Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<Staff> GetById(int Id)
    {
        var query = $@"SELECT * FROM {TableNames.staff} WHERE id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Staff>(query, new { Id });
        
    }

    public async Task<List<Staff>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.staff} RETURNING *";

        using (var con = NewConnection)
            return (await con.QueryAsync<Staff>(query)).AsList();
    }

    public async Task<bool> Update(Staff Data)
    {
        var query = $@"INSERT INTO {TableNames.staff} 
        (name, mobile, date_of_birth, gender, shift) 
        VALUES (@Name, @Mobile, @DateOfBirth, @Gender, @Shift)";
        using (var con = NewConnection)
            return await con.ExecuteAsync(query, Data) > 0;
    }
}