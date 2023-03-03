using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using systeminventory_sample.Models.DbFirst;

namespace inHouseSysmte.Controllers;

// APIコントローラーを示す属性
[ApiController]
// ルートURLの指定
[Route("[Controller]")]

public class inHouseSysmteController : ControllerBase
{
    // データベースコンテキストの設定
    private readonly inHouseDbContext _context;

    public inHouseSysmteController(inHouseDbContext context)
    {
        _context = context;
    }

    // GETリクエストに対するアクションメソッドの指定

    [HttpGet]
    public IEnumerable<alldata> GetSystems()
    {
        var query = from system in _context.Systems
                    join category in _context.SystemCategories
                        on system.SystemCategory equals category.Id
                    join control in _context.ProcessControls
                        on system.ProcessControl equals control.Id
                    select new alldata
                    {
                        Id = system.Id,
                        SystemCategory = system.SystemCategory,
                        CategoryName = category.Name,
                        Name = system.Name,
                        Detail = system.Detail,
                        ProcessControl = system.ProcessControl,
                        ProcessName = control.Name
                    };

        return query.ToList();

    }

    // GETリクエストに対するアクションメソッドの指定
    [HttpGet("{id}")]
    public IEnumerable<alldata> GetSystem(string id)
    {
        // 指定されたIDのシステムを取得
        var result = from system in _context.Systems
                     join category in _context.SystemCategories on system.SystemCategory equals category.Id
                     join process in _context.ProcessControls on system.ProcessControl equals process.Id
                     where system.Id == id
                     select new alldata
                     {
                         Id = system.Id,
                         SystemCategory = system.SystemCategory,
                         CategoryName = category.Name,
                         Name = system.Name,
                         Detail = system.Detail,
                         ProcessControl = system.ProcessControl,
                         ProcessName = process.Name
                     };
        return result;
    }

    // PUTリクエストに対するアクションメソッドの指定
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSystem(string id, inHouseSystem system)
    {
        // IDの不一致をチェック
        if (id != system.Id)
        {
            return BadRequest();
        }
        // データの状態を変更
        _context.Entry(system).State = EntityState.Modified;

        try
        {
            // 変更をデータベースに保存
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // データの更新に失敗した場合は、IDが一致しない場合はBadRequestを返す
            if (id != system.Id)
            {
                return BadRequest();
            }
            else
            {
                // それ以外の場合は例外をスロー
                throw;
            }
        }
        // 更新が成功した場合は204を返す
        return NoContent();
    }

    // POSTリクエストに対するアクションメソッドの指定
    [HttpPost]
    public async Task<ActionResult<inHouseSystem>> PostSystem(inHouseSystem system)
    {
        // システムをデータベースに追加
        _context.Systems.Add(system);
        // 変更をデータベースに保存
        await _context.SaveChangesAsync();
        // 追加したシステムを返す
        return CreatedAtAction(nameof(GetSystems), new { id = system.Id }, system);
    }
}

public class alldata
{
    public string? Id { get; set; }

    public long? SystemCategory { get; set; }

    public string? CategoryName { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public long? ProcessControl { get; set; }

    public string? ProcessName { get; set; }

}
